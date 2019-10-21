using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReviewCSharp.volatilelearn;

namespace UnitTestReviewCSharp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestWorkerThreadExample()
        {
            WorkerThreadExample.MainTest();
        }
    }
}
