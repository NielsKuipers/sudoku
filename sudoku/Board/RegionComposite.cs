using System.Collections.Generic;

namespace sudoku.Board
{
    public abstract class RegionComposite : IRegion
    {
        private List<IRegion> children = new List<IRegion>();
        
        public void isValid()
        {
            throw new System.NotImplementedException();
        }
    }
}