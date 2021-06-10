using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace sudoku.Board
{
    public abstract class RegionComposite : IRegion
    {
        private List<IRegion> _children = new List<IRegion>();

        protected RegionComposite(params IRegion[] children)
        {
            foreach (var child in children)
            {
                _children.Add(child);
            }
        }
        
        public bool IsValid()
        {
            return true;
        }

        // public IEnumerable<int> GetValues()
        // {
        //     return _children.Select(child => child.IsValid()).ToList();
        // }
    }
}