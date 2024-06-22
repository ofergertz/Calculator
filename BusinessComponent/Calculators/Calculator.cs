using Model.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessComponent.Calculators
{
    public class Calculator : ICalculator
    {
        public string Display { get;  set; } = "0";
        public string FullExpression { get;  set; } = string.Empty;
        public IEnumerable<string> Buttons => new[]
        {
             "7", "8", "9", "/",
             "4", "5", "6", "*",
             "1", "2", "3", "-",
             "0", ".", "=", "+"
         };
    }
}
