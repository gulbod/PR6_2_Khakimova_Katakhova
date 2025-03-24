using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp13
{
    public partial class SignUpPage : Page
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            string firstName = firstNameText.Text;
            string lastName = lastNameText.Text;
            string login = loginText.Text;
            string password = passwordText.Text;
            string phone = phoneText.Text;
            string email = emailText.Text;

            Register(firstName, lastName, login, password, phone, email);
        }

        public bool Register(string firstName, string lastName, string login, string password, string phone, string email)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль!");
                return false;
            }

            using (var db = new KyrcovaEntities3())
            {
                if (db.Students.Any(u => u.Login == login))
                {
                    MessageBox.Show("Пользователь с таким логином уже существует!");
                    return false;
                }

                var newUser = new Students
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Login = login,
                    Password = MainWindow.GetHash(password),
                    Phone = phone,
                    Email = email
                };

                db.Students.Add(newUser);
                db.SaveChanges();
            }

            MessageBox.Show("Регистрация успешна!");
            return true;
        }
    }
}
