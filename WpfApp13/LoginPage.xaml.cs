using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp13
{
    public partial class LoginPage : Page
    {
        public int failedAttempts = 0;
        public string captchaText; // Изменен уровень доступа на public

        public LoginPage()
        {
            InitializeComponent();
        }

        public void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            if (failedAttempts >= 3)
            {
                if (CaptchaCheck())
                {
                    Auth(loginText.Text, passwordText.Password);
                }
                else
                {
                    MessageBox.Show("Неверная капча!");
                    return;
                }
            }
            else
            {
                Auth(loginText.Text, passwordText.Password);
            }
        }

        public bool Auth(string login, string password) // Изменен уровень доступа на public
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль!");
                return false;
            }

            using (var db = new KyrcovaEntities3())
            {
                var user = db.Students.FirstOrDefault(u => u.Login == login);
                if (user != null && user.Password == MainWindow.GetHash(password))
                {
                    var mainWindow = Window.GetWindow(this) as MainWindow;
                    mainWindow.MainFrame.Navigate(new AdminPage());
                    failedAttempts = 0; // Сброс счетчика неудачных попыток
                    return true;
                }
                else
                {
                    failedAttempts++;
                    if (failedAttempts >= 3)
                    {
                        GenerateCaptcha();
                    }
                    MessageBox.Show("Неверный логин или пароль!");
                    return false;
                }
            }
        }

        public void GenerateCaptcha()
        {
            Random rand = new Random();
            int num1 = rand.Next(10, 99);
            int num2 = rand.Next(10, 99);
            captchaText = (num1 + num2).ToString();
            CaptchaLabel.Text = $"{num1} + {num2} = ?";
            CaptchaLabel.Visibility = Visibility.Visible;
            CaptchaTextBox.Visibility = Visibility.Visible;
        }

        public bool CaptchaCheck()
        {
            return CaptchaTextBox.Text == captchaText;
        }

        public void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.MainFrame.Navigate(new SignUpPage());
        }
    }
}
