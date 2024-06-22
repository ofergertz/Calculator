using Model.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessComponent.Operations
{
    public class DefaultOperation : IOperation
    {
        public double Evaluate(double leftNumber, double rightNumber)
        {
            throw new NotImplementedException();
        }

        public bool ShouldEvaluate(string operation)
        {
            return operation != "+" && operation != "-" && operation != "*" && operation != "/";
        }
    }
}
