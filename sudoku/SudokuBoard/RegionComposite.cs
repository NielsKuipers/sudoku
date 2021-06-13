using System.Collections.Generic;

namespace sudoku.SudokuBoard
{
    public class RegionComposite : Region
    {
        protected readonly List<Region> _children = new List<Region>();

        public override void Add(Region region)
        {
            _children.Add(region);
        }

        public override void Remove(Region region)
        {
            _children.Remove(region);
        }

        public override void RemoveAt(int pos)
        {
            _children.RemoveAt(pos);
        }

        public override Region Get(int childNumber)
        {
            return _children[childNumber];
        }

        public override int GetCount()
        {
            return _children.Count;
        }
    }
}