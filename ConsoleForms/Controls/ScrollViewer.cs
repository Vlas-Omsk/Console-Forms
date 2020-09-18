using System;
using System.Threading;
using PinkConsoleForms.PinkDrawing;

namespace PinkConsoleForms.Controls
{
    public class ScrollViewer : Control, IScrollViewer
    {
        public ScrollViewer(ConsoleForms owner) : base(owner)
        {
            CShowBorders = true;
            CText = "";
        }

        #region ---      Public       ---
        public bool LockVerticalScrolling = false;
        public bool LockHorizontalScrolling = false;


        public new void GoToXY(int x, int y)
        {
            if ((y + CVerticalScrollOffset > 0 + CPadding.Top && y + CVerticalScrollOffset < CSize.Height - 1 - CPadding.Bottom) &&
                (x + CHorizontalScrollOffset > 0 + CPadding.Left && x + CHorizontalScrollOffset < CSize.Width - 1 - CPadding.Right))
                Owner.GoToXY(x + CLocation.X + CHorizontalScrollOffset, y + CLocation.Y + CVerticalScrollOffset);
            else
                Owner.GoToXY(0, 0);
        }

        public new void Write(dynamic obj)
        {
            if ((Console.CursorTop > CLocation.Y && Console.CursorTop < CLocation.Y + CSize.Height) &&
                (Console.CursorLeft > CLocation.X && Console.CursorLeft < CLocation.X + CSize.Width))
                Console.Write(obj);
        }

        public new void WriteLine(dynamic obj)
        {
            //if (Console.CursorTop >= CLocation.Y - CVerticalScrollOffset)
                Console.WriteLine(obj);
        }
        #endregion

        #region ---      Private      ---
        protected int CVerticalScrollOffset = 0;
        protected int CHorizontalScrollOffset = 0;
        #endregion

        #region ---    Properties     ---
        public int VerticalScrollOffset { get => CVerticalScrollOffset; set => SetVerticalScrollOffset(value); }
        public void SetVerticalScrollOffset(int get)
        {
            if (LockVerticalScrolling)
                return;

            CVerticalScrollOffset = get;
            Redraw();
            OnChangeVerticalScrollOffset?.Invoke(get);
        }

        public int HorizontalScrollOffset { get => CHorizontalScrollOffset; set => SetHorizontalScrollOffset(value); }
        public void SetHorizontalScrollOffset(int get)
        {
            if (LockHorizontalScrolling)
                return;

            CHorizontalScrollOffset = get;
            Redraw();
            OnChangeHorizontalScrollOffset?.Invoke(get);
        }
        #endregion

        #region ---      Events       ---
        public delegate void OnChangeVerticalScrollOffsetEventHandler(int value);
        public event OnChangeVerticalScrollOffsetEventHandler OnChangeVerticalScrollOffset;

        public delegate void OnChangeHorizontalScrollOffsetEventHandler(int value);
        public event OnChangeHorizontalScrollOffsetEventHandler OnChangeHorizontalScrollOffset;
        #endregion
    }
}
