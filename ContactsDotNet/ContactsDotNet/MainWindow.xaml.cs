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
                var writer = new StreamWriter(fileDialog.FileName);
                foreach (var x in App.Repository)
                {
                    writer.WriteLine(x.ToCsv());
                }
                writer.Close();
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
                RenderList();
            }
        }

        private void NewContact_Click(object sender, RoutedEventArgs e)
        {
            var editContactWindow = new EditContactWindow(this, App.Repository);
            editContactWindow.Show();
        }

        public void RenderList()
        {
            ContactsList.Items.Clear();
            foreach (var x in App.Repository)
            {
                ContactsList.Items.Add(x);
            }
           
        }

        private void ContactsList_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var index = (sender as ListView).SelectedIndex;
            if (index == -1)
                return;

            var contact = App.Repository.Find(index+1);
            var contactWindow = new ContactWindow(this, contact);
            contactWindow.Show();
        }
    }
}
