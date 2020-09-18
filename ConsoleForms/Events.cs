using System;
using System.Threading;
using System.Collections;
using System.Runtime.InteropServices;
using PinkConsoleForms.PinkWinApi;
using System.Windows.Forms;

namespace PinkConsoleForms
{
    public class Events
    {
        public ConsoleForms Owner;

        public void EventsInit()
        {
            InstallHook();
            InitProc();
        }

        #region ---     Mouse Hook     ---
        static IntPtr hHook = IntPtr.Zero;
        static IntPtr hModule = IntPtr.Zero;
        static bool hookInstall = false;
        static WinApi.HookProc hookDel;

        public void InstallHook()
        {
            Owner.HiddenForm.Invoke((MethodInvoker)(() =>
            {
                hModule = Marshal.GetHINSTANCE(AppDomain.CurrentDomain.GetAssemblies()[0].GetModules()[0]);
                hookDel = new WinApi.HookProc(HookProcFunction);

                hHook = WinApi.SetWindowsHookEx(HookType.WH_MOUSE_LL,
                    hookDel, hModule, 0);

                if (hHook != IntPtr.Zero)
                    hookInstall = true;
                else
                    throw new Exception("Can't install low level keyboard hook!");
            }));
        }

        public static bool IsHookInstalled
        {
            get { return hookInstall && hHook != IntPtr.Zero; }
        }

        public static void UnInstallHook()
        {
            if (IsHookInstalled)
            {
                if (!WinApi.UnhookWindowsHookEx(hHook))
                    throw new Exception("Can't uninstall low level keyboard hook!");
                hHook = IntPtr.Zero;
                hModule = IntPtr.Zero;
                hookInstall = false;
            }
        }

        IntPtr HookProcFunction(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode == 0)
            {
                MSLLHOOKSTRUCT mhs = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                var inwindow = Owner.MouseInWindow(mhs.pt.X, mhs.pt.Y);
                switch ((WM)wParam.ToInt32())
                {
                    case WM.MOUSEMOVE:
                        if (inwindow)
                            OnMouseMove?.Invoke(Owner.ToConsoleCoord(mhs.pt.X, mhs.pt.Y).X, Owner.ToConsoleCoord(mhs.pt.X, mhs.pt.Y).Y, mhs.pt.X, mhs.pt.Y, Owner.GetMouseButtonConsole());
                        OnGlobalMouseMove?.Invoke(mhs.pt.X, mhs.pt.Y, Owner.GetMouseButtonScreen());
                        break;
                    case WM.LBUTTONDOWN:
                        OnMouseDown?.Invoke(Owner.ToConsoleCoord(mhs.pt.X, mhs.pt.Y).X, Owner.ToConsoleCoord(mhs.pt.X, mhs.pt.Y).Y, mhs.pt.X, mhs.pt.Y, inwindow, MButton.Left);
                        break;
                    case WM.MBUTTONDOWN:
                        OnMouseDown?.Invoke(Owner.ToConsoleCoord(mhs.pt.X, mhs.pt.Y).X, Owner.ToConsoleCoord(mhs.pt.X, mhs.pt.Y).Y, mhs.pt.X, mhs.pt.Y, inwindow, MButton.Center);
                        break;
                    case WM.RBUTTONDOWN:
                        OnMouseDown?.Invoke(Owner.ToConsoleCoord(mhs.pt.X, mhs.pt.Y).X, Owner.ToConsoleCoord(mhs.pt.X, mhs.pt.Y).Y, mhs.pt.X, mhs.pt.Y, inwindow, MButton.Right);
                        break;
                    case WM.XBUTTONDOWN:
                        OnMouseDown?.Invoke(Owner.ToConsoleCoord(mhs.pt.X, mhs.pt.Y).X, Owner.ToConsoleCoord(mhs.pt.X, mhs.pt.Y).Y, mhs.pt.X, mhs.pt.Y, inwindow, MButton.XBUTTON1 | MButton.XBUTTON2);
                        break;
                    case WM.LBUTTONUP:
                        OnMouseUp?.Invoke(Owner.ToConsoleCoord(mhs.pt.X, mhs.pt.Y).X, Owner.ToConsoleCoord(mhs.pt.X, mhs.pt.Y).Y, mhs.pt.X, mhs.pt.Y, inwindow, MButton.Left);
                        break;
                    case WM.MBUTTONUP:
                        OnMouseUp?.Invoke(Owner.ToConsoleCoord(mhs.pt.X, mhs.pt.Y).X, Owner.ToConsoleCoord(mhs.pt.X, mhs.pt.Y).Y, mhs.pt.X, mhs.pt.Y, inwindow, MButton.Center);
                        break;
                    case WM.RBUTTONUP:
                        OnMouseUp?.Invoke(Owner.ToConsoleCoord(mhs.pt.X, mhs.pt.Y).X, Owner.ToConsoleCoord(mhs.pt.X, mhs.pt.Y).Y, mhs.pt.X, mhs.pt.Y, inwindow, MButton.Right);
                        break;
                    case WM.XBUTTONUP:
                        OnMouseUp?.Invoke(Owner.ToConsoleCoord(mhs.pt.X, mhs.pt.Y).X, Owner.ToConsoleCoord(mhs.pt.X, mhs.pt.Y).Y, mhs.pt.X, mhs.pt.Y, inwindow, MButton.XBUTTON1 | MButton.XBUTTON2);
                        break;
                    case WM.MOUSEWHEEL:
                        OnMouseWheel?.Invoke(GetWheelStateByData(mhs.mouseData), mhs.mouseData, mhs.pt.X, mhs.pt.Y, Owner.GetMouseButtonScreen());
                        break;
                    default:
                        
                        break;
                }
            }

