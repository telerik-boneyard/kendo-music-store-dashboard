namespace Tablet.MvcMusicStore.Models
{
    public static class ModelHelper
    {
        /// <summary>
        /// Trims the strings so it fits the tab...
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string TrimName(this string input)
        {
            if (!string.IsNullOrWhiteSpace(input) && input.Length > 30)
            {
                return string.Format("{0}...", input.Substring(0, 30));
            }
            return input;
        }
    }
}