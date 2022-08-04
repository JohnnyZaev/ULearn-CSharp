using System;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace RefactorMe
{
    internal static class Drawer
    {
        private static float _x, _y;
        private static Graphics _graphics;

        public static void Initialize ( Graphics newGraphics )
        {
            _graphics = newGraphics;
            _graphics.SmoothingMode = SmoothingMode.None;
            _graphics.Clear(Color.Black);
        }

        public static void SetPosition(float x0, float y0)
        {_x = x0; _y = y0;}

        public static void DrawLineAtAngle(Pen pen, double length, double angle)
        {
            //Делает шаг длиной dlina в направлении ugol и рисует пройденную траекторию
            var x1 = (float)(_x + length * Math.Cos(angle));
            var y1 = (float)(_y + length * Math.Sin(angle));
            _graphics.DrawLine(pen, _x, _y, x1, y1);
            _x = x1;
            _y = y1;
        }

        public static void Change(double length, double angle)
        {
            _x = (float)(_x + length * Math.Cos(angle)); 
            _y = (float)(_y + length * Math.Sin(angle));
        }

        public static void DrawSide(int sz, double angle)
        {
            Drawer.DrawLineAtAngle(Pens.Yellow, sz * 0.375f, angle);
            Drawer.DrawLineAtAngle(Pens.Yellow, sz * 0.04f * Math.Sqrt(2), angle + Math.PI / 4);
            Drawer.DrawLineAtAngle(Pens.Yellow, sz * 0.375f, angle + Math.PI);
            Drawer.DrawLineAtAngle(Pens.Yellow, sz * 0.375f - sz * 0.04f, angle + Math.PI / 2);
        }
    }

    public static class ImpossibleSquare
    {
        public static void Draw(int wight, int height, double angleToRotate, Graphics graphics)
        {
            // angleToRotate пока не используется, но будет использоваться в будущем
            Drawer.Initialize(graphics);

            var sz = Math.Min(wight, height);

            var diagonalLength = Math.Sqrt(2) * (sz * 0.375f + sz * 0.04f) / 2;
            var x0 = (float)(diagonalLength * Math.Cos(Math.PI / 4 + Math.PI)) + wight / 2f;
            var y0 = (float)(diagonalLength * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f;

            Drawer.SetPosition(x0, y0);

            //Рисуем 1-ую сторону
            Drawer.DrawSide(sz, 0);

            Drawer.Change(sz * 0.04f, -Math.PI);
            Drawer.Change(sz * 0.04f * Math.Sqrt(2), 3 * Math.PI / 4);

            //Рисуем 2-ую сторону
            Drawer.DrawSide(sz, -Math.PI / 2);

            Drawer.Change(sz * 0.04f, -Math.PI / 2 - Math.PI);
            Drawer.Change(sz * 0.04f * Math.Sqrt(2), -Math.PI / 2 + 3 * Math.PI / 4);

            //Рисуем 3-ю сторону
            Drawer.DrawSide(sz, Math.PI);

            Drawer.Change(sz * 0.04f, Math.PI - Math.PI);
            Drawer.Change(sz * 0.04f * Math.Sqrt(2), Math.PI + 3 * Math.PI / 4);

            //Рисуем 4-ую сторону
            Drawer.DrawSide(sz, Math.PI / 2);

            Drawer.Change(sz * 0.04f, Math.PI / 2 - Math.PI);
            Drawer.Change(sz * 0.04f * Math.Sqrt(2), Math.PI / 2 + 3 * Math.PI / 4);
        }
    }
}