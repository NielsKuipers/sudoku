using System.Collections.Generic;

namespace sudoku.Builder
{
    public class SudokuParser
    {
        public void ParseSudoku(string[] content, int rowLength)
        {
            var boardData = new Dictionary<string, List<int>>();
            foreach (var line in content)
            {
                for (var i = 0; i < rowLength - 1; i++)
                {
                    
                }
            }
        }
    }
}