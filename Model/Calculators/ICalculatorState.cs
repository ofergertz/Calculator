using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Calculators
{
    public interface ICalculatorState
    {
        void Clear();
        string CurrentInput { get; set; }
        bool IsNewInput { get; set; }
        bool CalculationComplete { get; set; } 
    }
}
