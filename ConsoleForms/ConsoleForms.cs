using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using PinkConsoleForms.PinkWinApi;
using System.Threading;
using System.Windows.Forms;

namespace PinkConsoleForms
{
    public class ConsoleForms : Events, IConsoleForms
    {
        public ConsoleForms(bool SetDefaultOptions = true)
        {
            Owner = this;
            
            CreateHiddenWindow();

            _ConsoleBufferInit();

            MainThread = Thread.CurrentThread;

            OnResize += (Size s) => SetBufferEqualsSize();

            if (SetDefaultOptions)
            {
                _VirtualTerminalInit();

                ConsoleFont = ConsoleFont.Consolas;
                ConsoleCharSize = new Size(8, 16);

                QuickEditMode = false;

                SetBufferEqualsSize();
            }
        }

        /// <summary>
        /// ¯\_(ツ)_/¯  Author = @Vlas Dergaev
        /// </summary>
        public const string Author = "@Vlas Dergaev";

        /// <summary>
        /// Устанавливает, будет ли создаваться буфер того, что печатается в консоль
        /// </summary>
        public static bool EnableConsoleBufferWriter { get; set; } = true;

        
        public static Thread MainThread;
        public IntPtr ConsoleHWND { get => hWnd; }
        public StringBuilder ConsoleText { get; private set; }
        public bool BufferEqualsSize { get; set; } = true;
        public Form HiddenForm;

        private IntPtr hWnd = WinApi.FindWindow(null, Console.Title);
        private Rect wndRect = new Rect();
        private MultiTextWriter MultiWriter = new MultiTextWriter();
        private bool _FullScreen;
        private bool _LockKeyboardWriting;


        #region --- Console Font Info ---
        public Size ConsoleCharSize
        {
            get => new Size(WinApi.GetCurrentFontInfo().dwFontSize.X, WinApi.GetCurrentFontInfo().dwFontSize.Y);
            set
            {
                CONSOLE_FONT_INFO_EX ConsoleFontInfo = WinApi.GetCurrentFontInfo();
                ConsoleFontInfo.dwFontSize.X = (short)value.Width;
                ConsoleFontInfo.dwFontSize.Y = (short)value.Height;
                WinApi.SetCurrentFontInfo(ConsoleFontInfo);
            }
        }

        public ConsoleFont ConsoleFont
        {
            get => new ConsoleFont(WinApi.GetCurrentFontInfo().FaceName);
            set
            {
                CONSOLE_FONT_INFO_EX ConsoleFontInfo = WinApi.GetCurrentFontInfo();
                ConsoleFontInfo.FaceName = value.FontName;
                WinApi.SetCurrentFontInfo(ConsoleFontInfo);
            }
        }
        #endregion

        #region ---      Cursor       ---
        public Point Cursor
        {
            get => new Point(Console.CursorLeft, Console.CursorTop);
            set => GoToXY(value);
        }


        public void GoToXY(int x, int y)
        {
            if (x < Console.WindowWidth && y < Console.WindowHeight && x >= 0 && y >= 0)
                Console.SetCursorPosition(x, y);
        }

        public void GoToXY(Point p) => GoToXY(p.X, p.Y);
        #endregion

        #region ---  Console Window   ---
        public bool FullScreen
        {
            get => _FullScreen;
            set
            {
                if (value && !_FullScreen)
                {
                    if (IsWindows10())
                    {
                        SetWindowFlags(WindowStyles.WS_BORDER);
                        SetWindow(-3, -3, ScreenSize().Width + 6, ScreenSize().Height + 6, WindowState.HWND_TOP);
                        _FullScreen = true;
                    }
                }
                else if (_FullScreen && !value)
                {
                    if (IsWindows10())
                        Console.SetWindowSize(120, 30);
                    else
                        Console.SetWindowSize(80, 25);
                    SetWindowFlags(WindowStyles.WS_BORDER);
                    _FullScreen = false;
                }
            }
        }

        public Size ConsoleSize
        {
            get => new Size(Console.WindowWidth, Console.WindowHeight);
            set
            {
                Console.WindowWidth = value.Width;
                Console.WindowHeight = value.Height;
            }
        }

