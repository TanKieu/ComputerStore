using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStoreProject
{
    class UserDB
    {
        String strConnection;
        public UserDB()
        {
            strConnection = getConnectionString();
        }
        public String getConnectionString()
        {
            strConnection = @"server=20.188.105.155; database=ComputerManagement; uid=sa;pwd=kieunhattan2000!@#";
            return strConnection;
        }
        public User getUser(String uid)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            String SQL = "Select * from dbo.[User] Where uid = @id";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@id", uid);
            if (cnn.State == System.Data.ConnectionState.Closed)
            {
                cnn.Open();
            }
            SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            if (reader.Read())
            {
                User user = new User();
                user.uid = uid;
                user.fullname = reader["staff_name"].ToString();
                user.role = reader["role"].ToString();
                return user;
            }
            return null;
        }
    }
}
