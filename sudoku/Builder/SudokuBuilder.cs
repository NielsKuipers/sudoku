using System;
using sudoku.Exceptions;

namespace sudoku.Builder
{
    public abstract class SudokuBuilder : ISudokuBuilder
    {
        protected static readonly SudokuParser sudokuParser = new SudokuParser();
        protected string[] Content { get; private set; }
        public abstract int RowLength { get; }
        
        public abstract void BuildSudoku();

        public void GetResult()
        {
            
        }

        public void SetContent(string[] content)
        {
            Content = content;
        }
    }
}