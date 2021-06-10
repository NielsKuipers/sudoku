using System.Windows.Controls;
using sudoku.SudokuBoard;

namespace sudoku.Views
{
    public partial class SudokuUserControl : UserControl
    {
        private Board _board;
        public SudokuUserControl(Board board)
        {
            InitializeComponent();
            _board = board;
        }
    }
}