namespace sudoku.Board
{
    public class Cell : IRegion
    {
        private int Value { get; }

        public Cell(int val)
        {
            Value = val;
        }
        
        public void isValid()
        {
            throw new System.NotImplementedException();
        }
    }
}