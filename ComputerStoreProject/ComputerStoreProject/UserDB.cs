using System;
using System.Collections.Generic;
using System.Data;
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
        
        public DataTable  getAllUser()
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            String SQL = "Select Account.uid, staff_name, [User].role, username, password from dbo.[User] Join dbo.Account on [User].uid = dbo.Account.uid";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtUser = new DataTable();
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                {
                    cnn.Open();
                }
                da.Fill(dtUser);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }

            return dtUser;
        }
        public bool AddUser(User user)
        {
            bool result;
            SqlConnection cnn = new SqlConnection(strConnection);
            String SQL = " Insert dbo.Account values(@uid, @username, @password) Insert dbo.[User] values(@uid, @name, @role)";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@uid", user.uid);
            cmd.Parameters.AddWithValue("@name", user.fullname);
            cmd.Parameters.AddWithValue("@role", user.role);
            cmd.Parameters.AddWithValue("@username", user.username);
            cmd.Parameters.AddWithValue("@password", user.password);

            try
            {
                if(cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();

                }
                result = cmd.ExecuteNonQuery() > 0;
            } catch(SqlException se)
            {
                throw new Exception(se.Message);
            }
            return result;
        }
    }
}
