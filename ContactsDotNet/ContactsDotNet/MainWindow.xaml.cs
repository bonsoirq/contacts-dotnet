using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Application;

namespace ContactsDotNet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Application.Application App { get; protected set; } = new Application.Application();

        public MainWindow()
        {
            InitializeComponent();
            ContactsList.ItemsSource = App.Repository;
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Kontakty ⓒ 2019 Jarosław Bąk & Maksymilian Galas", "O aplikacji");
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new SaveFileDialog();
            fileDialog.AddExtension = true;
            fileDialog.FileName = "kontakty";
            fileDialog.DefaultExt = "cnt";
            if (fileDialog.ShowDialog(this) == true)
            {
                File.Create(fileDialog.FileName);
            }
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog(this) == true)
            {
                var reader = new StreamReader(fileDialog.FileName);
                string csv = reader.ReadLine();
                while (csv != null)
                {
                    App.Repository.Add(Application.Contact.Parse(csv));
                    csv = reader.ReadLine();
                }
                reader.Close();
            }
        }

        private void NewContact_Click(object sender, RoutedEventArgs e)
        {
            var contactWindow = new EditContactWindow(App.Repository);
            contactWindow.Show();
        }
    }
}