            return WinApi.CallNextHookEx(hHook, nCode, wParam, lParam);
        }

        private WheelState GetWheelStateByData(int data) => data < 0 ? (Owner.GetKeyState((int)Keys.VK_RSHIFT) != 0 || Owner.GetKeyState((int)Keys.VK_LSHIFT) != 0 ? WheelState.Right : WheelState.Down) : (Owner.GetKeyState((int)Keys.VK_RSHIFT) != 0 || Owner.GetKeyState((int)Keys.VK_LSHIFT) != 0 ? WheelState.Left : WheelState.Up);
        #endregion

        #region ---    Simply Events   ---
        public Thread CyclicCheckingEventsThread;

        public int CyclicCheckingEventsInterval = 5;

        private Point point = new Point(), oldpoint = new Point(),
                    pointg = new Point(), oldpointg = new Point();
        private MButton mb, oldmb, mbg;
        private char key, oldkey;
        private Size s, olds;
        private short[] keysg = new short[255], oldkeysg = new short[255];

        private void InitProc()
        {
            CyclicCheckingEventsThread = new Thread(() => ProcFunction());
            CyclicCheckingEventsThread.IsBackground = true;
            CyclicCheckingEventsThread.Start();
        }

        private void ProcFunction()
        {
            while (true)
            {
                try
                {
                    var starttime = DateTime.Now;

                    //Get values
                    point = Owner.GetMCursorPositionConsole();
                    pointg = Owner.GetMCursorPositionScreen();
                    mb = Owner.GetMouseButtonScreen();
                    mbg = Owner.GetMouseButtonScreen();
                    s = Owner.GetWindowSize();
                    for (var i = 0; i < 255; i++)
                        keysg[i] = Owner.GetKeyState(i);

                    //OnResize
                    if (s.Width != olds.Width || s.Height != olds.Height)
                        OnResize?.Invoke(s);

                    //OnMouseMove
                    //if (point.X != oldpoint.X || point.Y != oldpoint.Y)
                    //    OnMouseMove?.Invoke(point.X, point.Y, pointg.X, pointg.Y, mb);

                    //OnGlobalMouseMove
                    //if (pointg.X != oldpointg.X || pointg.Y != oldpointg.Y)
                    //    OnGlobalMouseMove?.Invoke(pointg.X, pointg.Y, mbg);

                    //OnGlobalKey*
                    for (var i = 0; i < 255; i++)
                        if (keysg[i] != oldkeysg[i])
                        {
                            if (keysg[i] == 0)
                                OnGlobalKeyUp?.Invoke(i, keysg);
                            else
                                OnGlobalKeyDown?.Invoke(i, keysg);
                            break;
                        }

                    //OnMouse*
                    //if (mb != oldmb)
                    //    if (mb == MButton.Null)
                    //        OnMouseUp?.Invoke(point.X, point.Y, pointg.X, pointg.Y, point.X != new Point().X && point.Y != new Point().Y, oldmb);
                    //    else if (mb != MButton.Null)
                    //        OnMouseDown?.Invoke(point.X, point.Y, pointg.X, pointg.Y, point.X != new Point().X && point.Y != new Point().Y, mb);

                    //OnKeyDown
                    if (Console.KeyAvailable)
                    {
                        key = Console.ReadKey().KeyChar;
                        OnKeyDown?.Invoke(key);
                    }

                    //Save old values
                    olds = s;
                    keysg.CopyTo(oldkeysg, 0);
                    oldkey = key;
                    oldmb = mb;
                    oldpoint = point;
                    oldpointg = pointg;

                    //OnEventHandlerTimerElapsed
                    OnEventHandlerTimerElapsed?.Invoke((DateTime.Now - starttime).TotalMilliseconds);
                }
                catch (Exception ex)
                {
                    CallException(ex);
                }

                Thread.Sleep(CyclicCheckingEventsInterval);
            }
        }
        #endregion

