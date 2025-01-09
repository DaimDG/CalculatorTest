using System.Globalization;
using UnityEngine;

namespace Calculator
{
    public class CalculatorProcessor
    {
        public CalculatorModel EvaluateExpression(string expression)
        {
            var parts = expression.Split('+');
            bool isExpressionValid = IsValidExpression(parts);
            
            string sum;
            if (!isExpressionValid) sum = "Error";
            else
            {
                int first = int.Parse(parts[0]);
                int second = int.Parse(parts[1]);
                sum = (first + second).ToString();
            }
            return new CalculatorModel(expression, sum, isExpressionValid);
        }

        private bool IsValidExpression(string[] parts)
        {
            if (parts.Length != 2) return false;
            
            //Check parts for >= 0
            return uint.TryParse(parts[0], out _) && uint.TryParse(parts[1], out _);
        }
    }
}