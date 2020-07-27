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

    }
}
