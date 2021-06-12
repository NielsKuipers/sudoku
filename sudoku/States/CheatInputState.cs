using System.Windows.Controls;
using System.Windows.Media;
using sudoku.SudokuBoard;

namespace sudoku.States
{
    public class CheatInputState : InputState
    {
        public CheatInputState(InputStateFactory inputStateFactory) : base(inputStateFactory)
        {
        }

        public override void HandleInput(Region cell, int input, Label label, Label selectedDraft)
        {
            cell.DraftNumbers.Clear();
            label.Content = "";
            selectedDraft.Content = "";
            if (input == cell.Value)
            {
                cell.Value = 0;
                return;
            }
            
            if (input == cell.Answer)
            {
                label.Background = Brushes.Green;
            }
            else
            {
                label.Background = Brushes.Red;
            }
            cell.Value = input;
            label.Content = input;
        }
    }
}