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
        public void ReplaceAt_CharTest()
        {
            string String = new string("01234 6789");
            String = String.ReplaceAt('5', 5);

            Assert.AreEqual('5', String[5]);
        }

        [TestMethod]
        public void ReplaceAt_StringTest()
        {
            string String = new string("0123   789");
            string Input = new string("456");

            var NewString = String.ReplaceAt(Input, 4);

            Assert.AreEqual(Input, NewString.Substring(4, 3));
        }
    }
}
