using Model.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessComponent.Calculators
{
    public class CalculatorState : ICalculatorState
    {
        public string CurrentInput { get; set; } = string.Empty;
        public bool IsNewInput { get; set; } = true;// Flag to indicate if we are entering a new input after an operator
        public bool CalculationComplete { get; set; } = false;// Flag to track if the last operation was a calculation

        public void Clear()
        {
            CurrentInput = string.Empty;
            IsNewInput = true;
            CalculationComplete = false;
        }
    }
}
