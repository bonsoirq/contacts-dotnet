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

namespace ContactsDotNet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Kontakty ⓒ 2019 Jarosław Bąk & Maksymilian Galas", "O aplikacji");
        }

        private void NewFile_Click(object sender, RoutedEventArgs e)
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
                var stream = new FileStream(fileDialog.FileName, FileMode.Open);
                var reader = new StreamReader(stream);
                var contactsData = new List<string>();
                while (reader.ReadLine() != null)
                {
                    contactsData.Add(reader.ReadLine());
                }
                reader.Close();
            }
        }
    }
}
