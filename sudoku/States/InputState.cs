﻿using sudoku.SudokuBoard;

namespace sudoku.States
{
    public abstract class InputState
    {
        protected IInputStateContext InputStateContext;
        private readonly InputStateFactory _inputStateFactory;

        protected InputState(InputStateFactory inputStateFactory)
        {
            _inputStateFactory = inputStateFactory;
        }
        
        public void SetContext(IInputStateContext inputStateContext)
        {
            InputStateContext = inputStateContext;
        }

        public void TransitionTo(string key)
        {
            InputStateContext.SetInputState(_inputStateFactory.GetState(key));
        }

        public abstract void HandleInput(Region cell, int input);
    }
}