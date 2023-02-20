using System;
using NUnit.Framework;
using sudoku.Builder;
using sudoku.Builder.BuilderType;
using sudoku.Models;
using sudoku.SudokuBoard;

namespace Tests
{
    [TestFixture]
    public class BuilderTests
    {
        [Test]
        public void GetCorrectBuilder()
        {
            var factory = new SudokuBuilderFactory();
            var builder = factory.GetBuilder(SudokuType._4x4);

            Assert.IsInstanceOf(typeof(_4x4Builder), builder);
        }

        [Test]
        public void ReturnsCorrectGenericSudoku()
        {
            var _4x4 = new[]
            {
                "0340400210030210"
            };
            var builder = new _4x4Builder();
            builder.SetContent(_4x4);
            builder.BuildSudoku();

            var result = builder.GetResult();

            Assert.AreEqual(4, result.Regions.GetCount());

            for (var i = 0; i < result.Regions.GetCount(); i++)
            {
                var temp = result.Regions.Get(i);
                Assert.AreEqual(4, temp.GetCount());
            }
        }

        [Test]
        public void ReturnsCorrectSamuraiSudoku()
        {
            var samurai = new[]
            {
                "000814392000090001000003008200000104370000059504000006700200000900070000825369000",
                "462185000100070000700400000206000003350000016900000208000002005000050001000861497",
                "000402000000307000000080000750000096006000200280000014000030000000701000000605000",
                "374816000800090000600400000703000009210000063900000807000009001000020006000648725",
                "000394852000060003000005009300000401270000085605000007700900000800020000596437000",
            };
            var builder = new SamuraiBuilder();
            builder.SetContent(samurai);
            builder.BuildSudoku();

            var result = builder.GetResult();

            Assert.AreEqual(41, result.Regions.GetCount());

            for (var i = 0; i < result.Regions.GetCount(); i++)
            {
                var temp = result.Regions.Get(i);
                Assert.AreEqual(9, temp.GetCount());
            }
        }

        [Test]
        public void ReturnsCorrectJigsawSudoku()
        {
            var jigsaw = new[]
            {
                "SumoCueV1=0J0=8J0=0J0=0J1=0J2=0J2=0J2=5J2=0J2=8J3=0J0=0J1=0J1=0J2=7J2=0J4=0J4=5J4=0J3=0J0=0J1=0J1=9J2=0J2=0J5=0J6=0J4=0J3=7J0=0J1=1J1=6J5=9J5=0J5=0J6=0J4=0J3=0J0=4J1=3J1=0J5=1J7=8J7=0J6=0J4=0J3=0J0=0J5=8J5=7J5=6J7=0J7=3J6=0J4=0J3=0J0=0J5=0J8=5J8=0J7=0J7=0J6=0J4=3J3=0J3=0J3=6J8=0J8=0J7=0J7=0J6=2J4=0J8=9J8=0J8=0J8=0J8=0J7=0J6=8J6=0J6"
            };
            var builder = new JigsawBuilder();
            builder.SetContent(jigsaw);
            builder.BuildSudoku();

            var result = builder.GetResult();

            Assert.AreEqual(9, result.Regions.GetCount());

            for (var i = 0; i < result.Regions.GetCount(); i++)
            {
                var temp = result.Regions.Get(i);
                Assert.AreEqual(9, temp.GetCount());
            }
        }
    }
}