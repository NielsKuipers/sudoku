namespace sudoku.Builder.BuilderType
{
    public class _4x4Builder : SudokuBuilder
    {
        public override int RowLength => 4;

        public override void BuildSudoku()
        {
            SudokuParser.ParseSudoku(Content, RowLength, 4, 2);
        }
    }
}