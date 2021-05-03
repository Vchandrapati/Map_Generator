using System.Windows;
using MySql.Data.MySqlClient;

namespace Map_Generator.Classes
{
    internal class MySQLconnect
    {
        private const string Server = "maplogin.mysql.database.azure.com";
        private const string Database = "users";
        private const string Uid = "Vc2004y@maplogin";
        private const string Password = "Iloveracing1";
        private MySqlConnection _connection;

        public MySQLconnect()
        {
            Init();
        }

        private void Init()
        {
            var connectionstring = $"SERVER={Server}; DATABASE={Database}; UID={Uid}; PASSWORD={Password};";
            _connection = new MySqlConnection(connectionstring);
        }

        public bool Connect()
        {
            try
            {
                _connection.OpenAsync();
                return true;
            }
            catch (MySqlException)
            {
                MessageBox.Show("There was an error connecting to the server");
            }

            return false;
        }

        public void CreateUser(string user, string password)
        {
            var query = $"INSERT INTO users (user, password) VALUES ('{user}', '{password}');";
            if (Connect())
            {
                var cmd = new MySqlCommand(query, _connection);
                cmd.ExecuteNonQuery();
            }
            else
                MessageBox.Show("There was an error connecting to the server");
        }

        public bool Login(string user, string password)
        {
            var query = $"SELECT EXISTS(SELECT * FROM users WHERE user = '{user}' AND password = '{password}');";
            var cmd = new MySqlCommand(query, _connection);

            cmd.ExecuteNonQuery();
            var read = cmd.ExecuteReader();

            while (read.Read())
            {
                if (!read.GetString(0).Contains("1")) continue;
                read.Close();
                return true;
            }

            read.Close();
            MessageBox.Show("There was an error creating the account");
            return false;
        }
    }
}