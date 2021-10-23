using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStoreProject
{
    
    
    public class Bill
    {
        public String BillId
        {
            get;set;
        }
        public String ClientId
        {
            get;set;
        }
        public float totalCost
        {
            get;set;
        }
        public DateTime OrderDate
        {
            get;set;
        }
        public String EmpId { get; set; }
        public Bill(String BillId,String ClientId, String EmpId, DateTime date, float totalCost)
        {
            this.BillId = BillId;
            this.ClientId = ClientId;
            this.EmpId = EmpId;
            this.OrderDate = date;
            this.totalCost = totalCost;
        }
        
    }
}
