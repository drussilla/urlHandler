using Microsoft.VisualStudio.TestTools.UnitTesting;
using urlHandler.Common.Configuration;

namespace urlHandler.Common.UnitTest.Configuration
{
    [TestClass]
    public class RuleElementTest
    {
        [TestMethod]
        public void ToUrlStringAllFilledTest()
        {
            var expected = "http://insite";

            var target = new RuleElement();
            target.Protocol = "http";
            target.Pattern = "^insite(/.*)?$";

            var actual = target.ToUrlString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RuleElementCtorUrlTest()
        {
            var expectedProtocol = "http";
            var expectedPattern = "^test.ru(/.*)?$";
            var initValue = "http://test.ru";
            
            var target = new RuleElement(initValue);

            Assert.AreEqual(expectedPattern, target.Pattern);
            Assert.AreEqual(expectedProtocol, target.Protocol);
        }
    }
}
