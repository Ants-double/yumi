using System;
using System.Text;
using AntsUtils.Dates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AntsUnitTest.Dates
{
    [TestClass]
    public class DatesTest1
    {
        [TestMethod]
        public void TestConvertDateTime()
        {
            DateTime dt = new DateTime(2018, 06, 25, 11, 33, 52);
            Assert.AreEqual(TimeStampHelper.ConvertDateTime(dt),"1529897632");
        }
        [TestMethod]
        public void TestStrToHexByte()
        {
            string hs = "0x7133";
            string res = HexHelper.StringToHexString(hs, Encoding.UTF8);
            byte[] resByte = HexHelper.StringToHexByte(res);
            string resHex = HexHelper.ByteToHexString(resByte);
            string strRes = HexHelper.HexStringToString(resHex, Encoding.UTF8);
            Assert.AreEqual(HexHelper.HexStringConvertDecimal(hs), 28979);
        }

    }
}
