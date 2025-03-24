using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp13; // Замените на правильное пространство имен для Entities


namespace UnitTestProject
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void AuthTest()
        {
            var page = new AuthPage();
            Assert.IsTrue(page.Auth("test", "test"));
            Assert.IsFalse(page.Auth("user1", "12345"));
            Assert.IsFalse(page.Auth("", ""));
            Assert.IsFalse(page.Auth(" ", " "));
        }
    }

    public class AuthPage
    {
        public TextBox TextBoxLogin { get; set; }
        public PasswordBox PasswordBox { get; set; }

        public AuthPage()
        {
            TextBoxLogin = new TextBox();
            PasswordBox = new PasswordBox();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            Auth(TextBoxLogin.Text, PasswordBox.Password);
        }

        public bool Auth(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль!");
                return false;
            }

            using (var db = new KyrcovaEntities3())
            {
                var user = db.Students.AsNoTracking().FirstOrDefault(u => u.Login == login && u.Password == password);
                if (user == null)
                {
                    MessageBox.Show("Пользователь с такими данными не найден!");
                    return false;
                }
            }

            MessageBox.Show("Пользователь успешно найден!");
            TextBoxLogin.Clear();
            PasswordBox.Clear();
            return true;
        }
    }
}
