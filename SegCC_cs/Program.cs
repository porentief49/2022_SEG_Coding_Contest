using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SegCC_Template;

namespace SegCC_cs {

    internal static class Program {

        const string INPUT_FOLDER_RELATIVE_TO_ASSEMBLY = @"..\..\..\input\";

        static void Main() {
            const string INPUT_FILE = "input_00.txt";
            var mPuzzle = new Puzzle_00() { InputFile = INPUT_FOLDER_RELATIVE_TO_ASSEMBLY + INPUT_FILE };
            //Console.WriteLine($"Final Result for part 1: {mPuzzle.Result(ePart.One)}");
            //Console.WriteLine($"Final Result for part 2: {mPuzzle.Result(ePart.Two)}");
        }
    }
}
