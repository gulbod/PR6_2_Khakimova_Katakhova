using System.Windows;
using System.Windows.Controls;

namespace WpfApp13
{
    public partial class UserPage : Page
    {
        private readonly Students _Students;

        public UserPage(Students students)
        {
            InitializeComponent();
            _Students = students;
            DataContext = _Students;

            firstNameText.Text = _Students.FirstName ?? string.Empty;
            lastNameText.Text = _Students.LastName ?? string.Empty;
            loginText.Text = _Students.Login ?? string.Empty;
            passwordText.Text = _Students.Password ?? string.Empty;
            phoneText.Text = _Students.Phone ?? string.Empty;
        }
    }
}
