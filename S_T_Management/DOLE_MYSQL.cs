using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Quan
{
    public class DOLE_MYSQL
    {

        private MySqlConnection connection;
        private string _server;
        private string _database;
        string _port;
        private string _uid;
        private string _password;

        //Constructor
   
        public string p_server
        {
            get { return _server; }
            set { _server = value; }
        }
        public string p_database
        {
            get { return _database; }
            set { _database = value; }
        }
        public string p_port
        {
            get { return _port; }
            set { _port= value; }
        }
        public string p_uid
        {
            get { return _uid; }
            set { _uid = value; }
        }
        public string p_password
        {
            get { return _password; }
            set { _password = value; }
        }

        //Initialize values
        public void Initialize()
        {
            string connectionString;
            connectionString = @"SERVER=" + _server + ";" + "DATABASE=" + _database + ";port=" + _port + "; user id=" + _uid + ";" + "PASSWORD=" + _password + ";CharSet=utf8;Convert Zero Datetime=True;";
            connection = new MySqlConnection(connectionString);
  
        }
        public int OpenConnection()
        {
            try
            {
                connection.Open();
                return 0;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                return ex.Number;
            }
        }

        //Close connection
        public int CloseConnection()
        {
            try
            {
                connection.Close();
                return 0;
            }
            catch (MySqlException ex)
            {
                return ex.Number;
            }
        }
        public DataTable RunQuery(string query)
        {
            if (this.OpenConnection() == 0)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dataReader);
                dataReader.Close();
                this.CloseConnection();
                return dt;
            }
            else
            {
                this.CloseConnection();
                return null;
            }
        }
        public DataTable RunStore(string store_name)
        {
            if (this.OpenConnection() == 0)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(store_name, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dataReader);
                dataReader.Close();
                this.CloseConnection();
                return dt;
            }
            else
            {
                this.CloseConnection();
                return null;
            }
        }
        public DataTable RunStore(string store_name, DataRow[] drs)
        {
            if (this.OpenConnection() == 0)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(store_name, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (DataRow dr in drs)
                    cmd.Parameters.AddWithValue(dr[0].ToString(), dr[1]);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dataReader);
                dataReader.Close();
                this.CloseConnection();
                return dt;
            }
            else
            {
                this.CloseConnection();
                return null;
            }
        }
        public DataTable _RunQuery(string query)
        {
            //create command and assign the query and connection from the constructor
            MySqlCommand cmd = new MySqlCommand(query, connection);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dataReader);
            dataReader.Close();
            return dt;
        }
        public DataTable _RunStore(string store_name)
        {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(store_name, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dataReader);
                dataReader.Close();
                return dt;
        }
        public DataTable _RunStore(string store_name, DataRow[] drs)
        {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(store_name, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (DataRow dr in drs)
                    cmd.Parameters.AddWithValue(dr[0].ToString(), dr[1]);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dataReader);
                dataReader.Close();
                return dt;
            
        }
    }
}

