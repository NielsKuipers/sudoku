namespace sudoku.Builder.BuilderType
{
    public class _6x6Builder : SudokuBuilder
    {
        public override int Size => 6;
        protected override int BlockRowLength => 3;
        protected override int BlocksPerRow => 2;

        public override void BuildSudoku()
        {
            var rawBoard = SudokuParser.ParseGenericSudoku(Content[0], Size, 3, 2);
        }
    }
}