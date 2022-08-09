namespace Pluralize
{
	public static class PluralizeTask
	{
		public static string PluralizeRubles(int count)
		{
			if ((count > 10 && count < 20) || (count % 100 > 10 && count % 100 < 20) )  return "рублей";
			var temp = count % 10;
			if (temp == 1) return "рубль";
			if (temp > 1 && temp < 5) return "рубля";
			return "рублей";
		}
	}
}