using System.Linq;
using System.Reflection.Emit;
using sudoku.SudokuBoard;
using Label = System.Windows.Controls.Label;

namespace sudoku.States
{
    public class DraftInputState : InputState
    {
        public DraftInputState(InputStateFactory inputStateFactory) : base(inputStateFactory)
        {
        }

        public override void HandleInput(Region cell, int input, Label label, Label selectedDraft)
        {
            if (cell.DraftNumbers.Contains(input))
                cell.DraftNumbers.Remove(input);
            else
                cell.DraftNumbers.Add(input);
            
            var content = cell.DraftNumbers.Aggregate("", (current, number) => current + number);
            selectedDraft.Content = content;
        }
    }
}