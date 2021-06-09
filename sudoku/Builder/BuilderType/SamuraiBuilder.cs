namespace sudoku.Builder.BuilderType
{
    public class SamuraiBuilder : SudokuBuilder
    {
        public override int Size => 9;
        protected override int BlockRowLength => 3;
        protected override int BlocksPerRow => 3;

        public override void BuildSudoku()
        {
            throw new System.NotImplementedException();
        }
    }
}