using System.Diagnostics;

namespace QueensPuzzleExample
{
    internal class EntryPoint
    {
        // Define algorithm types
        enum AlgorithmType
        {
            BasicBacktracking,
            BitManipulation    
        }

        static void Main()
        {
            RunApplication();
        }

        static void RunApplication()
        {
            int n = 8;
            
            // Switch algorithm here
            var algorithm = AlgorithmType.BitManipulation;

            Console.WriteLine($"Solving {n}-Queens using {algorithm}...");

            IList<IList<string>> solutions;
            var sw = Stopwatch.StartNew();

            solutions = algorithm switch
            {
                AlgorithmType.BitManipulation => NQueensBitSolver.SolveNQueens(n),
                AlgorithmType.BasicBacktracking => NQueensBasicSolver.SolveNQueens(n),
                _ => NQueensBasicSolver.SolveNQueens(n)
            };

            sw.Stop();

            Console.WriteLine($"Total solutions: {solutions.Count}");
            Console.WriteLine($"Time elapsed: {sw.Elapsed.TotalMilliseconds} ms");
            Console.WriteLine();

           //Print all solutions in console
            for (int i = 0; i < solutions.Count; i++)
            {
                Console.WriteLine($"// Solution {i + 1}");
                foreach (var row in solutions[i])
                {
                    Console.WriteLine(row);
                }
                Console.WriteLine();
            }
        }
    }
}
