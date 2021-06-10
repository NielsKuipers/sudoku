namespace sudoku.SudokuBoard
{
    public sealed class Cell : Region
    {
        public Cell(int x, int y, int value, Region region)
        {
            X = x;
            Y = y;
            Value = value;
            MyRegion = region;
        }
    }
}