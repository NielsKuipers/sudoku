namespace sudoku.Builder.BuilderType
{
    public class _9x9Builder : SudokuBuilder
    {
        public override int Size => 9;
        protected override int BlockRowLength => 3;
        protected override int BlocksPerRow => 3;

        public override void BuildSudoku()
        {
            var rawBoard = SudokuParser.ParseGenericSudoku(Content[0], Size, 3, 3);
        }
    }
}