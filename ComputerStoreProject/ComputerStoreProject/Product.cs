using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStoreProject
{
    public class Product
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
        public int CostSold { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
        public string ModifyDate { get; set; }
    }

    public class ProductDB {
        string connectionString;
     
        public ProductDB()
        {
            getConnectionString();
        }
        public string getConnectionString()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ProductDB"]
                    .ConnectionString;
            return connectionString;
        }

        public DataTable getAllProduct() {
            string sql = "SELECT product_id, product_name,quantity,category,costSold,price,dateModify,status \n" +
                "FROM Product";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtProduct = new DataTable();
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                adapter.Fill(dtProduct);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally {
                connection.Close();
            }
            return dtProduct;
        }
        public ArrayList getAllProductId()
        {
            ArrayList productIdList= new ArrayList();
            String sql = "Select  product_id, product_name,quantity,category,costSold,price,dateModify,status From Product where status = @status";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@status", "active");
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        ProductID = reader["product_id"].ToString(),
                        ProductName = reader["product_name"].ToString(),
                        Quantity = int.Parse(reader["quantity"].ToString()),
                        Category = reader["category"].ToString(),
                        CostSold = int.Parse(reader["costSold"].ToString()),
                        Price = int.Parse(reader["price"].ToString()),
                        ModifyDate = reader["dateModify"].ToString(),
                        Status = reader["status"].ToString()
                    };
                    productIdList.Add(product);

                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return productIdList;
        }

        public Product getProductByID(string id) {
            Product product = null;
            string sql = "SELECT product_name,quantity,category,costSold,price,dateModify,status \n" +
                "FROM Product WHERE product_id = @ProductID";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@ProductID", id);
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.Read())
                {
                    product = new Product()
                    {
                        ProductID = id,
                        ProductName = reader["product_name"].ToString(),
                        Quantity = int.Parse(reader["quantity"].ToString()),
                        Category = reader["category"].ToString(),
                        CostSold = int.Parse(reader["costSold"].ToString()),
                        Price = int.Parse(reader["price"].ToString()),
                        ModifyDate = reader["dateModify"].ToString(),
                        Status = reader["status"].ToString()
                };
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return product;

        }

        public bool updateProduct(Product product)
        {
            bool result = false;
            string sql = "UPDATE Product \n " +
                "SET product_name = @ProductName ,quantity = @Quantity," +
                    "category = @Category,costSold = @CostSold,price = @Price," +
                    "dateModify = @DateModify,status = @Status \n" +
                "WHERE product_id= @ProductID";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
            cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
            cmd.Parameters.AddWithValue("@Category", product.Category);
            cmd.Parameters.AddWithValue("@CostSold", product.CostSold);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@DateModify", product.ModifyDate);
            cmd.Parameters.AddWithValue("@Status", product.Status);
            cmd.Parameters.AddWithValue("@ProductID", product.ProductID);
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

        public bool addProduct(Product product)
        {
            bool result = false;   
            string sql = "INSERT INTO Product(product_id, product_name,quantity,category,costSold,price,dateModify,status) \n" +
                "VALUES (@ProductID,@ProductName,@Quantity,@Category,@CostSold,@Price,@DateModify,@Status)";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@ProductID", product.ProductID);
            cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
            cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
            cmd.Parameters.AddWithValue("@Category", product.Category);
            cmd.Parameters.AddWithValue("@CostSold", product.CostSold);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@DateModify", product.ModifyDate);
            cmd.Parameters.AddWithValue("@Status", product.Status);

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
            finally {
                connection.Close();
            }
            return result;

        }

        public bool deleteProduct(string id)
        {
            bool result = false;
            string sql = "DELETE FROM Product WHERE product_id = @ProductID";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@ProductID", id);
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
