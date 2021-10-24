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

}
