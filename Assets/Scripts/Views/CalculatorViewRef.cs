using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CalculatorViewRef : MonoBehaviour, ICalculatorView
{
    [SerializeField] private BackgroundImageScaler backgroundImageScaler;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshProUGUI historyText;
    [SerializeField] private Button calculateButton;

    public event Action OnCalculate;

    public void Start()
    {
        calculateButton.onClick.AddListener(() => OnCalculate?.Invoke());
    }

    public string GetInput()
    {
        return inputField.text;
    }

    public void SetInput(string input)
    {
        inputField.text = input;
    }

    public void SetHistory(List<string> history)
    {
        historyText.text = string.Join("\n", history);
        Invoke(nameof(UpdateVisual), 0.1f);
    }

    public void ShowMessage(string message)
    {
        historyText.text += "\n" + message;
        Invoke(nameof(UpdateVisual), 0.1f);
    }

    private void UpdateVisual()
    {
        backgroundImageScaler.RefreshBackgroundSize();
    }
}