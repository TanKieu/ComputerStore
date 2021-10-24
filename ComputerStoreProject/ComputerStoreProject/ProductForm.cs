using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public ProductForm(bool addOrEdit, Product product) : this() {
            this.addOrEdit = addOrEdit;
            this.ProductAddOrEdit = product;
            LoadData();
        }

        private void LoadData()
        {
            if (addOrEdit == false) {
                txtProductID.Enabled = false;
            }

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
            bool valid = validData();
            if (valid == false) {
                return;
            }

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

                flag = productDB.addProduct(product);
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

        private bool validData() {
            bool result = true;
            string productID = txtProductID.Text;
            string productName = txtProductName.Text;
            string quantity = txtQuantity.Text; //int
            string costSold = txtCostSold.Text; //int
            string price = txtPrice.Text;           //int
            string category = cbCategory.Text;
            string status = cbStatus.Text;
            //id
            if (isValidString(productID, 2, 15))
            {
                error.SetError(txtProductID, "");
            }
            else {
                error.SetError(txtProductID, "ID length 3-15 chacracters");
                result = false;
            }
            //name
            if (isValidString(productName, 2, 40))
            {
                error.SetError(txtProductName, "");
            }
            else {
                error.SetError(txtProductName, "Name length 3-40 chacracters");
                result = false;
            }
            //quantity
            if (isNumber(quantity))
            {
                error.SetError(txtQuantity, "");
            }
            else
            {
                error.SetError(txtQuantity, "Quantity is positive number");
                result = false;
            }
            //cost sold
            if (isNumber(costSold))
            {
                error.SetError(txtCostSold, "");
            }
            else
            {
                error.SetError(txtCostSold, "Cost sold is positive number");
                result = false;
            }
            if (isNumber(price))
            {
                error.SetError(txtPrice, "");
            }
            else
            {
                error.SetError(txtPrice, "Price is positive number");
                result = false;
            }
            //category
            if (isValidString(category,2,20))
            {
                error.SetError(cbCategory, "");
            }
            else
            {
                error.SetError(cbCategory, "Select category");
                result = false;
            }
            //status
            if (isValidString(status, 1, 20))
            {
                error.SetError(cbStatus, "");
            }
            else
            {
                error.SetError(cbStatus, "Select status");
                result = false;
            }
            return result;
        }


        private bool isValidString(string str, int min,int max) {
            if (str.Trim().Length <= min || str.Trim().Length >= max) {
                return false;
            }
            return true;
        }

        private bool isNumber(string number) {
            try
            {
                int value = int.Parse(number);
                if (value <= 0) {
                    return false;
                }
            }
            catch (Exception) {
                return false; 
            }
            return true;
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {

        }
    }
}
