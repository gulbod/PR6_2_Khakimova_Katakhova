using System.Linq;
using System.Windows.Controls;
using System.Windows;



namespace WpfApp13
{
    public partial class GradesPage : Page
    {
        public GradesPage()
        {
            InitializeComponent();
            LoadGrades();
        }

        private void LoadGrades()
        {
            using (var db = new KyrcovaEntities3())
            {
                var grades = db.Grades.ToList();
                gradesDataGrid.ItemsSource = grades;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.MainFrame.Navigate(new AdminPage());
        }
    }
}
