namespace sudoku.Builder.BuilderType
{
    public class _4x4Builder : SudokuBuilder
    {
        public override int RegionSize => 4;
        public override int BlockRowSize => 2;
        public override int BlocksPerRow => BlockRowSize;
        public override int BlocksAmount => 4;

        public override void BuildSudoku()
        {
            BuildGenericSudoku();
        }
    }
}