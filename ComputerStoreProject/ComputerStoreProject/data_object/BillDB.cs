using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStoreProject.data_object
{
    public class BillDB
    {
        string connectionString;

        public BillDB()
        {
            getConnectionString();
        }
        public string getConnectionString()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ProductDB"]
                    .ConnectionString;
            return connectionString;
        }

        public DataTable getAllBill()
        {
            string sql = "SELECT bill_id, client_id,totalCost,orderDate,uid \n" +
                "FROM BillList";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtBill = new DataTable();
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                adapter.Fill(dtBill);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dtBill;
        }
    }
}
