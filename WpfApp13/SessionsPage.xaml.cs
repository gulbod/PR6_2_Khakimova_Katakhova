using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp13
{
    public partial class SessionsPage : Page
    {
        public SessionsPage()
        {
            InitializeComponent();
            LoadSessions();
        }

        private void LoadSessions()
        {
            using (var db = new KyrcovaEntities3())
            {
                var sessions = db.Sessions.ToList();
                sessionsDataGrid.ItemsSource = sessions;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.MainFrame.Navigate(new AdminPage());
        }
    }
}
