using System.Collections.Generic;

namespace sudoku.States
{
    public class InputStateFactory
    {
        private readonly Dictionary<string, InputState> _inputStates;

        public InputStateFactory()
        {
            _inputStates = new Dictionary<string, InputState>
            {
                { "normal", new NormalInputState(this) },
                { "draft", new DraftInputState(this) },
                { "cheat", new CheatInputState(this) }
            };
        }

        public InputState GetState(string key)
        {
            return _inputStates[key];
        }
    }
}