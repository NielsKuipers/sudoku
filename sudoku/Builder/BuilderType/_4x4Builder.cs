using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Documents;
using sudoku.SudokuBoard;

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

        public override void GenerateAnswer()
        {
            var cells = new List<Region>();
            var rawAnswer = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"resources\puzzle.4x4.txt"));
            var temp = rawAnswer[0];

            var x = 0;
            var y = 0;
            
            for (var i = 0; i < Board.Regions.GetCount(); i++)
            {
                var reg = Board.Regions.Get(i);
                for (var j = 0; j < reg.GetCount(); j++)
                {
                    cells.Add(reg.Get(j));
                }
            }

            foreach (var cellValue in temp)
            {
                if (x == 4)
                {
                    x = 0;
                    y++;
                }
                int.TryParse(cellValue.ToString(), out var value);

                var cell = cells.Find(c => c.X == y && c.Y == x);
                cell.Answer = value;
                
                x++;
            }
        }
    }
}