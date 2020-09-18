using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkConsoleForms
{
    public class Math
    {
        /// <summary>
        /// Получает длину линии проведенной из точки p1 в точку p2
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static int GetLength(Point p1, Point p2)
        {
            var p3 = new Point(p2.X, p1.Y);
            var x = p1.X - p3.X;
            var y = p2.Y - p3.Y;
            return Convert.ToInt32(System.Math.Sqrt(x * x + y * y));
        }

        /// <summary>
        /// Получает угол по двум линия p1, p2 проведенным из точку center
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="center"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static int GetAngle(Point p1, Point center, Point p2)
        {
            p1.X -= center.X; p1.Y -= center.Y;
            p2.X -= center.X; p2.Y -= center.Y;
            var cos = System.Math.Round((p1.X * p2.X + p1.Y * p2.Y) / (System.Math.Sqrt(p1.X * p1.X + p1.Y * p1.Y) * System.Math.Sqrt(p2.X * p2.X + p2.Y * p2.Y)), 9);
            try { return Convert.ToInt32(System.Math.Acos(cos) * 180 / System.Math.PI); }
            catch { return 0; }
        }

        /// <summary>
        /// Представляет угол в градусах, как угол в радианах
        /// </summary>
        /// <param name="deg"></param>
        /// <returns></returns>
        public static double DegToRad(int deg) => System.Math.PI * deg / 180;

        /// <summary>
        /// Проверяет, находится ли значение val в диапазоне значений от min до max включительно
        /// </summary>
        /// <param name="val"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static bool IntInRange(int val, int min, int max)
        {
            for (var i = min; i <= max; i++)
                if (val == i)
                    return true;
            return false;
        }
    }
}
