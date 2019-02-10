using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Application;

namespace ContactsDotNet
{
    /// <summary>
    /// Interaction logic for ContactWindow.xaml
    /// </summary>
    public partial class ContactWindow : Window
    {
        private Contact contact;
        private object parent;

        public ContactWindow(object parent, Contact contact)
        {
            InitializeComponent();

            this.contact = contact;
            this.parent = parent;

            this.ReloadContact();
        }

        public void ReloadContact()
        {
            if (contact.Name.Length > 0)
            {
                var name = contact.Name.Split(' ')[0];
                this.Title = name;
            }
            else
            {
                this.Title = "Kontakt";
            }

            NameLabel.Content = contact.Name;
            PositionLabel.Content = contact.Position;
            NumberLabel.Content = contact.PhoneNumber;
            EmailLabel.Content = contact.Email;
            WebsiteLabel.Content = contact.Website;
            AddressLabel.Content = contact.Address;
            NotesLabel.Content = contact.Notes;

            var parent = (this.parent as MainWindow);
            if (parent != null)
            {
                parent.RenderList();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var contactWindow = new EditContactWindow(this, contact);
            contactWindow.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var parent = (this.parent as MainWindow);
            if (parent != null)
            {
                parent.App.Repository.Remove(contact);
                parent.RenderList();
            }
            this.Close();
        }
    }
}
