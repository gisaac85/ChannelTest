using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharedLogic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var top = 3;            
            Assert.AreEqual(top, ConsoleLogic.GetTopProducts(top));          
        }

        [TestMethod]
        public void TestMethod2()
        {
            var top = ConsoleLogic.GetTopProducts(4);
            Assert.IsNotNull(top);
        }
    }
}
