using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CalculatorViewCustom : MonoBehaviour, ICalculatorView
{
    [SerializeField] private TextMeshProUGUI inputField;
    [SerializeField] private TextMeshProUGUI historyText;
    
    [Space]
    [SerializeField] private ButtonView[] buttonAnswers;
    [SerializeField] private Button calculateButton;
    [SerializeField] private Button backspaceButton;
    [SerializeField] private Button plusButton;
    
    private string _currentInput = "";

    public event Action OnCalculate;

    public void Start()
    {
        calculateButton.onClick.AddListener(() => OnCalculate?.Invoke());

        InitButtons();
    }

    public string GetInput()
    {
        return inputField.text;
    }

    public void SetInput(string input)
    {
        _currentInput = input;
        inputField.text = input;
    }

    public void SetHistory(List<string> history)
    {
        historyText.text = string.Join("\n", history);
    }

    public void ShowMessage(string message)
    {
        historyText.text += "\n" + message;
    }
    
    private void InitButtons()
    {
        for (int i = 0; i < buttonAnswers.Length; i++)
        {
            buttonAnswers[i].textValue.text = i.ToString();
            buttonAnswers[i].button.onClick.RemoveAllListeners();
            var i1 = i;
            buttonAnswers[i].button.onClick.AddListener(() => AddSymbol(i1.ToString()));
        }

        backspaceButton.onClick.RemoveAllListeners();
        backspaceButton.onClick.AddListener(RemoveLastSymbol);
        
        plusButton.onClick.RemoveAllListeners();
        plusButton.onClick.AddListener(() => AddSymbol("+"));
    }
    
    private void AddSymbol(string symbol)
    {
        _currentInput += symbol;
        SetInput(_currentInput);
    }
    
    private void RemoveLastSymbol()
    {
        if (_currentInput.Length > 0)
        {
            _currentInput = _currentInput.Substring(0, _currentInput.Length - 1);
            inputField.text = _currentInput;
        }
    }
}