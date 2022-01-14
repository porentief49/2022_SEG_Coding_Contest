using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_Template
{
    public abstract class Day_base {

        public string InputFile { get; set; } = String.Empty;
        public bool ConsoleOutputs { get; set; } = false;

        public abstract string Result(bool aPartA);

    }
}
