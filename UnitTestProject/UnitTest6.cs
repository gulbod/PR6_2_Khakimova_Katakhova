using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;
using WpfApp13;

namespace UnitTestProject
{
    [TestClass]
    public class CaptchaTests
    {
        [TestMethod]
        public void CaptchaTest_DisplayAfterThreeFailures()
        {
            var page = new LoginPage();

            
            page.Auth("invalidLogin", "invalidPassword");
            page.Auth("invalidLogin", "invalidPassword");
            page.Auth("invalidLogin", "invalidPassword");

           
            Assert.AreEqual(Visibility.Visible, page.CaptchaLabel.Visibility);
            Assert.AreEqual(Visibility.Visible, page.CaptchaTextBox.Visibility);
        }

        [TestMethod]
        public void CaptchaTest_CorrectCaptcha()
        {
            var page = new LoginPage();

           
            page.Auth("invalidLogin", "invalidPassword");
            page.Auth("invalidLogin", "invalidPassword");
            page.Auth("invalidLogin", "invalidPassword");

            
            page.GenerateCaptcha();

            
            page.CaptchaTextBox.Text = page.captchaText;

           
            Assert.IsTrue(page.CaptchaCheck());
        }

        [TestMethod]
        public void CaptchaTest_IncorrectCaptcha()
        {
            var page = new LoginPage();

           
            page.Auth("invalidLogin", "invalidPassword");
            page.Auth("invalidLogin", "invalidPassword");
            page.Auth("invalidLogin", "invalidPassword");

            
            page.GenerateCaptcha();

            
            page.CaptchaLabel.Text = "incorrect";

            
            Assert.IsFalse(page.CaptchaCheck());
        }

        [TestMethod]
        public void CaptchaTest_ResetAfterSuccessfulAuth()
        {
            var page = new LoginPage();

            
            page.Auth("invalidLogin", "invalidPassword");
            page.Auth("invalidLogin", "invalidPassword");
            page.Auth("invalidLogin", "invalidPassword");

            
            page.Auth("validLogin", "validPassword");

            
            Assert.AreEqual(Visibility.Collapsed, page.CaptchaLabel.Visibility);
            Assert.AreEqual(Visibility.Collapsed, page.CaptchaTextBox.Visibility);
        }
    }
}
