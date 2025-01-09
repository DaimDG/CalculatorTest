using UnityEngine;

namespace Calculator
{
    public class CalculatorHistory
    {
        public void SaveData(CalculatorData dataType, string data)
        {
            PlayerPrefs.SetString(dataType.ToString(), data);
        }

        public string LoadData(CalculatorData dataType)
        {
            return PlayerPrefs.GetString(dataType.ToString());
        }
    }
}