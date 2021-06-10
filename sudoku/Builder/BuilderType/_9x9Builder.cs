﻿namespace sudoku.Builder.BuilderType
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
    }
}