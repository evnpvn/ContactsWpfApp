using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Contacts
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static readonly string databaseName = "Contacts.db";
        static readonly string folderPath = Environment.CurrentDirectory;
        public static string databasePath = System.IO.Path.Combine(folderPath, databaseName);

    }
}
