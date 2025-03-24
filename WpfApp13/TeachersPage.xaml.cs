using System;
using System.Collections.ObjectModel; // Добавьте эту строку
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace WpfApp13
{
    public partial class TeachersPage : Page
    {
        private ObservableCollection<Teachers> teachers; // Измените на ObservableCollection

        public TeachersPage()
        {
            InitializeComponent();
            LoadTeachers();
        }

        private void LoadTeachers()
        {
            using (var db = new KyrcovaEntities3())
            {
                teachers = new ObservableCollection<Teachers>(db.Teachers.ToList());
                teachersDataGrid.ItemsSource = teachers; // Убедитесь, что вы используете teachers
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                mainWindow.MainFrame.Navigate(new AdminPage());
            }
        }

        private void AddPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            if (teachersDataGrid.SelectedItem is Teachers selectedTeacher)
            {
                var openFileDialog = new OpenFileDialog
                {
                    Filter = "Image Files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp"
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    string photoPath = openFileDialog.FileName;
                    string destinationPath = Path.Combine(Environment.CurrentDirectory, "Photos", Path.GetFileName(photoPath));

                    if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Photos")))
                    {
                        Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Photos"));
                    }

                    File.Copy(photoPath, destinationPath, true);

                    using (var db = new KyrcovaEntities3())
                    {
                        selectedTeacher.PhotoPath = destinationPath;
                        db.SaveChanges();
                    }

                   
                    teachersDataGrid.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите преподавателя для добавления фото.");
            }
        }
    }

    public class PathToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string path && File.Exists(path))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(path);
                image.CacheOption = BitmapCacheOption.OnLoad; 
                image.EndInit();
                image.Freeze(); 
                return image;
            }
            return null; 
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null; 
        }
    }
}
