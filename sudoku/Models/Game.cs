using sudoku.States;
using sudoku.SudokuBoard;

namespace sudoku.Models
{
    public class Game : IInputStateContext
    {
        private InputState _inputState;
        public Board Board { get; }
        public int SudokuSize { get; }

        public Game(Board board, int sudokuSize)
        {
            SetInputState(new NormalInputState(new InputStateFactory()));
            Board = board;
            SudokuSize = sudokuSize;
        }
        
        public void SetInputState(InputState inputState)
        {
            _inputState = inputState;
            _inputState.SetContext(this);
        }

        public void HandleInput(Region cell, int input)
        {
            _inputState.HandleInput(cell, input);
        }
    }
}