using System;
using System.Collections.Generic;
using sudoku.Builder.BuilderType;

namespace sudoku.Builder
{
    public class SudokuBuilderFactory
    {
        private readonly Dictionary<SudokuType, ISudokuBuilder> _builders;

        public SudokuBuilderFactory()
        {
            _builders = new Dictionary<SudokuType, ISudokuBuilder>
            {
                {SudokuType._4x4, new _4x4Builder()},
                {SudokuType._6x6, new _6x6Builder()},
                {SudokuType._9x9, new _9x9Builder()},
                {SudokuType.Samurai, new SamuraiBuilder()},
                {SudokuType.Jigsaw, new JigsawBuilder()}
            };
        }

        public ISudokuBuilder GetBuilder(SudokuType ext)
        {
            return _builders[ext];
        }
    }
}