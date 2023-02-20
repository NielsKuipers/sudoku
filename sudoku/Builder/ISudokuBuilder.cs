using sudoku.SudokuBoard;

namespace sudoku.Builder
{
    public interface ISudokuBuilder
    {
        void BuildSudoku();
        void GenerateAnswer();
        void SetContent(string[] content);
        Board GetResult();
    }
}