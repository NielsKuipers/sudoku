using System.Windows.Controls;
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
            throw new System.NotImplementedException();
        }
    }
}