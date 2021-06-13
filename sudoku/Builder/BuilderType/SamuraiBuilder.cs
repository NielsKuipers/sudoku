using System;
using System.Collections.Generic;
using System.IO;
using sudoku.SudokuBoard;

namespace sudoku.Builder.BuilderType
{
    public class SamuraiBuilder : SudokuBuilder
    {
        public override int RegionSize => 9;
        public override int BlockRowSize => 3;
        public override int BlocksPerRow => BlockRowSize;
        public override int BlocksAmount => 45;

        public override void BuildSudoku()
        {
            var sudoku = SudokuParser.ParseSamuraiSudoku(Content);
            int x = 0, y = 0, blockPointer = 0;

            var regions = new RegionComposite();
            for (var i = 0; i < BlocksAmount; i++)
            {
                regions.Add(new RegionComposite());
            }

            for (var i = 0; i < sudoku.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        x = 0;
                        y = 0;
                        break;
                    case 1:
                        x = 12;
                        y = 0;
                        break;
                    case 2:
                        x = 6;
                        y = 6;
                        break;
                    case 3:
                        x = 0;
                        y = 12;
                        break;
                    case 4:
                        x = 12;
                        y = 12;
                        break;
                }

                var sudokuPart = sudoku[i];
                var startX = x;

                foreach (var row in sudokuPart)
                {
                    foreach (var cell in row)
                    {
                        regions.Get(blockPointer).Add(new Cell(x, y, cell, regions.Get(blockPointer)));
                        x++;
                        var curCellsAmount = regions.Get(blockPointer).GetCount();
                        if (curCellsAmount % BlockRowSize == 0) blockPointer++;
                    }

                    if (regions.Get(blockPointer - 1).GetCount() != RegionSize) blockPointer -= BlocksPerRow;
                    x = startX;
                    y++;
                }
            }

            regions.RemoveAt(18);
            regions.RemoveAt(19);
            regions.RemoveAt(24);
            regions.RemoveAt(26);

            Board = new Board(regions);
        }

        public override void GenerateAnswer()
        {
            var cells = new List<Region>();
            var rawAnswer =
                File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"resources\puzzle.samurai.txt"));
            var answer = new int[rawAnswer.Length, rawAnswer.Length];

            for (var i = 0; i < rawAnswer.Length; i++)
            {
                var row = rawAnswer[i];
                for (var j = 0; j < row.Length; j++)
                {
                    int.TryParse(row[j].ToString(), out var value);
                    answer[i, j] = value;
                }
            }

            for (var i = 0; i < Board.Regions.GetCount(); i++)
            {
                var reg = Board.Regions.Get(i);
                for (var j = 0; j < reg.GetCount(); j++)
                {
                    cells.Add(reg.Get(j));
                }
            }

            foreach (var cell in cells)
            {
                cell.Answer = answer[cell.X, cell.Y];
            }
        }
    }
}