        public Rect ConsoleWindowRect
        {
            get => GetWindow();
            set => SetWindow(value.Left, value.Top, value.Right - value.Left, value.Bottom - value.Top, 0);
        }


        public Rect GetWindow()
        {
            WinApi.GetWindowRect(hWnd, out wndRect);
            return wndRect;
        }

        public Size GetWindowSize() => new Size(GetWindow().Right - GetWindow().Left, GetWindow().Bottom - GetWindow().Top);

        public Point GetWindowPoint() => new Point(GetWindow().Left, GetWindow().Top);

        public Rect ScreenRect() => new Rect(System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Left,
            System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Top,
            System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Right,
            System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Bottom);

        public Size ScreenSize() => new Size(System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width,
            System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height);

        public void SetWindow(int x, int y, int width, int height, WindowState state) => WinApi.SetWindowPos(hWnd, new IntPtr(Convert.ToInt32(state)), x, y, width, height, 0);

        public void SetConsoleSize(int width, int height)
        {
            Console.SetWindowSize(width, height);
            SetBufferEqualsSize();
        }

        public void SetWindowFlags(params WindowStyles[] flags)
        {
            foreach (var flag in flags)
                WinApi.SetWindowLong(hWnd,
                    (int)GWL.GWL_STYLE,
                    WinApi.GetWindowLong(hWnd, (int)GWL.GWL_STYLE) ^ (uint)flag);
        }

        public IntPtr CloseWindowQuickly() => WinApi.SendMessage(hWnd, 16, 0, IntPtr.Zero);

        public bool GotFocus() => WinApi.SetWindowPos(hWnd, new IntPtr(Convert.ToInt32(WindowState.HWND_TOP)), 0, 0, 0, 0, 0x0002 | 0x0001);
        #endregion

        #region ---      Windows      ---
        public IntPtr GetForegroundWindow() => WinApi.GetForegroundWindow();

        public bool SetForegroundWindow(IntPtr hWnd) => WinApi.SetForegroundWindow(hWnd);
        #endregion

        #region ---       Mouse       ---
        public Point GetMCursorPositionScreen() => new Point(System.Windows.Forms.Cursor.Position.X, System.Windows.Forms.Cursor.Position.Y);

        public bool MouseInWindow(int x, int y)
        {
            return Math.IntInRange(x, Owner.ConsoleWindowRect.Left + 7, Owner.ConsoleWindowRect.Right) && Math.IntInRange(y, Owner.ConsoleWindowRect.Top + 27, Owner.ConsoleWindowRect.Bottom);
        }

        public Point ToWindowCoord(int x, int y)
        {
            return new Point(x - ConsoleWindowRect.Left - 7, y - ConsoleWindowRect.Top - 27);
        }

        public Point ToConsoleCoord(int x, int y)
        {
            return new Point(ToWindowCoord(x, y).X / Owner.ConsoleCharSize.Width, ToWindowCoord(x, y).Y / Owner.ConsoleCharSize.Height);
        }

        public Point GetMCursorPositionWindow()
        {
            if (MouseInWindow(GetMCursorPositionScreen().X, GetMCursorPositionScreen().Y))
                return ToWindowCoord(System.Windows.Forms.Cursor.Position.X, System.Windows.Forms.Cursor.Position.Y);
            return new Point();
        }

        public Point GetMCursorPositionConsole() => new Point(GetMCursorPositionWindow().X / ConsoleCharSize.Width, GetMCursorPositionWindow().Y / ConsoleCharSize.Height);

        public MButton GetMouseButtonScreen()
        {
            if (WinApi.GetAsyncKeyState(1) != 0)
                return MButton.Left;
            else if (WinApi.GetAsyncKeyState(2) != 0)
                return MButton.Right;
            else if (WinApi.GetAsyncKeyState(4) != 0)
                return MButton.Center;
            else if (WinApi.GetAsyncKeyState(5) != 0)
                return MButton.XBUTTON1;
            else if (WinApi.GetAsyncKeyState(6) != 0)
                return MButton.XBUTTON2;
            else return MButton.Null;
        }

