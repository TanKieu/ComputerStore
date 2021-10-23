﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerStoreProject
{
    public partial class frmSale : Form
    {
        public String userId;
        List<BillDetails> billList = new List<BillDetails>();
        ProductDB productDB = new ProductDB();
        ArrayList proList = new ArrayList();
        String billID;
        float totalCost = 0;
        
        public frmSale()
        {
            InitializeComponent();
        }
        public frmSale(String userId)
        {
            InitializeComponent();
            this.userId = userId;
            proList = productDB.getAllProductId();
            billID = userId + DateTime.Now.ToString("yyyyMMddHHmmss");
            loadData();
        }
        private void loadData()
        {
            dgvOrderList.ColumnCount = 4;
            dgvOrderList.Columns[0].Name ="Product ID";
            dgvOrderList.Columns[1].Name="Product Name";
            dgvOrderList.Columns[2].Name = "Price";
            dgvOrderList.Columns[3].Name="Quantity";
            foreach (Product pro in proList)
            {
                cbProId.Items.Add(pro.ProductID);
            }
        }

        private void txtClientName_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmSale_Load(object sender, EventArgs e)
        {

        }

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            Product pro = FindPro(cbProId.Text);
            BillDetails billDetails = new  BillDetails(billID, pro.ProductID, int.Parse(numUDQuantity.Value.ToString()));
            billList.Add(billDetails);
            totalCost += pro.Price* int.Parse(numUDQuantity.Value.ToString());
            dgvOrderList.Rows.Add(pro.ProductID, pro.ProductName,pro.Price , numUDQuantity.Value);
        }
        private Product FindPro(String id)
        {
            Product pro = null;
            foreach (Product product in proList)
            {
                if (product.ProductID.Equals(id)) { pro = product; }
            }
            return pro;
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            bool flag = false;
            ClientDB clientDb = new ClientDB();
            if (mtxtPhone.MaskFull)
            {
                if(clientDb.searchClientById(mtxtPhone.Text) == false)
                {
                    clientDb.insertNewClient(mtxtPhone.Text, txtClientName.Text);
                }
                Bill bill = new Bill(billID, mtxtPhone.Text, userId, DateTime.Today, totalCost);
                OrderListDB orderDB = new OrderListDB();
                flag = orderDB.InsertOrder(bill);
                BillDetailsDB detailsDB = new BillDetailsDB();
                if (flag == true)
                {
                    foreach (BillDetails billDetails in billList)
                    {
                        detailsDB.insertBillDetails(billDetails);
                        ProductDB productDB = new ProductDB();
                        Product pro = productDB.getProductByID(billDetails.ProductId);
                        pro.Quantity = pro.Quantity - billDetails.quantity;
                        productDB.updateProduct(pro);
                    }
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("Order successfully");
                }
                else
                {
                    MessageBox.Show("Create fail. Please try again later");
                }
            }else
            {
                MessageBox.Show("Please Input Client Information!!!");
            }
            
        }
    }
}