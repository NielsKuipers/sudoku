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
                Brushes.Brown, Brushes.Aqua, Brushes.Chartreuse, Brushes.Crimson, Brushes.Fuchsia, Brushes.Chocolate,
                Brushes.Gold, Brushes.CadetBlue, Brushes.Orange
            };

            InitializeComponent();
            _board = board;
            var grid = (Grid) FindName("sudokuGrid");

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