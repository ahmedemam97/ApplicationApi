
    public static class Extentions
    {
        public static decimal Round(this decimal num, int dec = 5)
        {
            return Math.Round(num, dec, MidpointRounding.AwayFromZero);
        }
        public static double Round(this double num)
        {
            return Math.Round(num, 5, MidpointRounding.AwayFromZero);
        }
        public static string ToMony(this decimal amount)
        {
          return Math.Round(amount, 5, MidpointRounding.AwayFromZero).ToString();
        }
}