        public MButton GetMouseButtonConsole()
        {
            if (Math.IntInRange(GetMCursorPositionScreen().X, ConsoleWindowRect.Left + 7, ConsoleWindowRect.Right) && Math.IntInRange(GetMCursorPositionScreen().Y, ConsoleWindowRect.Top + 27, ConsoleWindowRect.Bottom))
                return GetMouseButtonScreen();
            return MButton.Null;
        }

        public bool SetCursorPos(int x, int y) => WinApi.SetCursorPos(x, y);

        public int ShowCursor(bool show) => WinApi.ShowCursor(show);
        #endregion

        #region ---     Keyboard      ---
        public bool LockKeyboardWriting
        {
            get => _LockKeyboardWriting;
            set
            {
                if (value && !_LockKeyboardWriting)
                {
                    OnKeyDown += _LockWriting;
                    _LockKeyboardWriting = true;
                }
                else if (_LockKeyboardWriting && !value)
                {
                    OnKeyDown -= _LockWriting;
                    _LockKeyboardWriting = false;
                }
            }
        }


        private void _LockWriting(char key)
        {
            GoToXY(Cursor.X - 1, Cursor.Y);
            Console.Write(' ');
            GoToXY(Cursor.X - 1, Cursor.Y);
        }

        public short GetKeyState(int key) => WinApi.GetAsyncKeyState(key);
        #endregion

        #region ---  Console Buffer   ---
        private void _ConsoleBufferInit()
        {
            ConsoleText = new StringBuilder();

            MultiWriter.AddWriter(Console.Out);
            MultiWriter.AddFileWriter(new StringWriter(ConsoleText));

            Console.SetOut(MultiWriter);
        }

        public void SetBufferEqualsSize()
        {
            try
            {
                if (BufferEqualsSize)
                {
                    Console.BufferHeight = Console.WindowHeight;
                    Console.BufferWidth = Console.WindowWidth;
                }
            }
            catch { }
        }

        public char GetChar(int x, int y)
        {
            if (EnableConsoleBufferWriter)
            {
                try
                {
                    var text = ConsoleText.ToString();
                    if (text.LastIndexOf($" {x} {y} ") != -1)
                        return text[text.LastIndexOf($" {x} {y} ")];
                }
                catch { }
                return ' ';
            }
            return ' ';
        }

        public void SaveConsole(string path)
        {
            var s = "";
            for (var x = 0; x < ConsoleSize.Height; x++) {
                for (var y = 0; x < ConsoleSize.Width; x++) {
                    if (char.IsWhiteSpace(GetChar(x, y)))
                        s += (char)32;
                    else
                        s += GetChar(y, x);
                }
                s += System.Environment.NewLine;
            }
            System.IO.File.WriteAllText(path, s, Encoding.GetEncoding("cp866"));
        }
        #endregion

        #region ---       Other       ---
        public bool QuickEditMode
        {
            set
            {
                if (value)
                    WinApi.SetConsoleMode(WinApi.GetStdHandle(StdHandle.InputHandle), 0x0040 | 0x0080 | 0x0020);
                else
                    WinApi.SetConsoleMode(WinApi.GetStdHandle(StdHandle.InputHandle), 0x0080);
            }
        }

        public void Clear()
        {
            ConsoleText.Clear();
            Console.Clear();
        }

        public bool IsWindows10()
        {
            if (((Environment.OSVersion.Version.Major == 6) && (Environment.OSVersion.Version.Minor >= 2)) || (Environment.OSVersion.Version.Major == 10))
                return true;
            else
                return false;
        }

        public void ShowMessageBox(string content, string title)
        {
            System.Windows.Forms.MessageBox.Show(content, title);
        }

        private void CreateHiddenWindow()
        {
            new Thread(() =>
            {
                HiddenForm = new Form();
                HiddenForm.Visible = true;
                HiddenForm.WindowState = FormWindowState.Minimized;
                HiddenForm.ShowInTaskbar = false;

                HiddenForm.Shown += (s, e) => EventsInit();
                HiddenForm.FormClosed += (s, e) => UnInstallHook();

                Application.EnableVisualStyles();
                //Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(HiddenForm);
            }).Start();
        }

