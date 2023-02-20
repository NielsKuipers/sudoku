using System.Windows.Controls;
using sudoku.SudokuBoard;

namespace sudoku.States
{
    public class NormalInputState : InputState
    {
        public NormalInputState(InputStateFactory inputStateFactory) : base(inputStateFactory)
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
            }
            else
            {
                cell.Value = input;
                label.Content = input;
            }
        }
    }
}