using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace sudoku.Builder
{
    public class SudokuReader
    {
        public void ReadFile()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "txt files (*.txt)|*.txt"
            };

            if (openFileDialog.ShowDialog() != true) return;

            var path = openFileDialog.FileName;
            var lines = File.ReadAllLines(path);
            
            foreach (var line in lines)
            {
            }
        }
    }
}