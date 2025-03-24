using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp13; // Замените на правильное пространство имен для вашего проекта

namespace UnitTestProject
{
    [TestClass]
    public class NegativeAuthTests
    {
        [TestMethod]
        public void AuthTest_EmptyLogin()
        {
            var page = new AuthPage();
            Assert.IsFalse(page.Auth("", "validPassword")); 
        }

        [TestMethod]
        public void AuthTest_EmptyPassword()
        {
            var page = new AuthPage();
            Assert.IsFalse(page.Auth("validLogin", "")); 
        }

        [TestMethod]
        public void AuthTest_InvalidLogin()
        {
            var page = new AuthPage();
            Assert.IsFalse(page.Auth("invalidLogin", "validPassword")); 
        }

        [TestMethod]
        public void AuthTest_InvalidPassword()
        {
            var page = new AuthPage();
            Assert.IsFalse(page.Auth("validLogin", "invalidPassword")); 
        }

        [TestMethod]
        public void AuthTest_BothEmpty()
        {
            var page = new AuthPage();
            Assert.IsFalse(page.Auth("", "")); 
        }
    }
}
