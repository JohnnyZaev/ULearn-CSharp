using System;

namespace DistanceTask
{
	public static class DistanceTask
	{
		// Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
		public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
		{
			if ((x == ax && y == ay) || (x == bx && y == by))
				return 0;
			if (ax == bx && ay == by)
				return Math.Sqrt((x - ax) * (x - ax) + (y - ay) * (y - ay));
			var c = Math.Sqrt((ax - bx) * (ax - bx) + (ay - by) * (ay - by));
			var a = Math.Sqrt((x - ax) * (x - ax) + (y - ay) * (y - ay));
			var b = Math.Sqrt((x - bx) * (x - bx) + (y - by) * (y - by));

			if (a * a > b * b + c * c || b * b > a * a + c * c)
				return Math.Min(a, b);
			var aa = by - ay;
			var bb = ax - bx;
			var cc = -aa * ax - bb * ay;
			return Math.Abs((aa * x + bb * y + cc) / Math.Sqrt(aa * aa + bb * bb));
		}
	}
}