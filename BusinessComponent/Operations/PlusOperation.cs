using Model.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessComponent.Operations
{
    public class PlusOperation : IOperation
    {
        public double Evaluate(double leftNumber, double rightNumber)
        {
            return leftNumber + rightNumber;
        }

        public bool ShouldEvaluate(string operation)
        {
            return operation == "+";
        }
    }
}
