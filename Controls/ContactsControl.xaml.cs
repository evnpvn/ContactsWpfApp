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

namespace Contacts.Controls
{
    /// <summary>
    /// Interaction logic for ContactsControl.xaml
    /// </summary>
    public partial class ContactsControl : UserControl
    {

        public ContactPersons Contact
        {
            get { return GetValue(ContactProperty) as ContactPersons; }
            set { SetValue(ContactProperty, value); }
        }

        //Using a DependencyProperty as the backing store for MyProperty. This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register("Contact", typeof(ContactPersons), typeof(ContactsControl), new PropertyMetadata(null, SetContactValues));

        private static void SetContactValues(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContactsControl control = d as ContactsControl;

            if(control != null)
            {
                control.NameTextBlock.Text = ((ContactPersons)e.NewValue).Name; //different syntax for casting but same thing as below
                control.EmailTextBlock.Text = (e.NewValue as ContactPersons).Email;
                control.PhoneTextBlock.Text = (e.NewValue as ContactPersons).Phone;
            }
        }

        public ContactsControl()
        {
            InitializeComponent();
        }
    }
}
