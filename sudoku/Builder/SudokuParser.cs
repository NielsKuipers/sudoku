using System;
using System.Collections.Generic;
using System.Linq;

namespace sudoku.Builder
{
    public class SudokuParser
    {
        public static List<List<int>> ParseGenericSudoku(string content, int rowSize)
        {
            var rows = new List<List<int>>();
            for (var i = 0; i < rowSize; i++)
            {
                rows.Add(new List<int>());
            }

            var rowPointer = 0;
            
            foreach (var value in content.Select(c => int.Parse(c.ToString())))
            {
                rows[rowPointer].Add(value);
                if (rows[rowPointer].Count == rowSize) rowPointer++;
            }
            
            return rows;
        }

        public static List<List<int>> ParseSamuraiSudoku(string[] content)
        {
            throw new NotImplementedException();
        }

        public static List<List<int>> ParseJigSawSudoku(string content)
        {
            throw new NotImplementedException();
        }
    }
}