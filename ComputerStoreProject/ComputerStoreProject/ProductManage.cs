using System;
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
    public partial class ProductManage : Form
    {
        DataTable dtProduct;
        ProductDB productDB = new ProductDB();
   
        public ProductManage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ProductManage_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        { 
            // get data
            dtProduct = productDB.getAllProduct();
            // khai bao khoa chinh
            dtProduct.PrimaryKey = new DataColumn[] {dtProduct.Columns["product_id"] };
            // su dung binding source
            bsProduct.DataSource = dtProduct;
            // xoa cac rang buoc du lieu
            txtProductID.DataBindings.Clear();
            txtName.DataBindings.Clear();
            txtCostSold.DataBindings.Clear();
            txtPrice.DataBindings.Clear();
            txtQuantity.DataBindings.Clear();
            txtCategory.DataBindings.Clear();
            txtStatus.DataBindings.Clear();
            // binding cho cac field
            txtProductID.DataBindings.Add("Text", bsProduct, "product_id");
            txtName.DataBindings.Add("Text", bsProduct, "product_name");
            txtQuantity.DataBindings.Add("Text", bsProduct, "quantity");
            txtCostSold.DataBindings.Add("Text", bsProduct, "costSold");
            txtPrice.DataBindings.Add("Text", bsProduct, "price");
            txtCategory.DataBindings.Add("Text", bsProduct, "category");
            txtStatus.DataBindings.Add("Text", bsProduct, "status");
            dgvProduct.DataSource = bsProduct;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            ProductForm productForm = new ProductForm(true,product);
            DialogResult r =  productForm.ShowDialog();
            if (r == DialogResult.OK) // cap nhat thong tin tren data table
            {
                product = productForm.ProductAddOrEdit;
                //product_id, product_name,quantity,category,costSold,price,dateModify,status
                DataRow row =  dtProduct.Rows.Add(product.ProductID);
                //row["product_id"] = product.ProductID;
                row["product_name"] = product.ProductName;
                row["quantity"] = product.Quantity;
                row["category"] = product.Category;
                row["costSold"] = product.CostSold;
                row["price"] = product.Price;
                row["dateModify"] = System.DateTime.Now;
                row["status"] = product.Status;

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product product = getCurrentProduct();
            ProductForm productForm = new ProductForm(false, product);
            DialogResult r = productForm.ShowDialog();
            if (r == DialogResult.OK) // cap nhat thong tin tren data table
            {
                DataRow row = dtProduct.Rows.Find(product.ProductID);
                row["product_name"] = product.ProductName;
                row["quantity"] = product.Quantity;
                row["category"] = product.Category;
                row["costSold"] = product.CostSold;
                row["price"] = product.Price;
                row["dateModify"] = System.DateTime.Now;
                row["status"] = product.Status;
            }
        }

        private Product getCurrentProduct() {
            string productID = txtProductID.Text;
            string productName = txtName.Text;
            int quantity = int.Parse(txtQuantity.Text);
            int costSold = int.Parse(txtCostSold.Text);
            int price = int.Parse(txtPrice.Text);
            string category = txtCategory.Text;
            string status = txtStatus.Text;
            Product product = new Product()
            {
                ProductID = productID,
                ProductName = productName,
                Quantity = quantity,
                CostSold = costSold,
                Price = price,
                Category = category,
                Status = status,
                ModifyDate = System.DateTime.Now.ToString()
            };
            return product;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to delete","Confirm",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string productID = txtProductID.Text;
                productDB.deleteProduct(productID);
                DataRow row = dtProduct.Rows.Find(productID);
                row.Delete();

            }
        }

        private void txtNameSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dtProduct.DefaultView;
            string filter = "product_name LIKE '%" + txtNameSearch.Text + "%'";
            dv.RowFilter = filter;
            lbResult.Text = "Total result : " + dtProduct.Compute("COUNT(product_id)",filter); 
        }
    }
}
