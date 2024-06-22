using Model.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessComponent.Operations
{
    public class DevideOperation : IOperation
    {
        public double Evaluate(double leftNumber, double rightNumber)
        {
            if (rightNumber == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed.");
            }
            return leftNumber / rightNumber;
        }

        public bool ShouldEvaluate(string operation)
        {
            return operation == "/";
        }
    }
}
