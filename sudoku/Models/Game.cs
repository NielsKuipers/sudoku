using sudoku.States;
using sudoku.SudokuBoard;

namespace sudoku.Models
{
    public class Game : IInputStateContext
    {
        private InputState _inputState;
        public Board Board { get; }

        public Game(Board board)
        {
            SetInputState(new NormalInputState(new InputStateFactory()));
            Board = board;
        }
        
        public void SetInputState(InputState inputState)
        {
            _inputState = inputState;
            _inputState.SetContext(this);
        }
    }
}