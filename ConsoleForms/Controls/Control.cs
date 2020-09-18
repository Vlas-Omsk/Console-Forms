using System;
using System.Threading;
using PinkConsoleForms.PinkDrawing;

namespace PinkConsoleForms.Controls
{
    public class Control : IControl
    {
        public Control(ConsoleForms owner)
        {
            Owner = owner;
            Drawing = new Drawing(owner);

            Owner.OnMouseMove += Move;
            Owner.OnMouseUp += Up;
            Owner.OnMouseDown += Down;

            _Redraw();
        }

        public Control(ScrollViewer owner)
        {
            OwnerScroll = owner;
            Owner = owner.Owner;
            Drawing = new Drawing(owner.Owner);

            OwnerScroll.OnRedraw += () => Redraw();

            Owner.OnMouseMove += Move;
            Owner.OnMouseUp += Up;
            Owner.OnMouseDown += Down;

            _Redraw();
        }

        #region ---     Protected     ---
        protected bool CVisible = true;
        protected bool CFreed = false;
        protected bool CTextCentered;
        protected bool CShowBorders = true;
        protected ConsoleColor CBordersTextColor = ConsoleColor.Gray;
        protected ConsoleColor CBackgroundColor = ConsoleColor.Black;
        protected string CState;
        protected Point CLocation;
        protected Size CSize;
        protected string CText = "";
        protected Border CBorder = PinkConsoleForms.PinkDrawing.Border.DoubleLine;
        protected Rect CPadding = new Rect(1);

        private bool IsClearing;
        private bool IsRedrawing;
        private ScrollViewer OwnerScroll;


        protected virtual void Move(int x, int y, int xglobal, int yglobal, MButton mb)
        {
            if (PointOnControl(x, y))
                MouseMove?.Invoke(x, y, mb);
        }

        protected virtual void Down(int x, int y, int xglobal, int yglobal, bool inwindow, MButton mb)
        {
            if (PointOnControl(x, y) && inwindow)
                MouseDown?.Invoke(x, y, mb);
        }

        protected virtual void Up(int x, int y, int xglobal, int yglobal, bool inwindow, MButton mb)
        {
            if (PointOnControl(x, y) && inwindow)
                MouseUp?.Invoke(x, y, mb);
        }

        protected virtual void _Clear(char c = ' ', bool savecolor = true)
        {
            if (IsClearing)
                return;

            IsClearing = true;

            var p = new Point(Owner.Cursor.X, Owner.Cursor.Y);
            var OldTextColor = Console.ForegroundColor;
            var OldBackColor = Console.BackgroundColor;
            if (savecolor)
                Console.ResetColor();

            for (var y = CLocation.Y; y < CSize.Height + CLocation.Y; y++)
            {
                GoToXY(CLocation.X, y);
                Write(new string(' ', CSize.Width));
            }

            if (savecolor)
            {
                Console.ForegroundColor = OldTextColor;
                Console.BackgroundColor = OldBackColor;
                GoToXY(p.X, p.Y);
            }

            IsClearing = false;
        }

        protected virtual void _Redraw(string state = " ", ConsoleColor backgroundcolor = (ConsoleColor)(-1), ConsoleColor borderstextcolor = (ConsoleColor)(-1))
        {
            if (IsRedrawing)
                return;

            CState = state;
            

            new Thread(() =>
            {
                IsRedrawing = true;

                var p = new Point(Owner.Cursor.X, Owner.Cursor.Y);
                var OldTextColor = Console.ForegroundColor;
                var OldBackColor = Console.BackgroundColor;
                Console.ResetColor();

                Console.ForegroundColor = (borderstextcolor == (ConsoleColor)(-1) ? CBordersTextColor : borderstextcolor);
                Console.BackgroundColor = (backgroundcolor == (ConsoleColor)(-1) ? CBackgroundColor : backgroundcolor);

                if (CVisible && !CFreed)
                {
                    _Clear(' ', false);
                    if (CShowBorders)
                        Drawing.DrawBorder(new Rect(CLocation, CSize), CBorder, this);
                    if (!string.IsNullOrEmpty(CText))
                        Drawing.DrawText(new Rect(CLocation, CSize), CText, (CShowBorders ? new Rect(1) : new Rect(0)) + CPadding, CTextCentered, CState, this);
                }

                Console.ForegroundColor = OldTextColor;
                Console.BackgroundColor = OldBackColor;
                GoToXY(p.X, p.Y);

                OnRedraw?.Invoke();

                IsRedrawing = false;
            }).Start();
        }


        public void GoToXY(int x, int y)
        {
            if (OwnerScroll == null)
                Owner.GoToXY(x, y);
            else
                OwnerScroll.GoToXY(x, y);
        }

