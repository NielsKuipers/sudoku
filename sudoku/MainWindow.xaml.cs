﻿using System.Diagnostics;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using sudoku.Board;
using sudoku.Builder;

namespace sudoku
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private (string[] content, SudokuType type) _rawSudoku;
        private readonly SudokuBuilderFactory _factory;
        private ISudokuBuilder _builder;

        public MainWindow()
        {
            InitializeComponent();
            _factory = new SudokuBuilderFactory();

            var composite = new RowComposite(new Cell(4),
                new Cell(5),
                new Cell(6));

            var b = composite.GetValues();

            foreach (var i in b)
            {
                Debug.WriteLine(i);
            }
        }

        private void ReadFile_Click(object sender, RoutedEventArgs e)
        {
            _rawSudoku = SudokuReader.ReadFile();
            _builder = _factory.GetBuilder(_rawSudoku.type);
            _builder.SetContent(_rawSudoku.content);

            _builder.BuildSudoku();
        }
    }
}