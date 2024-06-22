using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Calculators
{
    public interface ICalculatorProcessor
    {
        void ProcessInput(string input, ICalculatorState state, ICalculator calculator);
    }
}
