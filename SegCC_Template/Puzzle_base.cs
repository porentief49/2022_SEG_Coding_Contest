using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegCC_Template
{

    public enum ePart { One, Two}

    public abstract class Puzzle_base {

        public string Result { get; protected set; } = string.Empty;

        public string InputFile { get; set; } = string.Empty;
        public bool EnableConsoleOutputs { get; set; } = false;

        public abstract void Process(ePart aPart);

    }
}
