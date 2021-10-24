using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStoreProject
{
    public class BillDetails
    {
        public String OrderId { get; set; }
        public String ProductId { get; set; }
        public int quantity { get; set; }

        public BillDetails(String orderId, String productId, int quantity)
        {
            this.OrderId = orderId;
            this.ProductId = productId;
            this.quantity = quantity;
        }
    }
}
