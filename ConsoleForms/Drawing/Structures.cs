using System;

namespace PinkConsoleForms.PinkDrawing
{
    /// <summary>
    /// <para>Представляет границу, а также задает константы, которые определяют типы линий границы.</para>
    /// <para>Represents a border and also sets constants that define the line types of the border.</para>
    /// </summary>
    public class Border
    {
        public Border(char LeftTop, char RightTop, char LeftBottom, char RightBottom, char Vartical, char Horizontal, char Fill)
        {
            this.LeftTop = LeftTop;
            this.RightTop = RightTop;
            this.LeftBottom = LeftBottom;
            this.RightBottom = RightBottom;
            this.Vartical = Vartical;
            this.Horizontal = Horizontal;
            this.Fill = Fill;
        }

        public readonly char LeftTop, RightTop, LeftBottom, RightBottom, Vartical, Horizontal, Fill;

        public static Border SingleLine = new Border('┌', '┐', '└', '┘', '─', '│', char.MinValue);
        public static Border DoubleLine = new Border('╔', '╗', '╚', '╝', '═', '║', char.MinValue);
        public static Border VerticalDoubleLine = new Border('╓', '╖', '╙', '╜', '─', '║', char.MinValue);
        public static Border HorizontalDoubleLine = new Border('╒', '╕', '╘', '╛', '═', '│', char.MinValue);
        public static Border BoldLine = new Border('█', '█', '█', '█', '█', '█', char.MinValue);
    }
}
