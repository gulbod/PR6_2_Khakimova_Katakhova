using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp13; 

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void AuthTestSuccess()
        {
            var page = new AuthPage();

            Assert.IsTrue(page.Auth("testLogin1", "testPassword1"));
            Assert.IsTrue(page.Auth("testLogin2", "testPassword2"));
            Assert.IsTrue(page.Auth("testLogin3", "testPassword3"));
        }
    }
}
