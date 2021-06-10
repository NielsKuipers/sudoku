namespace sudoku.SudokuBoard
{
    public class Board
    {
        public Region Regions { get; set; }
        public Board(Region regions)
        {
            Regions = regions;
        }
    }
}