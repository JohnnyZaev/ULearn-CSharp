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

        private static void DrawLineAtAngle(Pen pen, double length, double angle)
        {
            var x1 = (float)(_x + length * Math.Cos(angle));
            var y1 = (float)(_y + length * Math.Sin(angle));
            _graphics.DrawLine(pen, _x, _y, x1, y1);
            _x = x1;
            _y = y1;
        }

        private static void Change(double length, double angle)
        {
            _x = (float)(_x + length * Math.Cos(angle)); 
            _y = (float)(_y + length * Math.Sin(angle));
        }

        public static void DrawSide(int sz, double angle)
        {
            DrawLineAtAngle(Pens.Yellow, sz * 0.375f, angle);
            DrawLineAtAngle(Pens.Yellow, sz * 0.04f * Math.Sqrt(2), angle + Math.PI / 4);
            DrawLineAtAngle(Pens.Yellow, sz * 0.375f, angle + Math.PI);
            DrawLineAtAngle(Pens.Yellow, sz * 0.375f - sz * 0.04f, angle + Math.PI / 2);
            
            Change(sz * 0.04f, angle - Math.PI);
            Change(sz * 0.04f * Math.Sqrt(2), angle + 3 * Math.PI / 4);
        }
    }

    public static class ImpossibleSquare
    {
        public static void Draw(int wight, int height, double angleToRotate, Graphics graphics)
        {
            Drawer.Initialize(graphics);

            var sz = Math.Min(wight, height);
            var diagonalLength = Math.Sqrt(2) * (sz * 0.375f + sz * 0.04f) / 2;
            var x0 = (float)(diagonalLength * Math.Cos(Math.PI / 4 + Math.PI)) + wight / 2f;
            var y0 = (float)(diagonalLength * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f;
            var angles = new[] { 0, -Math.PI / 2, Math.PI, Math.PI / 2};

            Drawer.SetPosition(x0, y0);

            foreach (var angle in angles)
            {
                Drawer.DrawSide(sz, angle);
            }
        }
    }
}