namespace Common.Enums
{
    public enum Operators
    {
        GreaterThan,
        GreaterThanOrEqual,
        LessThan,
        LessThanOrEqual,
        Contain,
        NotContain,
        Equal,
        NotEqual
    }
    public static class OperatorsExtension
    {
        public static string AsString(this Operators operators)
        {
            switch (operators)
            {
                case Operators.GreaterThan: return ">";
                case Operators.GreaterThanOrEqual: return ">=";
                case Operators.LessThan: return "<";
                case Operators.LessThanOrEqual: return "<=";
                case Operators.NotContain: return "notlike";
                case Operators.Equal: return "==";
                case Operators.NotEqual: return "!=";
            }
            return "like"; //Default case is Contain
        }

        public static Operators ToOperator(this string operators)
        {
            switch (operators)
            {
                case "GreaterThan": return Operators.GreaterThan;
                case "GreaterThanOrEqual": return Operators.GreaterThanOrEqual;
                case "LessThan": return Operators.LessThan;
                case "LessThanOrEqual": return Operators.LessThanOrEqual;
                case "NotContain": return Operators.NotContain;
                case "Equal": return Operators.Equal;
                case "NotEqual": return Operators.NotEqual;
            }
            return Operators.Contain; //Default case is Contain
        }
    }
}
