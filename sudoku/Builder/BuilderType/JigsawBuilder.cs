namespace sudoku.Builder.BuilderType
{
    public class JigsawBuilder : SudokuBuilder
    {
        public override int Size => 9;
        protected override int BlockRowLength => 9;
        protected override int BlocksPerRow { get; }

        public override void BuildSudoku()
        {
            throw new System.NotImplementedException();
        }
    }
}