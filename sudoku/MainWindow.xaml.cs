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
            
            _builder = _sudokuBuilderfactory.GetBuilder(parsedExt);
            _builder.SetContent(content);
            _builder.BuildSudoku();
            _game = new Game(_builder.GetResult());

            Content = new SudokuUserControl(_game);
        }
    }
}