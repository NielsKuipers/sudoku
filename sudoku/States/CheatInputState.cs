using sudoku.SudokuBoard;

namespace sudoku.States
{
    public class CheatInputState : InputState
    {
        public CheatInputState(InputStateFactory inputStateFactory) : base(inputStateFactory)
        {
        }

        public override void HandleInput(Region cell, int input)
        {
            throw new System.NotImplementedException();
        }
    }
}