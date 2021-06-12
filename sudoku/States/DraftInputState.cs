using sudoku.SudokuBoard;

namespace sudoku.States
{
    public class DraftInputState : InputState
    {
        public DraftInputState(InputStateFactory inputStateFactory) : base(inputStateFactory)
        {
        }

        public override void HandleInput(Region cell, int input)
        {
            if (cell.DraftNumbers.Contains(input))
                cell.DraftNumbers.Remove(input);
            else
                cell.DraftNumbers.Add(input);
        }
    }
}