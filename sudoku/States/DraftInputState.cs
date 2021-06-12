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
            throw new System.NotImplementedException();
        }
    }
}