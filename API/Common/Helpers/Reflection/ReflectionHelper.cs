using System.Collections.Generic;
using System.Reflection;

namespace Common.Helpers.Reflection
{
    public static class ReflectionHelper
    {
        public static string GetTranslatedProperty<T>(T entity, string propertyName)
        {
            propertyName = string.Concat(propertyName.ToLower().Trim(), Languages.LanguageHelper.GetCurrentLanguage);
            List<PropertyInfo> propertiesInfo = new List<PropertyInfo>(entity.GetType().GetProperties());
            var property = propertiesInfo.Find(x => x.Name.ToLower() == propertyName);

            return property?.GetValue(entity, null).ToString();
        }
    }
}
