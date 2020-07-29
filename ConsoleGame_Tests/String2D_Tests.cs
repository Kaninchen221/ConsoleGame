using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleGame;

namespace ConsoleGame_Tests
{
    [TestClass]
    public class String2D_Tests
    {
        ConsoleGame.String2D GetDefaultString(Vector2i Size)
        {
            ConsoleGame.String2D String = new ConsoleGame.String2D();
            String.Resize(Size);

            return String;
        }

        [TestMethod]
        public void Resize_Test()
        {
            var Size = new Vector2i(10, 10);
            var String = GetDefaultString(Size);

            Assert.IsTrue(Size.CompareTo(String.Size));
        }

        [TestMethod]
        public void Clear_Test()
        {
            var Size = new Vector2i(10, 10);
            var String = GetDefaultString(Size);

            var ExpectedSize = new Vector2i(0, 0);
            String.Clear();

            Assert.IsTrue(ExpectedSize.CompareTo(String.Size));

        }

        [TestMethod]
        public void IsSizeValid_Test()
        {
            var ValidSize = new Vector2i(3, 8);
            var InvalidSize = new Vector2i(-1, -1);
            
            Assert.IsTrue(
                ConsoleGame.String2D.IsSizeValid(ValidSize));

            Assert.IsFalse(
                ConsoleGame.String2D.IsSizeValid(InvalidSize));
        }

        [TestMethod]
        public void At_Test()
        {
            var Size = new Vector2i(10, 10);
            var String = GetDefaultString(Size);

            var Position = new Vector2i(5, 5);
            char ExpectedChar = '*';

            String.ReplaceAt(ExpectedChar, Position);

            Assert.AreEqual(ExpectedChar, String.At(Position));
        }

        [TestMethod]
        public void ReplaceAt_Test()
        {
            var Size = new Vector2i(10, 10);
            var String = GetDefaultString(Size);

            var Position = new Vector2i(5, 5);
            char ExpectedChar = '*';
            
            String.ReplaceAt(ExpectedChar, Position);

            Assert.AreEqual(ExpectedChar, String.At(Position));
        }

        [TestMethod]
        public void FromString_Test()
        {
            var String = new string("***\n***\n");
            var ExpectedString = new string("******");
            var ExpectedSize = new Vector2i(3, 2);
            var String2D = new ConsoleGame.String2D();

            String2D.FromString(String, '\n');

            Assert.AreEqual(ExpectedString, String2D.Data);
            Assert.IsTrue(ExpectedSize.CompareTo(String2D.Size));
        }

        [TestMethod]
        public void Clone_Test()
        {
            var Size = new Vector2i(10, 10);
            var String = GetDefaultString(Size);

            var CopyOfString = (String2D)String.Clone();

            Assert.AreEqual(String.Data, CopyOfString.Data);
            Assert.AreEqual(String.DefaultChar, CopyOfString.DefaultChar);
            Assert.IsTrue(String.Size.CompareTo(CopyOfString.Size));

            CopyOfString.ReplaceAt('*', new Vector2i(2, 2));
            CopyOfString.DefaultChar = '8';

            Assert.AreNotEqual(String.Data, CopyOfString.Data);
            Assert.AreNotEqual(String.DefaultChar, CopyOfString.DefaultChar);
            Assert.IsTrue(String.Size.CompareTo(CopyOfString.Size));
        }

    }
}
