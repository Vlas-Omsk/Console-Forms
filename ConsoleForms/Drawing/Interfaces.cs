using System;
using System.Collections.Generic;
using PinkConsoleForms.Controls;

namespace PinkConsoleForms.PinkDrawing
{
    public interface IDrawing
    {
        /// <summary>
        /// Рисует границу из точки rect.left, rect.top в точку rect.right, rect.bottom
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="border"></param>
        /// <param name="sender"></param>
        void DrawBorder(Rect rect, Border border, Control sender = null);

        /// <summary>
        /// Рисует текст в прямоугольнике из точки rect.left, rect.top в точку rect.right, rect.bottom
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="text"></param>
        /// <param name="padding">Внутренний отступ</param>
        /// <param name="textcentered">Устанавливает, нужно ли выровнять текст по центру</param>
        /// <param name="state">Если не ровно null, отображает этот символ горизонтально с краев</param>
        /// <param name="sender"></param>
        void DrawText(Rect rect, string text, Rect padding, bool textcentered, string state = null, Control sender = null);

        /// <summary>
        /// Рисует закрашеный прямоугольник символом ch
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="ch">Fill char</param>
        void FillRectangle(Rect rect, char ch);
    }
}