        public void Write(dynamic obj)
        {
            if (OwnerScroll == null)
                Console.Write(obj);
            else
                OwnerScroll.Write(obj);
        }

        public void WriteLine(dynamic obj)
        {
            if (OwnerScroll == null)
                Console.WriteLine(obj);
            else
                OwnerScroll.WriteLine(obj);
        }

        //private void _Redraw(string state, params ConsoleColor[] cl)
        //{
        //    CState = state;
        //    var p = new Point(Owner.Cursor.X, Owner.Cursor.Y);
        //    var OldTextColor = Console.ForegroundColor;
        //    var OldBackColor = Console.BackgroundColor;
        //    if (cl.Length == 0)
        //    {
        //        Console.ForegroundColor = (System.ConsoleColor)CBordersTextColor;
        //        Console.BackgroundColor = (System.ConsoleColor)CBackgroundColor;
        //    }
        //    else
        //    {
        //        Console.ForegroundColor = (System.ConsoleColor)cl[0];
        //        Console.BackgroundColor = (System.ConsoleColor)cl[1];
        //    }

        //    if (CShowBorders)
        //    {
        //        for (var x = CLocation.X; x <= CSize.Width + CLocation.X - 1; x++)
        //        {
        //            Owner.GoToXY(x, CLocation.Y);
        //            if (x == CLocation.X)
        //                Console.Write('╔');
        //            else if (x == CSize.Width + CLocation.X - 1)
        //                Console.Write('╗');
        //            else
        //                Console.Write('═');

        //            Owner.GoToXY(x, CLocation.Y + CSize.Height);
        //            if (x == CLocation.X)
        //                Console.Write('╚');
        //            else if (x == CSize.Width + CLocation.X - 1)
        //                Console.Write('╝');
        //            else
        //                Console.Write('═');

        //            if (Animation != 0)
        //                Thread.Sleep(Animation);
        //        }

        //        var border = '║';
        //        if (CShowBorders == false)
        //            border = ' ';

        //        if (CTextCentered)
        //        {
        //            var n = 0;
        //            for (var y = CLocation.Y + 1; y <= CSize.Height + CLocation.Y - 1; y++)
        //            {
        //                Owner.GoToXY(CLocation.X, y);
        //                try
        //                {
        //                    var l = (n + 1) * (CSize.Width - 4);
        //                    var g = n * (CSize.Width - 4);
        //                    if (l > CText.Length - 1)
        //                    {
        //                        l = CText.Length;
        //                        int t = ((CSize.Width - 4) - (l - n * (CSize.Width - 4))) / 2;
        //                        Console.Write(border + state + new string(' ', t) + CText.Substring(g, l - g));
        //                        Console.Write(new string(' ', (CSize.Width - 4) - (new string(' ', t) + CText.Substring(g, l - g)).Length) + state + border);
        //                    }
        //                    else
        //                        Console.Write(border + state + CText.Substring(g, l - g) + state + border);
        //                }
        //                catch
        //                {
        //                    Console.Write(border + state + new string(' ', CSize.Width - 4) + state + border);
        //                }
        //                n += 1;

        //                if (Animation != 0)
        //                    Thread.Sleep(Animation);
        //            }
        //        }
        //        else
        //        {
        //            var n = 0;
        //            for (var y = CLocation.Y + 1; y <= CSize.Height + CLocation.Y - 1; y++)
        //            {
        //                Owner.GoToXY(CLocation.X, y);
        //                try
        //                {
        //                    var l = (n + 1) * (CSize.Width - 2);
        //                    if (l > CText.Length - 1)
        //                    {
        //                        l = CText.Length;
        //                        Console.Write(border + CText.Substring(n * (CSize.Width - 2), l - n * (CSize.Width - 2)));
        //                        Console.Write(new string(' ', (CSize.Width - 2) - (CText.Substring(n * (CSize.Width - 2), l - n * (CSize.Width - 2))).Length) + border);
        //                    }
        //                    else
        //                        Console.Write(border + CText.Substring(n * (CSize.Width - 2), l - n * (CSize.Width - 2)) + border);
        //                }
        //                catch
        //                {
        //                    Console.Write(border + new string(' ', CSize.Width - 2) + border);
        //                }
        //                n += 1;

        //                if (Animation != 0)
        //                    Thread.Sleep(Animation);
        //            }
        //        }

        //        Console.ForegroundColor = OldTextColor;
        //        Console.BackgroundColor = OldBackColor;
        //        Owner.GoToXY(p.X, p.Y);
        //    }
        //}
        #endregion

