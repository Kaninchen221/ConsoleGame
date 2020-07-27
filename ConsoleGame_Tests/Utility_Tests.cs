using ConsoleGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame_Tests
{
    [TestClass]
    public class Utility_Tests
    {
        [TestMethod]
        public void ReplaceAt_Test()
        {
            string String = new string("01234 6789");
            String = String.ReplaceAt('5', 5);

            Assert.AreEqual('5', String[5]);
        }

    }
}
