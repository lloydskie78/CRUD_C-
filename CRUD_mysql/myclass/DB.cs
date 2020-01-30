using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace CRUD_mysql.myclass
{
    class DB
    {
        public MySqlConnection con;

        public DB()
        {
            string host = "localhost";
            string db = "testuser";
            string port = "3306";
            string user = "root";
            string pass = "";
            string constring = "datasource = " + host + "; database = " + db + "; port = " + port + "; username=" + user + "; password=" + pass + "; SslMode=none;";
            con = new MySqlConnection(constring);
        }

    }

    class CRUD:DB
    {
        //PROPERTIES
        public string name { set; get; }
        public string number { set; get; }
        public string address { set; get; }

        //FOR ID
        public string id { set; get; }

        //READ PROPERTIES
        public DataTable dt = new DataTable();
        private DataSet ds = new DataSet();

        //CREATE FUNCTION
        public void Create_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO `contact` (`fullname`, `address`, `mobile_number`) VALUES (@name, @add, @num)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@add", MySqlDbType.VarChar).Value = address;
                cmd.Parameters.Add("@num", MySqlDbType.VarChar).Value = number;

                cmd.ExecuteNonQuery();
                con.Close();

            }

        }

        //UPDATE FUNCTION
        public void Update_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE contact SET fullname=@name, address=@add, mobile_number=@num WHERE id=@id";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@add", MySqlDbType.VarChar).Value = address;
                cmd.Parameters.Add("@num", MySqlDbType.VarChar).Value = number;

                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;

                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        //DELETE FUNCTION
        public void Delete_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "DELETE FROM contact WHERE id=@id";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;

                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        //READ FUNCTION
        public void Read_data()
        {
            dt.Clear();
            string query = "SELECT * FROM `contact`";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
            MDA.Fill(ds);
            dt = ds.Tables[0];
        }

    }
}
