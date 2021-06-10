using System;
using System.Linq;
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
            var rows = SudokuParser.ParseJigSawSudoku(Content[0]); 
            
            var x = 0;
            var y = 0;

            var regions = new RegionComposite();
            for (var i = 0; i < BlocksAmount; i++)
            {
                regions.Add(new RegionComposite());
            }
            
            foreach (var row in rows)
            {
                foreach (var cellInfo in row.Select(cell => cell.Split('J')))
                {
                    int.TryParse(cellInfo[0], out var cellValue);
                    int.TryParse(cellInfo[1], out var cellBlock);
                    regions.Get(cellBlock).Add(new Cell(x, y, cellValue, regions.Get(cellBlock)));
                    x++;
                }
                x = 0;
                y++;
            }

            Board = new Board(regions);
        }
        
    }
}