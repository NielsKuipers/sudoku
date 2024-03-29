﻿using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using sudoku.Exceptions;

namespace sudoku.Builder
{
    public static class SudokuReader
    {
        public static (string[] content, SudokuType parsedExt) ReadFile()
        {
            const string defaultSudoku = "_4x4";
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

            if (openFileDialog.ShowDialog() != true) throw new Exception();
            
            var path = openFileDialog.FileName;
            var extenstion = Path.GetExtension(path).Remove(0, 1);

            if (char.IsNumber(extenstion[0]))
                extenstion = "_" + extenstion;

            Enum.TryParse(extenstion, true, out SudokuType parsedExt);

            if (parsedExt == 0 && extenstion != defaultSudoku) throw new InvalidSudokuFileException();
            
            var content = File.ReadAllLines(path);

            return (content, parsedExt);
        }
    }
}