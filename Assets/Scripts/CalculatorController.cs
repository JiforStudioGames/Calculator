using UnityEngine;

public class CalculatorController : MonoBehaviour
{
    private void Start()
    {
        ICalculatorView view = GetComponent<ICalculatorView>();
        CalculatorModel model = new CalculatorModel();
        new CalculatorPresenter(view, model);
    }
}