using System;
using sudoku.SudokuBoard;

namespace sudoku.Builder.BuilderType
{
    public class JigsawBuilder : SudokuBuilder
    {
        public override int RegionSize => 9;
        public override int BlockRowSize => throw new NotImplementedException();
        public override int BlocksPerRow => throw new NotImplementedException();
        public override int BlocksAmount => 9;

        public override void BuildSudoku()
        {
            throw new System.NotImplementedException();
        }
        
    }
}