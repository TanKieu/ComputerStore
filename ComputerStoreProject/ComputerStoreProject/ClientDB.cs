using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStoreProject
{
    class ClientDB
    {
        String strConnection;
        public ClientDB()
        {
            strConnection = getConnectionString();
        }
        private string getConnectionString()
        {
            strConnection = @"server=20.188.105.155; database=ComputerManagement; uid=sa;pwd=kieunhattan2000!@#";
            return strConnection;
        }
        public bool searchClientById(String id)
        {
            bool result = false;
            string sql = "SELECT client_name \n" +
                "FROM Client WHERE client_id = @clientID";
            SqlConnection connection = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("clientID", id);
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.Read())
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }
        public bool insertNewClient(String id, String name)
        {
            bool result = false;
            string sql = "INSERT INTO Client(client_id, client_name,phone) \n" +
                "VALUES (@ClientID,@ClientName,@phone)";
            SqlConnection connection = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@ClientID", id);
            cmd.Parameters.AddWithValue("@ClientName", name);
            cmd.Parameters.AddWithValue("@phone", id);

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                result = (cmd.ExecuteNonQuery() > 0);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

    }

}
