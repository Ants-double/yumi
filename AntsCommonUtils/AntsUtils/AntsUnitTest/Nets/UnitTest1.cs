using System;
using AntsUtils.Nets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AntsUnitTest.Nets
{
    [TestClass]
    public class NetsTest1
    {
        [TestMethod]
        public void TestSendEmail()
        {
            Assert.AreEqual(NetHelper.SendEmail("", "title", "helloword", false), true);
        }
    }
}
