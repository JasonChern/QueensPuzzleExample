# N-Queens Puzzle Solver

A C# console application that solves the N-Queens problem using two different algorithms: **Basic Backtracking** and **Bit Manipulation**.

## Features

- **Multiple Algorithms**:
  - `BasicBacktracking`: Standard recursive backtracking approach.
  - `BitManipulation`: Optimized approach using bitwise operators for faster execution.
- **Performance Timing**: Measures and displays the execution time for the selected algorithm.
- **Solution Visualization**: Prints all valid board configurations to the console.

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/JasonChern/QueensPuzzleExample.git
   ```
2. Navigate to the project directory:
   ```bash
   cd QueensPuzzleExample
   ```

### Usage

1. Run the application:
   ```bash
   dotnet run
   ```

2. To change the N-Queens size (default is 8) or the algorithm, modify `EntryPoint.cs`:

   ```csharp
   static void RunApplication()
   {
       int n = 8; // Change board size here
       
       // Switch algorithm here
       var algorithm = AlgorithmType.BitManipulation; 
       // Options: AlgorithmType.BasicBacktracking, AlgorithmType.BitManipulation
       
       // ...
   }
   ```

## Algorithms

### Basic Backtracking (`NQueensBasicSolver`)
Uses a 2D array to represent the board and checks column, left diagonal, and right diagonal constraints iteratively for every placement.

### Bit Manipulation (`NQueensBitSolver`)
Uses integers to represent the columns and diagonals. Bitwise operators (`&`, `|`, `~`, `<<`, `>>`) are used to calculate available positions and valid moves in constant time, significantly improving performance for larger N.

## Project Structure

- `EntryPoint.cs`: Main entry point, handles configuration and execution flow.
- `NQueensBasicSolver.cs`: Implementation of the standard backtracking algorithm.
- `NQueensBitSolver.cs`: Implementation of the optimized bitwise algorithm.
- `BoardConstants.cs`: Shared constants for board representation (e.g., 'Q', '.').

