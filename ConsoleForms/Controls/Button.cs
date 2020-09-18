using System;
using System.Threading;
using PinkConsoleForms.PinkDrawing;

namespace PinkConsoleForms.Controls
{
    public class Button : Control, IButton
    {
        public Button(ConsoleForms owner) : base(owner)
        {
            CTextCentered = true;
            CShowBorders = true;
            CBordersTextColor = ConsoleColor.Gray;
            CState = " ";
        }

        public Button(ScrollViewer owner) : base(owner)
        {
            CTextCentered = true;
            CShowBorders = true;
            CBordersTextColor = ConsoleColor.Gray;
            CState = " ";
        }

        #region ---      Private      ---
        protected ConsoleColor CPressedBackgroundColor = (ConsoleColor)(-1);
        protected ConsoleColor CPressedBordersTextColor = ConsoleColor.DarkGray;
        #endregion

        #region ---    Properties     ---
        public ConsoleColor PressedBackgroundColor { get => (CPressedBackgroundColor == (ConsoleColor)(-1) ? CBackgroundColor : CPressedBackgroundColor); set => SetPressedBackgroundColor(value); }
        public void SetPressedBackgroundColor(ConsoleColor get)
        {
            CPressedBackgroundColor = get;
            OnChangePressedBackgroundColor?.Invoke(get);
        }

        public ConsoleColor PressedBordersTextColor { get => (CPressedBordersTextColor == (ConsoleColor)(-1) ? CBordersTextColor : CPressedBordersTextColor); set => SetPressedBordersTextColor(value); }
        public void SetPressedBordersTextColor(ConsoleColor get)
        {
            CPressedBordersTextColor = get;
            OnChangePressedBordersTextColor?.Invoke(get);
        }
        #endregion

        #region ---     Override      ---
        protected override void Move(int x, int y, int xglobal, int yglobal, MButton mb)
        {
            if (PointOnControl(x, y) && CState == " ")
                _Redraw("-");
            else if (!PointOnControl(x, y) && CState == "-")
                _Redraw(" ");

            base.Move(x, y, xglobal, yglobal, mb);
        }

        protected override void Down(int x, int y, int xglobal, int yglobal, bool inwindow, MButton mb)
        {
            if (PointOnControl(x, y) && inwindow)
                _Redraw("-", PressedBackgroundColor, PressedBordersTextColor);

            base.Down(x, y, xglobal, yglobal, inwindow, mb);
        }

        protected override void Up(int x, int y, int xglobal, int yglobal, bool inwindow, MButton mb)
        {
            if (PointOnControl(x, y) && inwindow)
                _Redraw("-");

            base.Up(x, y, xglobal, yglobal, inwindow, mb);
        }
        #endregion

        #region ---      Events       ---
        public delegate void OnChangePressedBordersTextColorEventHandler(ConsoleColor color);
        public event OnChangePressedBordersTextColorEventHandler OnChangePressedBordersTextColor;

        public delegate void OnChangePressedBackgroundColorEventHandler(ConsoleColor color);
        public event OnChangePressedBackgroundColorEventHandler OnChangePressedBackgroundColor;
        #endregion
    }
}
