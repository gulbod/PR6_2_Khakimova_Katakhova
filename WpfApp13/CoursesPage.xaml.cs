using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp13
{
    public partial class CoursesPage : Page
    {
        public CoursesPage()
        {
            InitializeComponent();
            LoadCourses();
        }

        private void LoadCourses()
        {
            using (var db = new KyrcovaEntities3())
            {
                var courses = db.Courses.ToList();
                coursesDataGrid.ItemsSource = courses;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.MainFrame.Navigate(new AdminPage());
        }
    }
}
