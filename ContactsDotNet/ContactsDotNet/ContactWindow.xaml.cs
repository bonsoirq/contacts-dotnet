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

        public ContactWindow(Contact contact)
        {
            InitializeComponent();

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

            this.contact = contact;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var contactWindow = new EditContactWindow(contact);
            contactWindow.Show();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
