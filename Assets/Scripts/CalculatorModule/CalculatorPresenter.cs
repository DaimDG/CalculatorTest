namespace Calculator
{
    public class CalculatorPresenter
    {
        private readonly CalculatorProcessor _processor;
        private readonly CalculatorHistory _history;
        private readonly IView _view;

        public CalculatorPresenter(IView view)
        {
            _processor = new CalculatorProcessor();
            _history = new CalculatorHistory();
            _view = view;
        }

        public void OnExpressionEntered(string expression)
        {
            CalculatorModel result = _processor.EvaluateExpression(expression);

            if (!result.IsValid) _view.ShowErrorMessage();
            _view.DisplayResult(result.Result);
        }

        public void RestoreState()
        {
            _view.SetInput(LoadExpression());
            _view.SetHistory(LoadHistory());
        }

        public void SaveExpression(string data)
        {
            _history.SaveData(CalculatorData.Expression, data);
        }
        
        public void SaveHistory(string data)
        {
            _history.SaveData(CalculatorData.History, data);
        }
        
        public string LoadExpression()
        {
            return _history.LoadData(CalculatorData.Expression);
        }
        
        public string LoadHistory()
        {
            return _history.LoadData(CalculatorData.History);
        }
    }
}