using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStoreProject
{
    class OrderListDB
    {
        String strConnection;
        public OrderListDB()
        {
            strConnection = getConnectionString();
        }

        private string getConnectionString()
        {
            strConnection = @"server=20.188.105.155; database=ComputerManagement; uid=sa;pwd=kieunhattan2000!@#";
            return strConnection;
        }
        public bool InsertOrder(Bill bill)
        {
            bool result;
            SqlConnection cnn = new SqlConnection(strConnection);
            String SQL = " Insert dbo.BillList values(@id, @clientid, @totalCost, @orderDate, @empId)";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@id", bill.BillId);
            cmd.Parameters.AddWithValue("@clientid", bill.ClientId);
            cmd.Parameters.AddWithValue("@totalCost", bill.totalCost);
            cmd.Parameters.AddWithValue("@orderDate", bill.OrderDate);
            cmd.Parameters.AddWithValue("@empId", bill.EmpId);
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();

                }
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            return result;
        }
    }
}
