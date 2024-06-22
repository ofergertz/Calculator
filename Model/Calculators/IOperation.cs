using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Calculators
{
    public interface IOperation
    {
        bool ShouldEvaluate(string operation);
        double Evaluate(double leftNumber, double rightNumber);
    }
}
