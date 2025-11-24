using System.Numerics;

namespace QueensPuzzleExample
{
    public class NQueensBitSolver
    {
        public static IList<IList<string>> SolveNQueens(int n)
        {
            var solutions = new List<IList<string>>();
            // Records the column index where the queen is placed for each row, used for generating the final output
            var queens = new int[n];
            
            // Parameters:
            // row: The current row being processed
            // cols: Vertical column occupancy (1 means occupied)
            // diag1: Left diagonal occupancy (shifts left as we go down)
            // diag2: Right diagonal occupancy (shifts right as we go down)
            Solve(0, 0, 0, 0, n, queens, solutions);
            
            return solutions;
        }

        private static void Solve(int row, int cols, int diag1, int diag2, int n, int[] queens, IList<IList<string>> solutions)
        {
            if (row == n)
            {
                solutions.Add(ConstructBoard(queens, n));
                return;
            }

            // Core Logic:
            // 1. (cols | diag1 | diag2) Combines all attack ranges
            // 2. ~ (Bitwise NOT) Inverts bits: 1 becomes safe, 0 becomes dangerous
            // 3. & ((1 << n) - 1) Mask to ensure we only look at the first n bits, ignoring high-bit noise
            var availablePositions = ((1 << n) - 1) & ~(cols | diag1 | diag2);

            while (availablePositions != 0)
            {
                // Extract the lowest set bit (Low bit) -> This is the rightmost available position
                var position = availablePositions & -availablePositions;
                
                // Remove this position from the available list, preparing for the next iteration
                availablePositions &= availablePositions - 1;

                // Find the bit index of the position (column index)
                // This is for board reconstruction; bitwise operations themselves don't need this index
                var colIndex = BitOperations.TrailingZeroCount(position);
                queens[row] = colIndex;

                // Recurse to the next row
                // diag1 (left diagonal) shifts left << 1 for the next row
                // diag2 (right diagonal) shifts right >> 1 for the next row
                Solve(row + 1, 
                      cols | position, 
                      (diag1 | position) << 1, 
                      (diag2 | position) >> 1, 
                      n, queens, solutions);
            }
        }

        private static List<string> ConstructBoard(int[] queens, int n)
        {
            var board = new List<string>();
            for (int i = 0; i < n; i++)
            {
                var row = new char[n];
                Array.Fill(row, BoardConstants.EmptyChar);
                row[queens[i]] = BoardConstants.QueenChar;
                board.Add(new string(row));
            }
            return board;
        }
    }
}

