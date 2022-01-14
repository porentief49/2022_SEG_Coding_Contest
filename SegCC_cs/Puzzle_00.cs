using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SegCC_Template;

namespace SegCC_cs {

    // Assume the following puzzle:
    //
    // Part 1:
    // Your sensors constantly measure the gamma ray intensity. To estimate the damage to your protection shields, you need to add all the
    // measurements taken. The total sum is your puzzle result for part 1.
    //
    // Part 2:
    // Your shields are actually exponentially impacted by the gamma ray intensity. To get the real damage, you need to multiply the
    // measurements with themselves before adding up. The total sum of the sqared numbers is your puzzle result for part 2.

    public class Puzzle_00 : SegCC_Template.Puzzle_base {

        public override void Process(ePart aPart) {
            string[] lLines = File.ReadAllLines(InputFile);
            if (aPart == ePart.One) Result = lLines.ToList().Select(x => long.Parse(x)).Sum().ToString();
            else Result = lLines.ToList().Select(x => Math.Pow(long.Parse(x), 2)).Sum().ToString();
        }
    }
}
