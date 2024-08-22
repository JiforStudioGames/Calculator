using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class CalculatorModel
{
    public string LastInput { get; set; }
    public List<string> History { get; private set; }

    public CalculatorModel()
    {
        History = new List<string>();
        LoadState();
    }

    public string Calculate(string input)
    {
        LastInput = input;

        if (!IsValidInput(input))
        {
            History.Add($"{input} = !Error!");
            SaveState();
            return "Error";
        }

        var numbers = input.Split('+');
        int result = int.Parse(numbers[0]) + int.Parse(numbers[1]);

        LastInput = "";
        History.Add($"{input} = {result}");
        SaveState();
        return result.ToString();
    }

    private bool IsValidInput(string input)
    {
        return Regex.IsMatch(input.Trim(), @"^\d+\+\d+$");
    }

    private void SaveState()
    {
        PlayerPrefs.SetString("LastInput", LastInput);
        PlayerPrefs.SetString("History", string.Join(";", History));
    }

    private void LoadState()
    {
        LastInput = PlayerPrefs.GetString("LastInput", string.Empty);
        string historyString = PlayerPrefs.GetString("History", string.Empty);
        if (!string.IsNullOrEmpty(historyString))
        {
            History.AddRange(historyString.Split(';'));
        }
    }
}