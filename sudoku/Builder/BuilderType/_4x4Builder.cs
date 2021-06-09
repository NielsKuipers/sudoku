namespace sudoku.Builder.BuilderType
{
    public class _4x4Builder : SudokuBuilder
    {
        public override int Size => 4;
        protected override int BlockRowLength => 2;
        protected override int BlocksPerRow => 2;

        public override void BuildSudoku()
        {
            var rawBoard = SudokuParser.ParseGenericSudoku(Content[0], Size, 2, 2);
        }
    }
}