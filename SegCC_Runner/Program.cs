using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegCC_Runner {

    internal class Program {

        static void Main(string[] args) {
            SegCC_cs.Day_1 mDay_1_cs = new SegCC_cs.Day_1();
            Console.WriteLine(mDay_1_cs.Result(true));
            SegCC_vb.Day_1 mDay_1_vb = new SegCC_vb.Day_1();
            Console.WriteLine(mDay_1_vb.Result(true));
        }
    }
}
