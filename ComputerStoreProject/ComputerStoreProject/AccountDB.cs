using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStoreProject
{
    class AccountDB
    {
        String strConnection;
        public AccountDB()
        {
            strConnection = getConnectionString();
        }
        public String getConnectionString()
        {
            String strConnection = @"server=20.188.105.155; database=ComputerManagement; uid=sa;pwd=kieunhattan2000!@#";
            return strConnection;
        }
        public String checkLogin(String username, String password)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            String SQL = "Select password, uid From dbo.Account Where username = @username";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@username", username);
            if(cnn.State == System.Data.ConnectionState.Closed)
            {
                cnn.Open();
            }
            SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            if (reader.Read())
            {
                String userPass = reader["password"].ToString();
                String uid = reader["uid"].ToString();
                if (userPass.Equals(password)) return uid;
            }
            return null ;
        }
        public bool createAccount(String username, String password)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            String SQL = "Insert into dbo.Account Values(@username, @password)";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            if(cnn.State == System.Data.ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            
            return (count>0);
        }
    }
}
