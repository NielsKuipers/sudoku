using System;
using sudoku.SudokuBoard;

namespace sudoku.Builder
{
    public abstract class SudokuBuilder : ISudokuBuilder
    {
        protected static readonly SudokuParser SudokuParser = new SudokuParser();
        protected string[] Content { get; private set; }
        public abstract int RegionSize { get; }
        public abstract int BlockRowSize { get; }
        public abstract int BlocksPerRow { get; }
        
        public abstract int BlocksAmount { get; }

        protected Board Board { get; set; }

        public abstract void BuildSudoku();

        public Board GetResult()
        {
            return Board;
        }

        public void SetContent(string[] content)
        {
            Content = content;
        }
        
        protected void BuildGenericSudoku()
        {
            var rows = SudokuParser.ParseGenericSudoku(Content[0], RegionSize);
            
            var x = 0;
            var y = 0;
            var blockPointer = 0;

            var regions = new RegionComposite();
            for (var i = 0; i < BlocksAmount; i++)
            {
                regions.Add(new RegionComposite());
            }
            
            foreach (var row in rows)
            {
                foreach (var cell in row)
                {
                    regions.Get(blockPointer).Add(new Cell(x, y, cell, regions.Get(blockPointer)));
                    x++;
                    if (x % BlockRowSize == 0 && x != RegionSize) blockPointer++;
                }

                if (regions.Get(blockPointer).GetCount() != RegionSize) blockPointer -= BlocksPerRow - 1;
                else blockPointer++;
                x = 0;
                y++;
            }

            Board = new Board(regions);
        }
    }
}