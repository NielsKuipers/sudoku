namespace sudoku.Builder.BuilderType
{
    public class SamuraiBuilder : SudokuBuilder
    {
        public override int RowLength => 9;

        public override void BuildSudoku()
        {
            throw new System.NotImplementedException();
        }
    }
}