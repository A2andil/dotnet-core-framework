namespace Common.Enums
{
    public enum CultureCode
    {
        ar,
        en
    }

    public static class CultureCodeExtensions
    {
        public static string AsString(this CultureCode cultureCode)
        {
            switch (cultureCode)
            {
                case CultureCode.ar: return "ar";
                case CultureCode.en: return "en";
            }
            return "en";
        }
    }
}
