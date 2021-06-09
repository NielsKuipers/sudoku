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
        private SudokuReader reader;
        public MainWindow()
        {
            reader = new SudokuReader();
            InitializeComponent();
        }

        private void readfile_Click(object sender, RoutedEventArgs e)
        {
            reader.ReadFile();
        }
    }
}