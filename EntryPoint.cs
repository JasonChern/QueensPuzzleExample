namespace QueensPuzzleExample
{
    internal class EntryPoint
    {
        static void Main()
        {
            RunApplication();
        }

        static void RunApplication()
        {
            int n = 8;
            var solutions = NQueensSolver.SolveNQueens(n);

            Console.WriteLine($"Total solutions for {n}-queens puzzle: {solutions.Count}");
            Console.WriteLine();

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
