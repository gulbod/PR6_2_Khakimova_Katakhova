using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp13
{
    public partial class DepartmentsPage : Page
    {
        public DepartmentsPage()
        {
            InitializeComponent();
            LoadDepartments();
        }

        private void LoadDepartments()
        {
            using (var db = new KyrcovaEntities3())
            {
                var departments = db.Departments.ToList();
                departmentsDataGrid.ItemsSource = departments;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.MainFrame.Navigate(new AdminPage());
        }
    }
}
