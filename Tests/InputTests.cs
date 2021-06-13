using System.Collections.Generic;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Media;
using NUnit.Framework;
using sudoku.Models;
using sudoku.States;
using sudoku.SudokuBoard;

namespace Tests
{
    [TestFixture]
    [Apartment(ApartmentState.STA)]
    public class InputTests
    {
        [Test]
        public void FactoryGetsCorrectInput()
        {
            var factory = new InputStateFactory();
            var state = factory.GetState("normal");
            
            Assert.IsInstanceOf(typeof(NormalInputState), state);
        }
        
        [Test]
        public void NormalInputChangesValue()
        {
            var region = new RegionComposite {Value = 0, DraftNumbers = new List<int>()};
            var input = new NormalInputState(new InputStateFactory());
            var label = new Label {Content = "4"};
            var draftLabel = new Label {Content = "123"};

            input.HandleInput(region, 2, label, draftLabel);

            Assert.AreEqual(2, region.Value);
            Assert.AreEqual(2, label.Content);
        }

        [Test]
        public void NormalInputRemovesSameValue()
        {
            var region = new RegionComposite {Value = 2, DraftNumbers = new List<int>()};
            var input = new NormalInputState(new InputStateFactory());
            var label = new Label {Content = "4"};
            var draftLabel = new Label {Content = "123"};

            input.HandleInput(region, 2, label, draftLabel);

            Assert.AreEqual(0, region.Value);
            Assert.AreEqual("", label.Content);
        }

        [Test]
        public void NormalInputRemovesDraft()
        {
            var region = new RegionComposite {Value = 4, DraftNumbers = new List<int> {1, 2, 4}};
            var input = new NormalInputState(new InputStateFactory());
            var label = new Label {Content = "4"};
            var draftLabel = new Label {Content = "123"};

            input.HandleInput(region, 2, label, draftLabel);

            Assert.IsEmpty(region.DraftNumbers);
            Assert.AreEqual("", draftLabel.Content);
        }

        [Test]
        public void DraftInputAddsValue()
        {
            var region = new RegionComposite {Value = 0, DraftNumbers = new List<int> {1, 2, 3}};
            var input = new DraftInputState(new InputStateFactory());
            var label = new Label {Content = "4"};
            var draftLabel = new Label {Content = "123"};

            input.HandleInput(region, 4, label, draftLabel);

            Assert.Contains(4, region.DraftNumbers);
            Assert.AreEqual("1234", draftLabel.Content);
        }
        
        [Test]
        public void DraftInputRemovesValue()
        {
            var region = new RegionComposite {Value = 0, DraftNumbers = new List<int> {1, 2, 3}};
            var input = new DraftInputState(new InputStateFactory());
            var label = new Label {Content = "4"};
            var draftLabel = new Label {Content = "123"};

            input.HandleInput(region, 3, label, draftLabel);

            Assert.AreEqual(new List<int>{1, 2}, region.DraftNumbers);
            Assert.AreEqual("12", draftLabel.Content);
        }
        
        [Test]
        public void DraftInputDoesNotAddWithValue()
        {
            var region = new RegionComposite {Value = 2, DraftNumbers = new List<int>()};
            var input = new DraftInputState(new InputStateFactory());
            var label = new Label {Content = "4"};
            var draftLabel = new Label {Content = ""};

            input.HandleInput(region, 4, label, draftLabel);

            Assert.IsEmpty(region.DraftNumbers);
            Assert.AreEqual("", draftLabel.Content);
        }

        [Test]
        public void CheatInputReturnsCorrectOrWrong()
        {
            var region = new RegionComposite {Value = 2, DraftNumbers = new List<int>(), Answer = 3};
            var input = new CheatInputState(new InputStateFactory());
            var label = new Label {Content = "2"};
            var draftLabel = new Label {Content = ""};

            input.HandleInput(region, 3, label, draftLabel);
            Assert.AreEqual(Brushes.Green, label.Background);
            
            input.HandleInput(region, 4, label, draftLabel);
            Assert.AreEqual(Brushes.Red, label.Background);
        }
    }
}