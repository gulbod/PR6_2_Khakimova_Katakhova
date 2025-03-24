using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp13;

namespace UnitTestProject
{
    [TestClass]
    public class RegistrationTests
    {
        [TestMethod]
        public void RegisterTest_Success()
        {
            var page = new SignUpPage();
            Assert.IsTrue(page.Register("New", "User", "newUser", "newPassword", "123456789", "newuser@example.com")); // Успешная регистрация
        }

        [TestMethod]
        public void RegisterTest_EmptyLogin()
        {
            var page = new SignUpPage();
            Assert.IsFalse(page.Register("New", "User", "", "validPassword", "123456789", "valid@example.com")); // Пустой логин
        }

        [TestMethod]
        public void RegisterTest_EmptyPassword()
        {
            var page = new SignUpPage();
            Assert.IsFalse(page.Register("New", "User", "validLogin", "", "123456789", "valid@example.com")); // Пустой пароль
        }

        [TestMethod]
        public void RegisterTest_DuplicateLogin()
        {
            var page = new SignUpPage();
            page.Register("Existing", "User", "existingUser", "existingPassword", "123456789", "existing@example.com"); // Создаем пользователя
            Assert.IsFalse(page.Register("New", "User", "existingUser", "newPassword", "123456789", "new@example.com")); // Повторная регистрация с тем же логином
        }
    }
}
