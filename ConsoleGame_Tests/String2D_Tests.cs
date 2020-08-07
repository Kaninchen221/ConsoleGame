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
            String.DefaultChar = '_';
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
        public void ReplaceAt_CharTest()
        {
            var Size = new Vector2i(10, 10);
            var String = GetDefaultString(Size);

            var Position = new Vector2i(5, 5);
            char ExpectedChar = '*';
            
            String.ReplaceAt(ExpectedChar, Position);

            Assert.AreEqual(ExpectedChar, String.At(Position));
        }

        [TestMethod]
        public void ReplaceAt_StringTest()
        {
            var Size = new Vector2i(10, 10);
            var String2D = GetDefaultString(Size);
            var String = new string("*_*_*_*");
            var Position = new Vector2i(2, 3);
            var ExpectedLine = new string("__*_*_*_*_");

            String2D.ReplaceAt(String, Position);
            
            var Line = String2D.GetLine(3);
            Assert.AreEqual(ExpectedLine, Line);
        }

        [TestMethod]
        public void GetIndex_Test()
        {
            var Size = new Vector2i(4, 10);
            var String2D = GetDefaultString(Size);

            int Index = String2D.GetIndex(new Vector2i(2, 4));
            int ExpectedIndex = 18;

            Assert.AreEqual(ExpectedIndex, Index);
        }

        [TestMethod]
        public void IsPositionValid_Test()
        {
            var Size = new Vector2i(5, 10);
            var String = GetDefaultString(Size);

            var InvalidMinusPosition = new Vector2i(-1, -1);
            var ZeroPosition = new Vector2i(0, 0);
            var TopPosition = new Vector2i(4, 9);
            var InvalidOutOfRangePosition = new Vector2i(5, 10);

            Assert.IsFalse(String.IsPositionValid(InvalidMinusPosition));
            Assert.IsTrue(String.IsPositionValid(ZeroPosition));
            Assert.IsTrue(String.IsPositionValid(TopPosition));
            Assert.IsFalse(String.IsPositionValid(InvalidOutOfRangePosition));
        }

        [TestMethod]
        public void GetLine_Test()
        {
            var Size = new Vector2i(5, 10);
            var String = GetDefaultString(Size);
            String.ReplaceAt('*', new Vector2i(3, 4));
            String.ReplaceAt('*', new Vector2i(2, 5));

            var CorrectLine = String.GetLine(4);
            Assert.AreEqual("___*_", CorrectLine);

            CorrectLine = String.GetLine(5);
            Assert.AreEqual("__*__", CorrectLine);
        }

        [TestMethod]
        public void IsLineValid_Test()
        {
            var Size = new Vector2i(5, 10);
            var String = GetDefaultString(Size);

            Assert.IsFalse(String.IsLineValid(-1));
            Assert.IsTrue(String.IsLineValid(0));
            Assert.IsTrue(String.IsLineValid(1));
            Assert.IsTrue(String.IsLineValid(9));
            Assert.IsFalse(String.IsLineValid(10));
            Assert.IsFalse(String.IsLineValid(11));
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

        [TestMethod]
        public void Foreach_Test()
        {
            var String2D = new String2D();
            
            var String = new string("xx_xx x_x_x _xxx_ x_x_x xx_xx");
            String2D.FromString(String, ' ');

            var ExpectedString = new string("xx_xxx_x_x_xxx_x_x_xxx_xx");
            var ExpectedChar = ExpectedString.GetEnumerator();
            ExpectedChar.MoveNext();

            int ExpectedIndex = 0;

            String2D.Foreach((char String2DChar, Vector2i Position) =>
            {
                bool CharsAreSame = (String2DChar == ExpectedChar.Current);

                int Index = String2D.GetIndex(Position);
                bool IndexesAreSame = (Index == ExpectedIndex);
                
                Assert.IsTrue(CharsAreSame);
                Assert.IsTrue(IndexesAreSame);

                ExpectedIndex += 1;
                ExpectedChar.MoveNext();
            });
        }
    }
}
