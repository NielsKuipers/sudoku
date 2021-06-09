using System;

namespace sudoku.Exceptions
{
    public class InvalidSudokuFileException : Exception
    {
        public InvalidSudokuFileException() {}

        public InvalidSudokuFileException(string message) : base(message) {}

        public InvalidSudokuFileException(string message, Exception inner ) : base(message, inner) {}
    }
}