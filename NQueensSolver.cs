namespace QueensPuzzleExample
{
    public class NQueensSolver
    {
        private const char QueenChar = 'Q';
        private const char EmptyChar = '.';

        public static IList<IList<string>> SolveNQueens(int n)
        {
            var solutions = new List<IList<string>>();
            var board = new char[n][];
            for (int i = 0; i < n; i++)
            {
                board[i] = new char[n];
                Array.Fill(board[i], EmptyChar);
            }

            Backtrack(0, board, solutions, n);
            return solutions;
        }

        private static void Backtrack(int row, char[][] board, IList<IList<string>> solutions, int n)
        {
            if (row == n)
            {
                solutions.Add(ConstructBoard(board));
                return;
            }

            for (int col = 0; col < n; col++)
            {
                if (IsValid(row, col, board, n))
                {
                    board[row][col] = QueenChar;
                    Backtrack(row + 1, board, solutions, n);
                    board[row][col] = EmptyChar;
                }
            }
        }

        private static bool IsValid(int row, int col, char[][] board, int n)
        {
            for (int i = 0; i < row; i++)
            {
                int diff = row - i;

                // Check column
                if (board[i][col] == QueenChar) return false;

                // Check upper left diagonal
                if (col - diff >= 0 && board[i][col - diff] == QueenChar) return false;

                // Check upper right diagonal
                if (col + diff < n && board[i][col + diff] == QueenChar) return false;
            }

            return true;
        }

        private static List<string> ConstructBoard(char[][] board)
        {
            var result = new List<string>();
            foreach (var row in board)
            {
                result.Add(new string(row));
            }
            return result;
        }
    }
}

