﻿using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
        private Label _lastSelected;
        private Label _selectedDraft;

        public SudokuUserControl(Game game)
        {
            var colors = new List<SolidColorBrush>
            {
                Brushes.Pink, Brushes.Orange, Brushes.Yellow, Brushes.Lime, Brushes.Coral, Brushes.Cyan,
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
                    var box = new Label
                    {
                        Background = colors[i],
                        VerticalContentAlignment = VerticalAlignment.Center,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        FontSize = 20,
                        FontWeight = FontWeights.Bold,
                        BorderBrush = Brushes.Black,
                        BorderThickness = new Thickness(1)
                    };

                    var draftBox = new Label
                    {
                        Background = Brushes.Transparent,
                        VerticalContentAlignment = VerticalAlignment.Top,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        FontWeight = FontWeights.SemiBold,
                    };

                    if (temp.Value.ToString() != "0")
                    {
                        box.Content = temp.Value.ToString();
                    }

                    cells.Add(temp);

                    Grid.SetColumn(box, temp.X);
                    Grid.SetRow(box, temp.Y);
                    Grid.SetColumn(draftBox, temp.X);
                    Grid.SetRow(draftBox, temp.Y);

                    _sudokuGrid?.Children.Add(box);
                    _sudokuGrid?.Children.Add(draftBox);
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
            if (_lastSelected != null)
                _lastSelected.Background = _tempColor;

            var selectedCell = (UIElement) e.Source;
            var input = _sudokuGrid.Children.Cast<Label>().First(el =>
                Grid.GetRow(el) == Grid.GetRow(selectedCell) && Grid.GetColumn(el) == Grid.GetColumn(selectedCell));
            _selectedDraft = _sudokuGrid.Children.Cast<Label>().Last(el =>
                Grid.GetRow(el) == Grid.GetRow(selectedCell) && Grid.GetColumn(el) == Grid.GetColumn(selectedCell));


            _lastSelected = input;

            _tempColor = input.Background;
            input.Background = Brushes.LightGray;

            _selectedCell = cells.Find(c => c.X == Grid.GetColumn(selectedCell) && c.Y == Grid.GetRow(selectedCell));
        }

        private void NumberButton_OnClick(object sender, RoutedEventArgs e)
        {
            var tag = ((Button) sender).Tag.ToString();
            int.TryParse(tag, out var i);

            _game.HandleInput(_selectedCell, i, _lastSelected, _selectedDraft);
        }

        private void ChangeInputDraft_OnClick(object sender, RoutedEventArgs e)
        {
            _game.GetInput().TransitionTo("draft");
        }

        private void ChangeInputNormal_OnClick(object sender, RoutedEventArgs e)
        {
           _game.GetInput().TransitionTo("normal");
        }

        private void ChangeInputCheat_OnClick(object sender, RoutedEventArgs e)
        {
           _game.GetInput().TransitionTo("cheat");
        }
        
        private void Solve_OnClick(object sender, RoutedEventArgs e)
        {
            _game.GetInput().TransitionTo("solve");
            foreach (var cell in cells)
            {
                var inputLabel = _sudokuGrid.Children.Cast<Label>().First(el =>
                    Grid.GetRow(el) == cell.X && Grid.GetColumn(el) == cell.Y);
                var draftLabel = _sudokuGrid.Children.Cast<Label>().Last(el =>
                    Grid.GetRow(el) == cell.X && Grid.GetColumn(el) == cell.Y);
                
                _game.HandleInput(cell, cell.Answer, inputLabel, draftLabel);
            }
            ChangeInputNormal_OnClick(this, null);
        }
    }
}
