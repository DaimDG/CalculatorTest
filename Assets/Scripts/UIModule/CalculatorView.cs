using Calculator;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule
{
    public class CalculatorView : MonoBehaviour, IView
    {
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private TMP_Text historyText;
        [SerializeField] private Button calculateButton;
        [SerializeField] private GameObject errorPopup;
        [SerializeField] private Button closeErrorPopupButton;

        private CalculatorPresenter _presenter;

        private void Start()
        {
            _presenter = new CalculatorPresenter(this);

            calculateButton.onClick.AddListener(() => _presenter.OnExpressionEntered(inputField.text));
            closeErrorPopupButton.onClick.AddListener(HideErrorMessage);

            //Restore state
            _presenter.RestoreState();
        }

        public void DisplayResult(string result)
        {
            historyText.text = $"{inputField.text} = {result}\n" + historyText.text;
        }

        //Open error popup
        public void ShowErrorMessage()
        {
            errorPopup.SetActive(true);
        }

        //Close error popup
        public void HideErrorMessage()
        {
            errorPopup.SetActive(false);
        }

        public void SetInput(string expression)
        {
            inputField.text = expression;
        }

        public void SetHistory(string history)
        {
            historyText.text = history;
        }

        //Save all data on app closing
        private void OnApplicationQuit()
        {
            _presenter.SaveExpression(inputField.text);
            _presenter.SaveHistory(historyText.text);
        }
    }
}