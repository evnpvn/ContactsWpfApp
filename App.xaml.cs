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
        //!Fields
        public const string dbName = "SqliteDatabaseFileName";
        public static readonly string folderPath = Environment.CurrentDirectory;
        public static string databasePath = System.IO.Path.Combine(folderPath, GetConnectionStringByName(dbName));

        //!Methods
        //gets only the specified connection string
        public static string GetConnectionStringByName(string name)
        {
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings[name];

            if (connectionStringSettings != null)
            {
                return connectionStringSettings.ConnectionString;
            }
            else return null;
        }
    }
}
