using SQLite;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Contacts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ContactPersons> contacts = new List<ContactPersons> { };

        public MainWindow()
        {
            InitializeComponent();

            ReadDatabase();
        }

        private void NewContactButton_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();

            ReadDatabase();
        }

        void ReadDatabase()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<ContactPersons>();
                contacts = (connection.Table<ContactPersons>().ToList()).OrderBy(contact => contact.Name).ToList();
            }
           
            if (contacts != null)
            {
                ContactsListView.ItemsSource = contacts;
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = (sender as TextBox).Text.ToUpper();

            List<ContactPersons> filteredContactList = new List<ContactPersons> { };

            //enumerate through and see if the searchtext is contained in any member of the contacts list
            foreach (ContactPersons contact in contacts)
            {
                if (contact.Name.ToUpper().Contains(searchText))
                { 
                    filteredContactList.Add(contact);
                }
            }

            //Same above code in LINQ query syntax
            filteredContactList = contacts.Where(contact => contact.Name.ToUpper().Contains(searchText)).ToList();

            //Same above code in LINQ method/function syntax
            filteredContactList = (from c in contacts
                                   where c.Name.ToUpper().Contains(searchText)
                                   orderby c.Name
                                   select c).ToList();

            ContactsListView.ItemsSource = filteredContactList;
        }

        private void ContactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateContactWindow updateContactWindow = new UpdateContactWindow();
            updateContactWindow.ShowDialog();
        }
    }
}