        public Color HsvToRgb(float h, float s, float v)
        {
            int i;
            float f, p, q, t;

            if (s < float.Epsilon)
            {
                int c = (int)(v * 255);
                return Color.FromRgb(c, c, c);
            }

            h /= 60;
            i = (int)System.Math.Floor(h);
            f = h - i;
            p = v * (1 - s);
            q = v * (1 - s * f);
            t = v * (1 - s * (1 - f));

            float r, g, b;
            switch (i)
            {
                case 0: r = v; g = t; b = p; break;
                case 1: r = q; g = v; b = p; break;
                case 2: r = p; g = v; b = t; break;
                case 3: r = p; g = q; b = v; break;
                case 4: r = t; g = p; b = v; break;
                default: r = v; g = p; b = q; break;
            }

            return Color.FromRgb((int)(r * 255), (int)(g * 255), (int)(b * 255));
        }
        #endregion

        #region ---  Virtual Terminal ---
        private void _VirtualTerminalInit()
        {
            IntPtr hOut = WinApi.GetStdHandle(StdHandle.OutputHandle);
            uint dwMode = 0;
            WinApi.GetConsoleMode(hOut, out dwMode);
            dwMode |= 0x0004;
            WinApi.SetConsoleMode(hOut, dwMode);
        }

        #region --- Cursor Controls ---
        public void CurMoveToHome() => Console.Write("\x1b[H");

        public void CurMoveTo(int line, int column) => Console.Write($"\x1b[{line};{column}H");

        public void CurSavePos() => Console.Write($"\x1b[s");

        public void CurRestorePos() => Console.Write($"\x1b[u");
        #endregion

        #region --- Erase Functions ---
        public void ScrClear() => Console.Write("\x1b[J");

        public void ScrClearToEnd() => Console.Write("\x1b[0J");

        public void ScrClearToBegin() => Console.Write("\x1b[1J");

        public void LineClear() => Console.Write("\x1b[K");

        public void LineClearToEnd() => Console.Write("\x1b[0K");

        public void LineClearToBegin() => Console.Write("\x1b[1K");
        #endregion

        #region --- Colors/Graphics ---
        public void StyleClear() => Console.Write("\x1b[0m");

        public void StyleBold() => Console.Write("\x1b[1m");

        public void StyleDim() => Console.Write("\x1b[2m");

        public void StyleSet(VirtualStyles style, Colors16? foreground = null, Colors16? background = null) => 
            Console.Write($"\x1b[{(int)style}{(foreground != null ? ";" + (int)foreground : null)}{(background != null ? (background == 0 ? ";0" : ";" + ((int)background + 10)) : null)}m");


        public void SetForegroundColors256(int id) => Console.Write($"\x1b[38;5;{id}m");

        public void SetBackgroundColors256(int id) => Console.Write($"\x1b[48;5;{id}m");


        public void SetForegroundColorsRGB(int r, int g, int b) => Console.Write($"\x1b[38;2;{r};{g};{b}m");
        public void SetForegroundColorsRGB(Color cl) => Console.Write($"\x1b[38;2;{cl.R};{cl.G};{cl.B}m");

        public void SetBackgroundColorsRGB(int r, int g, int b) => Console.Write($"\x1b[48;2;{r};{g};{b}m");
        public void SetBackgroundColorsRGB(Color cl) => Console.Write($"\x1b[48;2;{cl.R};{cl.G};{cl.B}m");
        #endregion

        #endregion
    }

    public class MultiTextWriter : TextWriter
    {
        private List<TextWriter> _filewriters = new List<TextWriter>();
        private List<TextWriter> _writers = new List<TextWriter>();

        public override Encoding Encoding => Encoding.UTF8;

        public void AddFileWriter(TextWriter writer) => _filewriters.Add(writer);
        public void AddWriter(TextWriter writer) => _writers.Add(writer);

        public override void Write(char ch)
        {
            if (ConsoleForms.EnableConsoleBufferWriter)
                foreach (var writer in _filewriters)
                    writer.WriteLine(ch + ' ' + Console.CursorLeft + ' ' + Console.CursorTop + ' ');
            foreach (var writer in _writers)
                writer.Write(ch);
        }

        public override void Close()
        {
            _writers.ForEach(w => { w.Close(); });
            _filewriters.ForEach(w => { w.Close(); });
            base.Close();
        }
    }
}
