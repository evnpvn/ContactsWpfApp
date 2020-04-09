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

namespace Contacts
{
    /// <summary>
    /// Interaction logic for UpdateContact.xaml
    /// </summary>
    public partial class UpdateContactWindow : Window
    {
        public UpdateContactWindow()
        {
            InitializeComponent();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Update record in SQLlite table
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Delete record in SQLlite table
        }
    }
}
