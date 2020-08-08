using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame_Tests
{
    [TestClass]
    public class Vector2i_Tests
    {

        [TestMethod]
        public void CompareTo_Test()
        {
            var First = new ConsoleGame.Vector2i(4, 7);
            var Second = new ConsoleGame.Vector2i(4, 7);
            var Third = new ConsoleGame.Vector2i(2, 7);

            Assert.IsTrue(First.CompareTo(Second));
            Assert.IsFalse(Second.CompareTo(Third));
        }

        [TestMethod]
        public void Addition_Test()
        {
            var Vec1 = new ConsoleGame.Vector2i(2, 4);
            var Vec2 = new ConsoleGame.Vector2i(4, 8);

            var ExpectedVec = new ConsoleGame.Vector2i(6, 12);
            var AdditionResult = Vec1 + Vec2;

            Assert.IsTrue(ExpectedVec.CompareTo(AdditionResult));
        }

        [TestMethod]
        public void Subtraction_Test()
        {
            var Vec1 = new ConsoleGame.Vector2i(2, 32);
            var Vec2 = new ConsoleGame.Vector2i(4, 8);

            var ExpectedVec = new ConsoleGame.Vector2i(-2, 24);
            var SubtractionResult = Vec1 - Vec2;

            Assert.IsTrue(ExpectedVec.CompareTo(SubtractionResult));
        }
    }
}
