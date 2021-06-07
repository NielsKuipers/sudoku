namespace sudoku.Builder
{
    public abstract class SudokuBuilder : ISudokuBuilder
    {
        private SudokuParser _sudokuParser = new SudokuParser();
        private SudokuReader _sudokuReader = new SudokuReader();

        public void BuildSudoku()
        {
            
        }

        public void GetResult()
        {
            
        }
    }
}