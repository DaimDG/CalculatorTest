namespace Calculator
{
    public interface IView
    {
        void DisplayResult(string result);
        void ShowErrorMessage();
        void HideErrorMessage();
        void SetInput(string expression);
        void SetHistory(string history);
    }
}