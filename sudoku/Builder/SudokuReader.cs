using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using sudoku.Exceptions;

namespace sudoku.Builder
{
    public class SudokuReader
    {
        public static (string[] content, SudokuType parsedExt) ReadFile()
        {
            var filter = "sudoku files |";
            foreach (var e in Enum.GetValues(typeof(SudokuType)))
            {
                var ext = e.ToString().Replace("_", "").ToLower();
                filter += "*." + ext + ";";
            }
            
            var openFileDialog = new OpenFileDialog
            {
                Filter = filter
            };

            var path = openFileDialog.FileName;
            var extenstion = Path.GetExtension(path).Remove(0, 1);

            if (char.IsNumber(extenstion[0]))
                extenstion = "_" + extenstion;

            Enum.TryParse(extenstion, out SudokuType parsedExt);
            
            var content = File.ReadAllLines(path);
            var sudoku = (content, parsedExt);

            return sudoku;
        }
    }
}