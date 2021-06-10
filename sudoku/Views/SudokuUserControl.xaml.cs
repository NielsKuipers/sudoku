using System.Runtime.CompilerServices;
using System.Windows;
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
            var grid = (Grid) FindName("sudokuGrid");

            for (var i = 0; i < _board.Regions.GetCount(); i++)
            {
                grid?.ColumnDefinitions.Add(new ColumnDefinition {Width = new GridLength(20)});
                grid?.RowDefinitions.Add(new RowDefinition{Height = new GridLength(20)});
                
                var curRegion = _board.Regions.Get(i);

                for (var j = 0; j < curRegion.GetCount(); j++)
                {
                    var temp = curRegion.Get(j);
                    var box = new TextBox {Text = temp.Value.ToString()};

                    Grid.SetColumn(box, temp.X);
                    Grid.SetRow(box, temp.Y);

                    grid?.Children.Add(box);
                }
            }
        }
    }
}