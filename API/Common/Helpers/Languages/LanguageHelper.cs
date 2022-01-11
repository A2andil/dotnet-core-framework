namespace Common.Helpers.Languages
{
    public class LanguageHelper
    {
        public static string GetCurrentLanguage
        {
            get { return System.Globalization.CultureInfo.CurrentCulture.ToString().Split('-')[0]; }
        }
    }
}
