using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using sudoku.Builder;
using sudoku.Models;
using sudoku.States;
using sudoku.SudokuBoard;
using sudoku.Views;

namespace sudoku
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly SudokuBuilderFactory _sudokuBuilderfactory;
        private ISudokuBuilder _builder;
        private Game _game;

        public MainWindow()
        {
            InitializeComponent();
            _sudokuBuilderfactory = new SudokuBuilderFactory();
        }

        private void ReadFile_Click(object sender, RoutedEventArgs e)
        {
            var (content, parsedExt) = SudokuReader.ReadFile();
            var sudokuSize = 0;

            switch (parsedExt)
            {
                case SudokuType._4x4:
                    sudokuSize = 4;
                    break;
                case SudokuType._6x6:
                    sudokuSize = 6;
                    break;
                case SudokuType._9x9:
                case SudokuType.Samurai:
                case SudokuType.Jigsaw:
                    sudokuSize = 9;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            _builder = _sudokuBuilderfactory.GetBuilder(parsedExt);
            _builder.SetContent(content);
            _builder.BuildSudoku();
            _builder.GenerateAnswer();
            _game = new Game(_builder.GetResult(), sudokuSize);

            Content = new SudokuUserControl(_game);
        }
    }
}