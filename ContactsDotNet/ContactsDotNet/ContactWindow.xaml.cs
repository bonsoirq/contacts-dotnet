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
                this.Title = "Nowy kontakt";
            }

            NameTextBox.Text = contact.Name;
            PositionTextBox.Text = contact.Position;
            NumberTextBox.Text = contact.PhoneNumber;
            EmailTextBox.Text = contact.Email;
            WebsiteTextBox.Text = contact.Website;
            AddressTextBox.Text = contact.Address;
            NotesTextBox.Text = contact.Notes;

            this.contact = contact;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            contact.Name = NameTextBox.Text;
            contact.Position = PositionTextBox.Text;
            contact.PhoneNumber = NumberTextBox.Text;
            contact.Email = EmailTextBox.Text;
            contact.Website = WebsiteTextBox.Text;
            contact.Address = AddressTextBox.Text;
            contact.Notes = NotesTextBox.Text;

            if (contact.Name.Length > 0)
            {
                var name = contact.Name.Split(' ')[0];
                this.Title = name;
            }
            else
            {
                this.Title = "Nowy kontakt";
            }

            this.Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
