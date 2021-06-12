namespace sudoku.Builder.BuilderType
{
    public class _9x9Builder : SudokuBuilder
    {
        public override int RegionSize => 9;
        public override int BlockRowSize => 3;
        public override int BlocksPerRow => BlockRowSize;
        public override int BlocksAmount => 9;

        public override void BuildSudoku()
        {
            BuildGenericSudoku();
        }

        public override void GenerateAnswer()
        {
            var grid = new int[9, 9];

            for (var i = 0; i < Board.Regions.GetCount(); i++)
            {
                var curRegion = Board.Regions.Get(i);

                for (var j = 0; j < curRegion.GetCount(); j++)
                {
                    grid[curRegion.Get(j).X, curRegion.Get(j).Y] = curRegion.Get(j).Value;
                }
            }

            if (SudokuSolver.SudokuSolver.Solve(grid))
                Board.Answer = grid;
        }
    }
}