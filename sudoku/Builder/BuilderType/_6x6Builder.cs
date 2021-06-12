namespace sudoku.Builder.BuilderType
{
    public class _6x6Builder : SudokuBuilder
    {
        public override int RegionSize => 6;
        public override int BlockRowSize => 3;
        public override int BlocksPerRow => 2;
        public override int BlocksAmount => 6;
        public override void BuildSudoku()
        {
            BuildGenericSudoku();
        }

        public override void GenerateAnswer()
        {
            throw new System.NotImplementedException();
        }
    }
}