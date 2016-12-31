using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MySql.Data;
using MySql.Data.MySqlClient;

//using MySql.Data.MySqlClient;

namespace MySqlRepository.Common
{
    public class DBConnection
    {
        private DBConnection()
        {
        }

        private string databaseName = string.Empty;
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public string Password { get; set; }
        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        private static DBConnection _instance = null;
        public static DBConnection Instance()
        {
            if (_instance == null)
                _instance = new DBConnection();
            return _instance;
        }

        public bool IsConnect()
        {
            bool result = true;


            if (Connection == null)
            {
                if (String.IsNullOrEmpty(databaseName))
                    result = false;
                string connstring = string.Format("Server=dockerserver-6gi4a4vc.cloudapp.net; database={0}; UID=root; password=123", databaseName);
               // string connstring = string.Format("Server=192.168.99.100; database={0}; UID=root; password=123", databaseName);


                
                try
                {
                    connection = new MySqlConnection(connstring);
                    connection.Open();
                    result = true;
                }
                catch (Exception ex)
                {

                    throw;
                }
                
            }

            return result;
        }

        public void Close()
        {
            connection.Close();
        }
    }
}
