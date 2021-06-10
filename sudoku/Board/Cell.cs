using System.Diagnostics;

namespace sudoku.Board
{
    public class Cell : IRegion
    {
        private int Value { get; }

        public Cell(int val)
        {
            Value = val;
        }

        public bool IsValid()
        {
            return true;
        }
    }
}