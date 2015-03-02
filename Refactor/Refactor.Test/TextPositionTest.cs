using System;
using Refactor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Refactor.Test
{
    [TestClass]
    public class TextPositionTest
    {
        [TestMethod]
        public void TestEquality()
        {
            var textPos1 = new TextPosition(1, 1);
            var textPos2 = new TextPosition(1, 1);

            Assert.AreEqual(textPos1, textPos2);
        }
    }
}
