namespace sudoku.Board
{
    public class BlockComposite : RegionComposite
    {
        public BlockComposite(params IRegion[] children) : base(children)
        {
        }
    }
}