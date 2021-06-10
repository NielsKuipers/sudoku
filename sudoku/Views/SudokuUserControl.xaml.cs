using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using sudoku.SudokuBoard;

namespace sudoku.Views
{
    public partial class SudokuUserControl : UserControl
    {
        private Board _board;

        public SudokuUserControl(Board board)
        {
            var colors = new List<SolidColorBrush>
            {
                Brushes.Red, Brushes.Orange, Brushes.Yellow, Brushes.Lime, Brushes.Green, Brushes.Cyan,
                Brushes.Blue, Brushes.Purple, Brushes.Magenta
            };

            InitializeComponent();
            _board = board;
            var grid = (Grid) FindName("SudokuGrid");

            for (var i = 0; i < _board.Regions.GetCount(); i++)
            {
                grid?.ColumnDefinitions.Add(new ColumnDefinition());
                grid?.RowDefinitions.Add(new RowDefinition());
                
                var curRegion = _board.Regions.Get(i);

                for (var j = 0; j < curRegion.GetCount(); j++)
                {
                    var temp = curRegion.Get(j);
                    var box = new TextBox {Text = temp.Value.ToString(), Background = colors[i]};

                    Grid.SetColumn(box, temp.X);
                    Grid.SetRow(box, temp.Y);

                    grid?.Children.Add(box);
                }
            }
        }
    }
}