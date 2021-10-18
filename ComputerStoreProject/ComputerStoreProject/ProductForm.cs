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
    public partial class ProductForm : Form
    {
        bool addOrEdit;
        public Product ProductAddOrEdit { get; set; }
        ProductDB productDB = new ProductDB();
        public ProductForm()
        {
            InitializeComponent();
        }
        public ProductForm(bool addOrEdit, Product product):this() {
            this.addOrEdit = addOrEdit;
            this.ProductAddOrEdit = product;
            LoadData();
        }

        private void LoadData()
        {
            txtProductID.Text = ProductAddOrEdit.ProductID;
            txtProductName.Text = ProductAddOrEdit.ProductName;
            txtQuantity.Text = ProductAddOrEdit.Quantity + "";
            txtCostSold.Text = ProductAddOrEdit.CostSold + "";
            txtPrice.Text = ProductAddOrEdit.Price + "";
            cbCategory.SelectedIndex = cbCategory.FindStringExact(ProductAddOrEdit.Category);
            cbStatus.SelectedIndex = cbStatus.FindStringExact(ProductAddOrEdit.Status);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string productID = txtProductID.Text;
            string productName = txtProductName.Text;
            int quantity = int.Parse(txtQuantity.Text);
            int costSold = int.Parse(txtCostSold.Text);
            int price = int.Parse(txtPrice.Text);
            string category = cbCategory.Text;
            string status = cbStatus.Text;

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
            bool flag;
            if (addOrEdit == true) // add new product
            {
               
               flag =  productDB.addProduct(product);
                ProductAddOrEdit = product;
            }
            else {
               flag = productDB.updateProduct(product);
                ProductAddOrEdit = product;

            }
            if (flag == true)
            {
                MessageBox.Show("Save success");
                this.DialogResult = DialogResult.OK;
            }
            else { 
                MessageBox.Show("Save failed");
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
