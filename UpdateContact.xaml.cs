using System;
using SQLite;
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

namespace Contacts
{
    /// <summary>
    /// Interaction logic for UpdateContact.xaml
    /// </summary>
    public partial class UpdateContactWindow : Window
    {
        ContactPersons contact;
        public UpdateContactWindow(ContactPersons selectedContact)
        {   
            InitializeComponent();
            this.contact = selectedContact;

            UpdateNameBox.Text = contact.Name;
            UpdateEmailBox.Text = contact.Email;
            UpdatePhonenumBox.Text = contact.Phone;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            contact.Name = UpdateNameBox.Text;
            contact.Email = UpdateEmailBox.Text;
            contact.Phone = UpdatePhonenumBox.Text;
                       
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<ContactPersons>();
                connection.Update(contact);
            }
            this.Close();
        }
            

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<ContactPersons>();
                connection.Delete(contact);
            }
            this.Close();
        }
    }
}
