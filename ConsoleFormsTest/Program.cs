using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using PinkConsoleForms;
using PinkConsoleForms.Controls;
using PinkConsoleForms.PinkDrawing;
using PinkConsoleForms.PinkWinApi;
using System.Diagnostics;

namespace ConsoleFormsTest
{
    class Program
    {
        public static ConsoleForms consoleForms = new ConsoleForms();
        public static Drawing drawing = new Drawing(consoleForms);
        public static Button bt1 = new Button(consoleForms);

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            ConsoleForms.EnableConsoleBufferWriter = false;
            
            bt1.Size = new Size(20, 5);
            bt1.Location = new Point(consoleForms.ConsoleSize.Width / 2 - 10, consoleForms.ConsoleSize.Height / 2 - 2);
            bt1.Text = "Click Me!";
            bt1.MouseUp += Bt1_MouseUp;

            consoleForms.OnMouseMove += ConsoleForms_OnMouseMove;

            Console.ReadLine();
        }

        private static void Bt1_MouseUp(int x, int y, MButton mButton)
        {
            Thread.Sleep(30);
            bt1.Free();
            new Thread(() =>
            {
                int h = 0;
                while (true)
                {
                    Thread.Sleep(30);
                    h++;
                    if (h >= 360) h = 0;
                    consoleForms.SetBackgroundColorsRGB(consoleForms.HsvToRgb(h, 1, 1));
                    Console.WriteLine();
                }
            }).Start();
        }

        private static void ConsoleForms_OnMouseMove(int x, int y, int xglobal, int yglobal, MButton mButton)
        {
            Console.Title = x + " " + y;
        }
    }
}
