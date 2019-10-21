using System;
using AntsUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AntsUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddTest()
        {
            int a = 10;
            int b = 20;
            Assert.AreEqual(FileUtils.Add(a, b), 30);
        }
    }
}
