using System.IO;
using System.Windows;
using Microsoft.Win32;
using sudoku.Builder;

namespace sudoku
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private (string[] content, SudokuType type) _rawSudoku; 
        private SudokuBuilderFactory _factory;
        private ISudokuBuilder _builder;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void readfile_Click(object sender, RoutedEventArgs e)
        {
            _rawSudoku = SudokuReader.ReadFile();
            _builder = _factory.getBuilder(_rawSudoku.type);
            _builder.SetContent(_rawSudoku.content);
            
            _builder.BuildSudoku();
        }
    }
}