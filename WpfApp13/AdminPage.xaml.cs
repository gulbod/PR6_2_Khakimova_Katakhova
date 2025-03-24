using System.Linq;
using System.Windows.Controls;
using System.Windows;

namespace WpfApp13
{
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            using (var db = new KyrcovaEntities3())
            {
                var users = db.Students.Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Login,
                    u.Password,
                    u.Phone
                }).ToList();
                usersDataGrid.ItemsSource = users;
            }
        }

        private void NavigateToGrades(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.MainFrame.Navigate(new GradesPage());
        }

        private void NavigateToCourses(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.MainFrame.Navigate(new CoursesPage());
        }

        private void NavigateToSessions(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.MainFrame.Navigate(new SessionsPage());
        }

        private void NavigateToDepartments(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.MainFrame.Navigate(new DepartmentsPage());
        }

        private void NavigateToTeachers(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.MainFrame.Navigate(new TeachersPage());
        }
    }
}
