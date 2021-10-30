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
    public partial class AdminForm : Form
    {
        User user;

        public AdminForm(User user)
        {
            this.user = user;
            InitializeComponent();
            lbWelcome.Text = "Welcome, " + user.fullname;
        }

        private void btnMngUser_Click(object sender, EventArgs e)
        {
            ManageUser manageUserForm = new ManageUser();
            manageUserForm.Show();
        }

        private void btnMngProduct_Click(object sender, EventArgs e)
        {
            ProductManage productManage = new ProductManage();
            productManage.Show();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            frmSale salePro = new frmSale(user.uid);
            salePro.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            fmLogin fm = new fmLogin();
            fm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BillManage billForm = new BillManage();
            billForm.Show();
        }
    }
}
