using System.Windows.Controls;
using sudoku.SudokuBoard;

namespace sudoku.States
{
    public class SolveInputState : InputState
    {
        public SolveInputState(InputStateFactory inputStateFactory) : base(inputStateFactory)
        {
        }

        public override void HandleInput(Region cell, int input, Label label, Label selectedDraft)
        {
            cell.DraftNumbers.Clear();
            label.Content = "";
            selectedDraft.Content = "";
            cell.Value = input;
            label.Content = input;
        }
    }
}