using System.Collections.Generic;
using UnityEngine;

public class CalculatorPresenter
{
    private readonly ICalculatorView _view;
    private readonly CalculatorModel _model;

    public CalculatorPresenter(ICalculatorView view, CalculatorModel model)
    {
        _view = view;
        _model = model;
        
        _view.SetInput(_model.LastInput);
        _view.SetHistory(_model.History);
        _view.OnCalculate += Calculate;
    }

    private void Calculate()
    {
        var input = _view.GetInput();
        var result = _model.Calculate(input);

        string historyEntry = $"{input} = {result}";
        
        _view.SetInput("");
        _view.SetHistory(_model.History);
    }
}