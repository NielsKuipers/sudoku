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

        public static List<List<List<int>>> ParseSamuraiSudoku(string[] content)
        {
            const int rowSize = 9;

            return content.Select(part => ParseGenericSudoku(part, rowSize)).ToList();
        }

        public static List<List<string>> ParseJigSawSudoku(string content)
        {
            const int rowSize = 9;

            var rows = new List<List<string>>();
            for (var i = 0; i < rowSize; i++)
            {
                rows.Add(new List<string>());
            }
            
            var values = content.Split('=').ToList();
            values.RemoveAt(0);

            var rowPointer = 0;
            
            foreach (var value in values)
            {
                rows[rowPointer].Add(value);
                if (rows[rowPointer].Count == rowSize) rowPointer++;
            }
            
            return rows;
        }
    }
}