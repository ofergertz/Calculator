using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Calculators
{
    public interface ICalculator
    {
        public string Display { get; set; }
        public string FullExpression { get; set; }
        public IEnumerable<string> Buttons
        {
            get;
        }
    }
}
