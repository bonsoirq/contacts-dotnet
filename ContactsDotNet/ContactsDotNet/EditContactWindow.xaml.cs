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
    /// Interaction logic for EditContactWindow.xaml
    /// </summary>
    public partial class EditContactWindow : Window
    {
        private Contact contact;
        private IRepository<Contact> repository;

        public EditContactWindow(IRepository<Contact> repository)
        {
            InitializeComponent();

            this.Title = "Nowy kontakt";

            NameTextBox.Text = "";
            PositionTextBox.Text = "";
            NumberTextBox.Text = "";
            EmailTextBox.Text = "";
            WebsiteTextBox.Text = "";
            AddressTextBox.Text = "";
            NotesTextBox.Text = "";

            this.repository = repository;
        }

        public EditContactWindow(Contact contact)
        {
            InitializeComponent();

            this.Title = "Edytuj kontakt";

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
            if (contact == null)
            {
                var contact = new Contact();

                contact.Name = NameTextBox.Text;
                contact.Position = PositionTextBox.Text;
                contact.PhoneNumber = NumberTextBox.Text;
                contact.Email = EmailTextBox.Text;
                contact.Website = WebsiteTextBox.Text;
                contact.Address = AddressTextBox.Text;
                contact.Notes = NotesTextBox.Text;

                repository.Add(contact);
            }
            else
            {
                contact.Name = NameTextBox.Text;
                contact.Position = PositionTextBox.Text;
                contact.PhoneNumber = NumberTextBox.Text;
                contact.Email = EmailTextBox.Text;
                contact.Website = WebsiteTextBox.Text;
                contact.Address = AddressTextBox.Text;
                contact.Notes = NotesTextBox.Text;
            }

            this.Close();
        }
    }
}
