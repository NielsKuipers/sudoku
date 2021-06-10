namespace sudoku.Board
{
    public class ColumnComposite : RegionComposite
    {
        public ColumnComposite(params IRegion[] children) : base(children)
        {
        }
    }
}