using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using sudoku.Models;
using sudoku.SudokuBoard;

namespace sudoku.Views
{
    public partial class SudokuUserControl : UserControl
    {
        private Game _game; 
        List<Region> cells = new List<Region>();
        private Region _selectedCell;
        private Grid _sudokuGrid;
        private Brush _tempColor;
        private TextBox _lastSelected;
        
        public SudokuUserControl(Game game)
        {
            var colors = new List<SolidColorBrush>
            {
                Brushes.Red, Brushes.Orange, Brushes.Yellow, Brushes.Lime, Brushes.Green, Brushes.Cyan,
                Brushes.Blue, Brushes.Purple, Brushes.Magenta
            };

            InitializeComponent();
            _game = game;
            GenerateButtons();
            _sudokuGrid = (Grid) FindName("SudokuGrid");

            for (var i = 0; i < _game.Board.Regions.GetCount(); i++)
            {
                _sudokuGrid?.ColumnDefinitions.Add(new ColumnDefinition());
                _sudokuGrid?.RowDefinitions.Add(new RowDefinition());

                var curRegion = _game.Board.Regions.Get(i);

                for (var j = 0; j < curRegion.GetCount(); j++)
                {
                    var temp = curRegion.Get(j);
                    var box = new TextBox {Background = colors[i]};

                    if (temp.Value.ToString() != "0")
                        box.Text = temp.Value.ToString();
                    
                    cells.Add(temp);
                    
                    Grid.SetColumn(box, temp.X);
                    Grid.SetRow(box, temp.Y);

                    _sudokuGrid?.Children.Add(box);
                }
            }
        }

        private void GenerateButtons()
        {
            var grid = (Grid) FindName("ButtonsGrid");
            var x = 0;
            var y = 0;
            
            for (var i = 0; i < _game.SudokuSize; i++)
            {
                if (x > 2)
                {
                    x = 0;
                    y++;
                }
                
                var b = new Button
                {
                    Tag = i + 1,
                    Content = i + 1,
                };

                b.Click += NumberButton_OnClick;
                Grid.SetColumn(b, x);
                Grid.SetRow(b, y);
                
                grid?.Children.Add(b);

                x++;
            }
        }

        private void SudokuGrid_OnMouseDown(object sender, MouseEventArgs e)
        {
            if(_lastSelected != null)
                _lastSelected.Background = _tempColor;
            
            var r = (UIElement) e.Source;
            var input = _sudokuGrid.Children.Cast<TextBox>().First(el =>
                Grid.GetRow(el) == Grid.GetRow(r) && Grid.GetColumn(el) == Grid.GetColumn(r));
            _lastSelected = input;
            
            _tempColor = input.Background;
            input.Background = Brushes.LightGray;

            _selectedCell = cells.Find(c => c.X == Grid.GetColumn(r) && c.Y == Grid.GetRow(r));
        }

        private void NumberButton_OnClick(object sender, RoutedEventArgs e)
        {
            var tag = ((Button) sender).Tag.ToString();
            _lastSelected.Text = tag;
            int.TryParse(tag, out var i);
            
            _game.HandleInput(_selectedCell, i);
        }
    }
}