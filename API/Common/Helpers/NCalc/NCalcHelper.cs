using Common.Enums;
using NCalc;

namespace Common.Helpers.NCalc
{
    public static class NCalcHelper
    {
        public static string CalculateEquation(string equation)
        {
            try
            {
                Expression expression = new Expression(equation);
                expression.EvaluateFunction += delegate (string name, FunctionArgs args)
                {
                    switch (name)
                    {
                        case nameof(NCalcFunctions.Sum):
                            args.Result = Sum(args.Parameters);
                            break;
                    }
                };
                return expression.Evaluate().ToString();
            }
            catch
            {
                return "Failed to calculate";
            }
        }

        public static int Sum(Expression[] parameters)
        {
            int summation = 0;
            for (int i = 0; i < parameters.Length; i++)
                summation += int.Parse(parameters[i].Evaluate().ToString());
            return summation;
        }
    }
}
