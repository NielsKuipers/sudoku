using sudoku.SudokuBoard;

namespace sudoku.States
{
    public class NormalInputState : InputState
    {
        public NormalInputState(InputStateFactory inputStateFactory) : base(inputStateFactory)
        {
        }

        public override void HandleInput(Region cell, int input)
        {
            cell.DraftNumbers.Clear();
            cell.Value = input;
        }
    }
}