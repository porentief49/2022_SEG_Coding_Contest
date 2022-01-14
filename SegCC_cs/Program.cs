using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_cs {

    internal class Program {

        static void Main(string[] args) {
            Day_1 mDay1 = new Day_1() { InputFile = "abc" };
            Console.WriteLine(mDay1.Result(true));
        }
    }
}
