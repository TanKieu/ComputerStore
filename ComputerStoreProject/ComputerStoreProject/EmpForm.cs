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
    public partial class EmpForm : Form
    {
        public User user;
        public EmpForm(User user)
        {
            this.user = user;
            InitializeComponent();
            lbWelcome.Text = "Welcome, " + user.fullname;
        }

        private void btnMngProduct_Click(object sender, EventArgs e)
        {
            ProductManage productManage = new ProductManage();
            productManage.Show();
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            frmSale salePro = new frmSale(user.uid);
            salePro.Show();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            BillManage billManage = new BillManage();
            billManage.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            fmLogin fm = new fmLogin();
            fm.Closed += (s, arg) => this.Close();
            fm.Show();
        }

        private void EmpForm_Load(object sender, EventArgs e)
        {

        }
    }
}
