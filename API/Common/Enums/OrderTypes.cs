namespace Common.Enums
{
    public enum OrderTypes
    {
        Desc,
        Asc
    }

    public static class OrderTypesExtension
    {
        public static string AsString(this OrderTypes OrderTypes)
        {
            switch (OrderTypes)
            {
                case OrderTypes.Desc: return "Desc";
            }
            return "Asc"; //Default case is Asc
        }
    }
}
