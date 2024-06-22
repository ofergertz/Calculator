using Model.Calculators;
using System.Text.RegularExpressions;
using Expression = org.matheval.Expression;
namespace BusinessComponent.Calculators
{
    public class CalculatorProcessor : ICalculatorProcessor
    {
        public void ProcessInput(string input, ICalculatorState state, ICalculator calculator)
        {
            if (state.CalculationComplete)
            {
                // Handle specific cases for input after calculation (similar to existing code)
            }

            switch (input)
            {
                case string s when IsDigitOrDot(s):
                    ProcessDigitOrDot(s, state, calculator);
                    break;
                case string s when IsOperator(s):
                    ProcessOperator(s, state, calculator);
                    break;
                case "=":
                    ProcessEquals(state, calculator);
                    break;
                default:
                    // Handle any unexpected input if needed with log or throwing new expection.
                    break;
            }
        }

        private void CalculateResult(ICalculator calculator, ICalculatorState state)
        {
            try
            {
                var result = EvaluateExpression(calculator.FullExpression);
                calculator.Display = result.ToString();

                // Reset state for new calculation
                state.CurrentInput = result.ToString();
                state.IsNewInput = true;
            }
            catch
            {
                calculator.Display = "Error";
            }
        }

        private bool IsDigitOrDot(string input)
        {
            return Regex.IsMatch(input, @"\d|\.");
        }

        private bool IsOperator(string input)
        {
            return Regex.IsMatch(input, @"[\+\-\*/]");
        }

        private void ProcessDigitOrDot(string input, ICalculatorState state, ICalculator calculator)
        {
            if (state.IsNewInput)
            {
                state.CurrentInput = input;
                state.IsNewInput = false;
            }
            else
            {
                state.CurrentInput += input;
            }

            calculator.Display = state.CurrentInput;
            if (!state.CalculationComplete)
                calculator.FullExpression += input;
            else
                calculator.FullExpression = input;
        }

        private void ProcessOperator(string input, ICalculatorState state, ICalculator calculator)
        {
            if (string.IsNullOrEmpty(calculator.FullExpression)) return;

            state.CurrentInput = string.Empty; // Clear current input for the new operation

            state.IsNewInput = true;
            state.CalculationComplete = false; // Reset calculation complete flag if operator is pressed
            if (!LastOperationWasOperator(calculator))
            {
                calculator.FullExpression = EvaluateExpression(calculator.FullExpression).ToString();
                calculator.FullExpression += input;
                calculator.Display = input;
            }
                
        }

        private bool LastOperationWasOperator(ICalculator calculator)
        {
            return IsOperator(calculator.FullExpression.Last().ToString());
        }

        private void ProcessEquals(ICalculatorState state, ICalculator calculator)
        {
            if (state.CalculationComplete) return; // Prevent processing "=" multiple times

            calculator.FullExpression += "="; 
            CalculateResult(calculator, state);
            state.CalculationComplete = true; 
        }

        private double EvaluateExpression(string expression)
        {
            // Remove trailing '=' for evaluation
            expression = expression.TrimEnd('=');

            var exp = new Expression(expression);
            var result = exp.Eval();
            // Evaluate using DataTable to respect order of operations
            //var dataTable = new System.Data.DataTable();
            //var result = dataTable.Compute(expression, string.Empty);
            return Convert.ToDouble(result);
        }
    }
}