        private static void CallException(Exception ex)
        {
            var result = "";
            foreach (DictionaryEntry obj in ex.Data)
            {
                result += "  " + obj.Key;
            }

            Console.WriteLine( $"\r\n-----------------------BEGIN-------------------------" +
                               $"\r\n[MESSAGE]\r\n{ex.Message}" +
                               $"\r\n[STACK TRACE]\r\n{ex.StackTrace}" +
                               $"\r\n[SOURCE]\r\n{ex.Source}" +
                               $"\r\n[TARGET SITE]\r\n{ex.TargetSite}" +
                               $"\r\n[HRESULT]\r\n{ex.HResult}" +
                               $"\r\n[DATA]\r\n{result}" +
                               $"\r\n[HELP LINK]\r\n{ex.HelpLink}" +
                               $"\r\n-------------------------END-------------------------");
        }

        public delegate void OnMouseWheelEventHandler(WheelState state, int data, int x, int y, MButton mButton);
        /// <summary>
        /// Происходит при движении мыши по окну консоли, получает консольные кординаты и нажатую клавишу мыши
        /// </summary>
        public event OnMouseWheelEventHandler OnMouseWheel;

        public delegate void OnMouseMoveEventHandler(int x, int y, int xglobal, int yglobal, MButton mButton);
        /// <summary>
        /// Происходит при движении мыши по окну консоли, получает консольные кординаты и нажатую клавишу мыши
        /// </summary>
        public event OnMouseMoveEventHandler OnMouseMove;

        public delegate void OnMouseDownEventHandler(int x, int y, int xglobal, int yglobal, bool inwindow, MButton mButton);
        /// <summary>
        /// Происходит при нажатии кнопки мыши в окне консоли, получает консольные кординаты и нажатую клавишу мыши
        /// </summary>
        public event OnMouseDownEventHandler OnMouseDown;

        public delegate void OnMouseUpEventHandler(int x, int y, int xglobal, int yglobal, bool inwindow, MButton mButton);
        /// <summary>
        /// Происходит при отжатии кнопки мыши в окне консоли, получает консольные кординаты и нажатую клавишу мыши
        /// </summary>
        public event OnMouseUpEventHandler OnMouseUp;

        public delegate void OnKeyDownEventHandler(char key);
        /// <summary>
        /// Происходит при нажатии клавиши, получает введенный символ
        /// </summary>
        public event OnKeyDownEventHandler OnKeyDown;

        //public delegate void OnKeyUpEventHandler(char key);
        //public event OnKeyUpEventHandler OnKeyUp;

        public delegate void OnGlobalKeyDownEventHandler(int key, short[] keys);
        /// <summary>
        /// Происходит при нажатии клавиши клавиатуры или мыши, получает введенный символ и состояния всех клавиш
        /// </summary>
        public event OnGlobalKeyDownEventHandler OnGlobalKeyDown;

        public delegate void OnGlobalKeyUpEventHandler(int key, short[] keys);
        /// <summary>
        /// Происходит при отжатии клавиши клавиатуры или мыши, получает введенный символ и состояния всех клавиш
        /// </summary>
        public event OnGlobalKeyUpEventHandler OnGlobalKeyUp;

        public delegate void OnGlobalMouseMoveEventHandler(int x, int y, MButton mb);
        /// <summary>
        /// Происходит при движении мыши
        /// </summary>
        public event OnGlobalMouseMoveEventHandler OnGlobalMouseMove;

        public delegate void OnResizeEventHandler(Size size);
        /// <summary>
        /// Происходит при изменении размеров консоли
        /// </summary>
        public event OnResizeEventHandler OnResize;

        public delegate void OnEventHandlerTimerElapsedEventHandler(double processingTime);
        /// <summary>
        /// Происходит после окончания EventHandlerTimer
        /// </summary>
        public event OnEventHandlerTimerElapsedEventHandler OnEventHandlerTimerElapsed;
    }
}