        #region ---       Public      ---
        public ConsoleForms Owner;
        public Drawing Drawing;
        public int Animation = 0;


        public virtual void Clear()
        {
            _Clear();
        }

        public virtual void Redraw()
        {
            _Redraw();
        }

        public virtual void Free()
        {
            Owner.OnMouseMove -= Move;
            Owner.OnMouseUp -= Up;
            Owner.OnMouseDown -= Down;

            _Clear(' ');

            CFreed = true;
        }

        public bool PointOnControl(int x, int y)
        {
            if (OwnerScroll != null)
                return Math.IntInRange(x, CLocation.X + OwnerScroll.CLocation.X + OwnerScroll.HorizontalScrollOffset, CSize.Width + CLocation.X - 1 + OwnerScroll.CLocation.X + OwnerScroll.HorizontalScrollOffset) && 
                    Math.IntInRange(y, CLocation.Y + OwnerScroll.CLocation.Y + OwnerScroll.VerticalScrollOffset, CSize.Height + CLocation.Y + OwnerScroll.CLocation.Y + OwnerScroll.VerticalScrollOffset);
            return Math.IntInRange(x, CLocation.X, CSize.Width + CLocation.X - 1) && Math.IntInRange(y, CLocation.Y, CSize.Height + CLocation.Y);
        }
        #endregion

        #region ---     Properties    ---
        public Point Location { get => CLocation; set => SetLocation(value); }
        public void SetLocation(Point get)
        {
            _Clear(' ');
            CLocation = get;
            OnChangeLocation?.Invoke(get);
        }

        public Size Size { get => CSize; set => SetSize(value); }
        public void SetSize(Size get)
        {
            _Clear(' ');
            CSize = get;
            Redraw();
            OnChangeSize?.Invoke(get);
        }

        public string Text { get => CText; set => SetText(value); }
        public void SetText(string get)
        {
            _Clear(' ');
            CText = get;
            Redraw();
            OnChangeText?.Invoke(get);
        }

        public ConsoleColor BackgroundColor { get => CBackgroundColor; set => SetBackgroundColor(value); }
        public void SetBackgroundColor(ConsoleColor get)
        {
            _Clear(' ');
            CBackgroundColor = get;
            Redraw();
            OnChangeBackgroundColor?.Invoke(get);
        }

        public ConsoleColor BordersTextColor { get => CBordersTextColor; set => SetBordersTextColor(value); }
        public void SetBordersTextColor(ConsoleColor get)
        {
            _Clear(' ');
            CBordersTextColor = get;
            Redraw();
            OnChangeBordersTextColor?.Invoke(get);
        }

        public bool ShowBorders { get => CShowBorders; set => SetShowBorders(value); }
        public void SetShowBorders(bool get)
        {
            CShowBorders = get;
            _Redraw(" ");
        }

        public bool TextCentered { get => CTextCentered; set => SetTextCentered(value); }
        public void SetTextCentered(bool get)
        {
            CTextCentered = get;
            _Redraw(" ");
        }

        public Border Border { get => CBorder; set => SetBorder(value); }
        public void SetBorder(Border get)
        {
            CBorder = get;
            _Redraw(" ");
        }

        public Rect Padding { get => CPadding; set => SetPadding(value); }
        public void SetPadding(Rect get)
        {
            CPadding = get;
            _Redraw(" ");
        }
        #endregion

        #region ---      Events       ---
        public delegate void OnChangeLocationEventHandler(Point location);
        public event OnChangeLocationEventHandler OnChangeLocation;

        public delegate void OnChangeSizeEventHandler(Size size);
        public event OnChangeSizeEventHandler OnChangeSize;

        public delegate void OnChangeTextEventHandler(string text);
        public event OnChangeTextEventHandler OnChangeText;

        public delegate void OnChangeBackgroundColorEventHandler(ConsoleColor backgroundColor);
        public event OnChangeBackgroundColorEventHandler OnChangeBackgroundColor;

        public delegate void OnChangeBordersTextColorEventHandler(ConsoleColor bordersTextColor);
        public event OnChangeBordersTextColorEventHandler OnChangeBordersTextColor;

        public delegate void MouseDownEventHandler(int x, int y, MButton mButton);
        public event MouseDownEventHandler MouseDown;

        public delegate void MouseUpEventHandler(int x, int y, MButton mButton);
        public event MouseUpEventHandler MouseUp;

        public delegate void MouseMoveEventHandler(int x, int y, MButton mButton);
        public event MouseMoveEventHandler MouseMove;

        public delegate void OnRedrawEventHandler();
        public event OnRedrawEventHandler OnRedraw;
        #endregion
    }
}
