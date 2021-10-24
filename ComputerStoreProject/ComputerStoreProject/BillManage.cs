using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComputerStoreProject.data_object;

namespace ComputerStoreProject
{
    public partial class BillManage : Form
    {
        DataTable dtBill = new DataTable();
        BillDB billDB = new BillDB();
        public BillManage()
        {
            InitializeComponent();
        }

        private void BillManage_Load(object sender, EventArgs e)
        {
            LoadData();
            ReadOnly();
        }

        private void LoadData()
        {
            // get data
            dtBill = billDB.getAllBill();
            // khai bao khoa chinh
            dtBill.PrimaryKey = new DataColumn[] { dtBill.Columns["bill_id"] };
            // su dung binding source
            bsBill.DataSource = dtBill;
            // xoa cac rang buoc du lieu
            txtID.DataBindings.Clear();
            txtCreateDate.DataBindings.Clear();
            txtPhone.DataBindings.Clear();
            txtStaffID.DataBindings.Clear();
            txtTotalCost.DataBindings.Clear();
            // binding cho cac field
            txtID.DataBindings.Add("Text", bsBill, "bill_id");
            txtCreateDate.DataBindings.Add("Text", bsBill, "orderDate");
            txtPhone.DataBindings.Add("Text", bsBill, "client_id");
            txtTotalCost.DataBindings.Add("Text", bsBill, "totalCost");
            txtStaffID.DataBindings.Add("Text", bsBill, "uid");
            dgvBill.DataSource = bsBill;

        }
        private void ReadOnly() {
            txtCreateDate.Enabled = false;
            txtID.Enabled = false;
            txtPhone.Enabled = false;
            txtStaffID.Enabled = false;
            txtTotalCost.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dataView = dtBill.DefaultView;
            string filter = "client_id LIKE '%" + txtSearchPhone.Text + "%'";
            dataView.RowFilter = filter;
            
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
       
            this.Close();
        }
    }
}
