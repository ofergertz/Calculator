﻿using Model.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services
{
    public interface ICalculatorService
    {
        void Clear();

        void ProcessInput(string input);

        ICalculator Calculator { get; }
    }
}
