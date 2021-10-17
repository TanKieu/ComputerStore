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
    public partial class frmUserDetails : Form
    {
        private bool addOrEdit;
        public User UserAddOrEdit { get; set; }
        public frmUserDetails()
        {
            InitializeComponent();
        }

        public frmUserDetails(bool flag, User user): this()
        {
            addOrEdit = flag;
            UserAddOrEdit = user;
            InitData();
        }

        private void InitData()
        {
            txtUid.Text = UserAddOrEdit.uid.ToString();
            txtName.Text = UserAddOrEdit.fullname.ToString();
            cbRole.SelectedItem = UserAddOrEdit.role;
            txtUsername.Text = UserAddOrEdit.username.ToString();
            txtPassword.Text = UserAddOrEdit.password.ToString();
            if(addOrEdit == false)
            {
                txtUid.Enabled = false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmUserDetails_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool flag = false;
            UserAddOrEdit.uid = txtUid.Text.ToString();
            UserAddOrEdit.fullname = txtName.Text.ToString();
            UserAddOrEdit.role = cbRole.SelectedItem.ToString();
            UserAddOrEdit.username = txtUsername.Text.ToString();
            UserAddOrEdit.password = txtPassword.Text.ToString();
            UserDB userDB = new UserDB();
           if(addOrEdit == true)
            {
                flag = userDB.AddUser(UserAddOrEdit);
            }
           if(flag == true)
            {
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Add successfully");
            }else
            {
                MessageBox.Show("Save fail");
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
