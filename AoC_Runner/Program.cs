using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_Runner {

    internal class Program {

        static void Main(string[] args) {
            AoC_cs.Day_1 mDay_1_cs = new AoC_cs.Day_1();
            Console.WriteLine(mDay_1_cs.Result(true));
            AoC_vb.Day_1 mDay_1_vb = new AoC_vb.Day_1();
            Console.WriteLine(mDay_1_vb.Result(true));
        }
    }
}
