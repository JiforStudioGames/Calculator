using System;
using System.Collections.Generic;

public interface ICalculatorView
{
    string GetInput();
    void SetInput(string input);
    void SetHistory(List<string> history);
    void ShowMessage(string message);
    event Action OnCalculate;
}
