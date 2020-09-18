using System;
using System.Collections.Generic;
using PinkConsoleForms.Controls;

namespace PinkConsoleForms.PinkDrawing
{
    public class Drawing : IDrawing
    {
        public Drawing (ConsoleForms owner)
        {
            Owner = owner;
        }

        public ConsoleForms Owner;

        private void Write(dynamic obj, Control sender = null)
        {
            if (sender == null)
                Console.Write(obj);
            else
                sender.Write(obj);
        }

        private void GoToXY(int x, int y, Control sender = null)
        {
            if (sender == null)
                Console.SetCursorPosition(x, y);
            else
                sender.GoToXY(x, y);
        }


        public void DrawBorder(Rect rect, Border border, Control sender = null)
        {
            for (var y = rect.Top; y <= rect.Height + rect.Top - 1; y++)
            {
                for (var x = rect.Left; x <= rect.Width + rect.Left - 1; x++)
                {
                    GoToXY(x, y, sender);
                    if (y == rect.Top)
                        if (x == rect.Left)
                            Write(border.LeftTop, sender);
                        else if (x == rect.Width + rect.Left - 1)
                            Write(border.RightTop, sender);
                        else
                            Write(border.Vartical, sender);
                    else if (y == rect.Top + rect.Height - 1)
                        if (x == rect.Left)
                            Write(border.LeftBottom, sender);
                        else if (x == rect.Width + rect.Left - 1)
                            Write(border.RightBottom, sender);
                        else
                            Write(border.Vartical, sender);
                    else
                        if (x == rect.Left || x == rect.Width + rect.Left - 1)
                            Write(border.Horizontal, sender);
                }
            }
        }

        public void DrawText(Rect rect, string text, Rect padding, bool textcentered, string state = null, Control sender = null)
        {
            //делит text на words
            var words = new List<string>(text.Replace("\n", "\n ").Replace("\t", "    ").Split(' '));
            //сохраняем оригинальный прямоугольник
            var original = rect;

            rect = new Rect(
                rect.Left + padding.Left + (!string.IsNullOrEmpty(state) ? 1 : 0),
                rect.Top + padding.Top,
                rect.Right - padding.Right - (!string.IsNullOrEmpty(state) ? 1 : 0),
                rect.Bottom - padding.Bottom);

            //делит большие word
            for (var i = 0; i < words.Count; i++)
            {
                if (words[i].Length > rect.Width)
                {
                    var word = words[i];
                    words.RemoveAt(i);
                    words.InsertRange(i, word.Split(rect.Width));
                }
            }

            var n = 0;
            var line = 0;

            //перебор слов пока хватает линий и слов
            do
            {
                var wordsline = "";

                //составляет строку учитывая длину слов
                while (n < words.Count && wordsline.Length + words[n].Length <= rect.Width && !wordsline.Contains("\n"))
                {
                    wordsline += words[n] + " ";
                    n += 1;
                }

                if (wordsline.Length != 0)
                {
                    //удаляет последний пробел и 
                    wordsline = wordsline
                        .Substring(0, wordsline.Length - 1)
                        .Replace("\n", "")
                        .Replace("\r", "");

                    //добавляет пробелы в начало, если cтрока меньше ширины и необходимо центрировать текст
                    if (wordsline.Length < rect.Width && textcentered)
                    {
                        var halfempty = new string(' ', (int)((rect.Width - wordsline.Length) / 2));
                        wordsline = halfempty + wordsline;
                    }

                    GoToXY(rect.Left, rect.Top + line, sender);
                    Write(wordsline, sender);
                }

                line += 1;
            } while (n < words.Count && line < rect.Height);

            //рисуем состояние
            if (!string.IsNullOrEmpty(state))
            {
                for (var y = 1; y < original.Height - 1; y++)
                {
                    GoToXY(original.Left + 1, original.Top + y, sender);
                    Write(state, sender);
                    GoToXY(original.Right - 1 - 1, original.Top + y, sender);
                    Write(state, sender);
                }
            }
        }

        public void FillRectangle(Rect rect, char ch)
        {
            for (var y = rect.Top; y <= rect.Height + rect.Top - 1; y++)
            {
                for (var x = rect.Left; x <= rect.Width + rect.Left - 1; x++)
                {
                    Owner.GoToXY(x, y);
                    Console.Write(ch);
                }
            }
        }

        public void FillEllipse(Rect rect, char ch)
        {
            for (var w = 0; w <= rect.Width; w+=2)
                for (var a = 0; a <= 360; a++)
                {
                    var w2 = (w / 2);
                    var w3 = (rect.Left - w2 + rect.Width / 2);
                    GoToXY(Convert.ToInt32(System.Math.Cos(Math.DegToRad(a)) * w2) + w3 + w2, Convert.ToInt32(System.Math.Sin(Math.DegToRad(a)) * (rect.Height / 2)) + rect.Top + (rect.Height / 2));
                    Write(ch);
                }
        }


        public void DrawEllipse(Rect rect, char ch)
        {
            for (var a = 0; a <= 360; a++)
            {
                GoToXY(Convert.ToInt32(System.Math.Cos(Math.DegToRad(a)) * (rect.Width / 2)) + rect.Left + (rect.Width / 2), Convert.ToInt32(System.Math.Sin(Math.DegToRad(a)) * (rect.Height / 2)) + rect.Top + (rect.Height / 2));
                Write(ch);
            }
        }
    }

    static class StringExtensions
    {
        public static IEnumerable<string> Split(this string s, int chunkSize)
        {
            int chunkCount = s.Length / chunkSize;
            for (int i = 0; i < chunkCount; i++)
                yield return s.Substring(i * chunkSize, chunkSize);

            if (chunkSize * chunkCount < s.Length)
                yield return s.Substring(chunkSize * chunkCount);
        }
    }
}
