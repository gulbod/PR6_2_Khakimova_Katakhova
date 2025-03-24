using System.Windows;

namespace WpfApp13
{
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new AdminPage());
        }
    }
}
