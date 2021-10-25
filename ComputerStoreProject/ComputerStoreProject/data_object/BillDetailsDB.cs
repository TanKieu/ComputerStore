using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStoreProject
{
    class BillDetailsDB
    {
        String strConnection;
        public BillDetailsDB()
        {
            strConnection = getConnectionString();
        }
        public String getConnectionString()
        {
            strConnection = @"server=20.188.105.155; database=ComputerManagement; uid=sa;pwd=kieunhattan2000!@#";
            return strConnection;
        }
        public bool insertBillDetails(BillDetails billDetails)
        {
            
                bool result;
                SqlConnection cnn = new SqlConnection(strConnection);
                String SQL = " Insert dbo.BillDetails values(@billId, @productid, @quantity)";
                SqlCommand cmd = new SqlCommand(SQL, cnn);
                cmd.Parameters.AddWithValue("@billid",billDetails.OrderId );
                cmd.Parameters.AddWithValue("@productid", billDetails.product.ProductID);
                cmd.Parameters.AddWithValue("@quantity", billDetails.quantity);
                
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
