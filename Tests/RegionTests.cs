using NUnit.Framework;
using sudoku.SudokuBoard;

namespace Tests
{
    [TestFixture]
    public class RegionTests
    {
        [Test]
        public void CanAddToRegion()
        {
            var region = new RegionComposite();
            var region2 = new RegionComposite();
            
            region.Add(region2);

            Assert.AreSame(region2, region.Get(0));
        }
        
        [Test]
        public void CanRemoveFromRegion()
        {
            var region = new RegionComposite();
            var region2 = new RegionComposite();
            
            region.Add(region2);
            region.Remove(region2);
            Assert.AreEqual(0, region.GetCount());
            
            region.Add(region2);
            region.RemoveAt(0);
            Assert.AreEqual(0, region.GetCount());
        }
    }
}