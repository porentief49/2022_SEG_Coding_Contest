using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;
using SegCC_Template;
using System.IO;

namespace SegCC_Runner {

    internal class Program {
        const string INPUT_FOLDER_RELATIVE_TO_ASSEMBLY = @"..\..\..\input\";

        static string mInputFile;
        static int mCount = 0;
        static CancellationToken mToken;
        static List<long> mMemory = new List<long>();
        static Process mCurrentProcess;
        static string mResult;
        static double mExecTimeMs;
        static long mMemBytes;
        static string mSourceFile;

        static void Main() {

            mInputFile = INPUT_FOLDER_RELATIVE_TO_ASSEMBLY + "input_00_big.txt";
            mSourceFile = @"..\..\..\SegCC_cs\Puzzle_00.cs";

            // perform clean run, measure execution time
            var lWatch = Stopwatch.StartNew();
            var lPuzzle = new SegCC_cs.Puzzle_00() { InputFile = mInputFile };
            lPuzzle.Process(ePart.One);
            mResult = lPuzzle.Result;
            lWatch.Stop();
            mExecTimeMs = lWatch.Elapsed.TotalMilliseconds;
            Console.WriteLine($"Result:                 {mResult}");
            Console.WriteLine($"Exec Time:              {mExecTimeMs:0.000} ms");
            GC.Collect();

            // perform clean run, measure execution time
            mCurrentProcess = Process.GetCurrentProcess();
            CancellationTokenSource lTokenSource = new CancellationTokenSource();
            mToken = new CancellationTokenSource().Token;
            Task lLoopTask = Task.Run(Loop, mToken);
            lPuzzle = new SegCC_cs.Puzzle_00() { InputFile = mInputFile };
            lPuzzle.Process(ePart.One);
            mResult = lPuzzle.Result;
            lTokenSource.Cancel();
            //Console.WriteLine($"Loop Count:             {mCount}");
            mMemBytes = Math.Max(0, mMemory.Max() - mMemory[0]);
            Console.WriteLine($"Max Memory Consumed:    {mMemBytes} bytes ({mCount} samples)");
            Console.WriteLine($"Max Memory Consumed:    {((double)mMemBytes)/1024/1024:0.000} MBytes");

            // code metrics
            string[] lSource = File.ReadAllLines(mSourceFile);
            int lCodeLines = lSource.ToList().Where(x => x.Trim().Length > 0 && (x.Trim()+"  ").Substring(0, 2) != "//").Count();
            Console.WriteLine($"Total Source Lines:     {lSource.Length}");
            Console.WriteLine($"Actual Code Lines:      {lCodeLines}");
        }

        private static async Task Loop() {
            while (!mToken.IsCancellationRequested) {
                await Task.Run(() => {
                    mCount++;
                    mCurrentProcess.Refresh();
                    mMemory.Add(mCurrentProcess.WorkingSet64);
                });
            }
        }

        public static string DetectAssemblyLanguage(Assembly assembly) {
            // credit: https://stackoverflow.com/questions/33161188/how-to-detect-which-net-language-is-calling-my-code
            var referencedAssemblies = assembly.GetReferencedAssemblies().Select(x => x.Name);

            var types = assembly.GetTypes();

            // Biggest hint: almost all VB.NET projects have a
            // hidden reference to the Microsoft.VisualBasic assembly
            bool referenceToMSVB = referencedAssemblies.Contains("Microsoft.VisualBasic");

            // VB.NET projects also typically reference the special
            // (YourProject).My.My* types that VB generates
            bool areMyTypesPresent = types.Select(x => x.FullName).Where(x => x.Contains(".My.My")).Any();

            // If a VB.NET project uses any anonymous types,
            // the compiler names them like VB$AnonymousType_0`1
            bool generatedVbNames = types.Select(x => x.Name).Where(x => x.StartsWith("VB$")).Any();

            // If a C# project uses dynamic, it'll have a reference to Microsoft.CSharp
            bool referenceToMSCS = referencedAssemblies.Contains("Microsoft.CSharp");

            // If a C# project uses any anonymous types,
            // the compiler names them like <>f__AnonymousType0`1
            bool generatedCsNames = types.Select(x => x.Name).Where(x => x.StartsWith("<>")).Any();

            var evidenceForVb = new bool[] { referenceToMSVB, areMyTypesPresent, generatedVbNames };

            var evidenceForCsharp = new bool[] { true, referenceToMSCS, generatedCsNames };

            var scoreForVb = evidenceForVb.Count(x => x) - evidenceForCsharp.Count(x => x);

            // In the case of a tie, C# is assumed
            return scoreForVb > 0 ? "vb" : "cs";
        }
    }
}
