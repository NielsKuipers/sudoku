using sudoku.SudokuBoard;

namespace sudoku.Builder
{
    public interface ISudokuBuilder
    {
        void BuildSudoku();
        void SetContent(string[] content);
        Board GetResult();
    }
}