using Model.Calculators;
using Model.Services;
using System.Text.RegularExpressions;

namespace BusinessServices.Calculation;

public class CalculatorService : ICalculatorService
{
    private readonly ICalculator _calculator;
    private readonly ICalculatorProcessor _processor;
    private readonly ICalculatorState _state;

    public ICalculator Calculator { get { return _calculator; } }

    public CalculatorService(ICalculator calculator, ICalculatorProcessor processor, ICalculatorState state)
    {
        _calculator = calculator;
        _processor=processor;
        _state=state;
    }

    public void ProcessInput(string input)
    {
        _processor.ProcessInput(input, _state, _calculator);
        return; 
    }

    public void Clear()
    {
        _calculator.Display = "0";
        _calculator.FullExpression = string.Empty;
        _state.Clear();
        _state.Clear();
    }
}


