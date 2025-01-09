namespace Calculator
{
    public class CalculatorModel
    {
        public string Expression { get; set; }
        public string Result { get; set; }
        public bool IsValid { get; set; }

        public CalculatorModel(string expression, string result, bool isValid)
        {
            Expression = expression;
            Result = result;
            IsValid = isValid;
        }
    }
}