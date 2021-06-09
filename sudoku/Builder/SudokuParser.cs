using System;
using System.Collections.Generic;
using System.Linq;

namespace sudoku.Builder
{
    public class SudokuParser
    {
        public void ParseSudoku(IEnumerable<string> content, int rowLength, int colLength, int blockSize)
        {
            var boardData = new Dictionary<string, List<List<int>>>();
            foreach (var line in content)
            {
                var rows = new List<List<int>>();
                var row = new List<int>();
                
                var cols = new List<List<int>>();
                for (var i = 0; i < colLength; i++)
                {
                    cols.Add(new List<int>());
                }

                var colPointer = 0;
                
                var block = new List<List<int>>();

                foreach (var value in line.Select(c => int.Parse(c.ToString())))
                {
                    // rows
                    row.Add(value);
                    if (row.Count == rowLength)
                    {
                        rows.Add(new List<int>(row));
                        row.Clear();
                    }
                    
                    // cols
                    cols[colPointer].Add(value);
                    colPointer++;
                    if (colPointer == colLength) colPointer = 0;
                    
                    // blocks
                    
                }

                foreach (var t in cols)
                {
                    System.Diagnostics.Debug.WriteLine("NEW COL");
                    foreach (var i in t)
                    {
                        System.Diagnostics.Debug.WriteLine(i);
                    }
                }
            }
        }
    }
}