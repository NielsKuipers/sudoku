using System;
using System.Collections.Generic;
using System.Linq;

namespace sudoku.Builder
{
    public class SudokuParser
    {
        public static Dictionary<string, List<List<int>>> ParseGenericSudoku(string content, int size, int blockRowLength, int blocksPerRow)
        {
            var boardData = new Dictionary<string, List<List<int>>>();
            var rows = new List<List<int>>();
            for (var i = 0; i < size; i++)
            {
                rows.Add(new List<int>());
            }

            var cols = new List<List<int>>();
            for (var i = 0; i < size; i++)
            {
                cols.Add(new List<int>());
            }

            var blocks = new List<List<int>>();
            for (var i = 0; i < size; i++)
            {
                blocks.Add(new List<int>());
            }

            var rowPointer = 0;
            var colPointer = 0;
            var blockPointer = 0;
            
            foreach (var value in content.Select(c => int.Parse(c.ToString())))
            {
                // blocks and rows
                blocks[blockPointer].Add(value);
                rows[rowPointer].Add(value);
                if (rows[rowPointer].Count == size)
                {
                    rowPointer++;
                    if (blocks[blockPointer].Count != size) blockPointer -= blocksPerRow - 1;
                    else blockPointer++;
                }
                else if (blocks[blockPointer].Count % blockRowLength == 0) blockPointer++;


                // cols
                cols[colPointer].Add(value);
                colPointer++;
                if (colPointer == size) colPointer = 0;
            }

            boardData.Add("rows", rows);
            boardData.Add("cols", cols);
            boardData.Add("blocks", blocks);
            return boardData;
        }
    }
}