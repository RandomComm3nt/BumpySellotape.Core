namespace BumpySellotape.Core.Utilities
{
    public static class StringExtensions
    {
        public static string GetSubstringBeforeMatch(this string input, string match)
        {
            var i = input.IndexOf(match);
                return i >= 0
                    ? input.Substring(0, i)
                    : input[..];
        }
    }
}
