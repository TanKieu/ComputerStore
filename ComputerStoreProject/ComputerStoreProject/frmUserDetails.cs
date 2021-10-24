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
            bool valid = validData();
            if (valid == false) {
                return;
            }
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
            else
            {
                flag = userDB.UpdateUser(UserAddOrEdit);
            }
           if(flag == true)
            {
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Save successfully");
            }else
            {
                MessageBox.Show("Save fail");
            }

        }
        //cancel button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private bool validData()
        {
            bool result = true;

            string userID = txtUid.Text.ToString();
            string fullname = txtName.Text.ToString();
            string role = cbRole.SelectedItem.ToString();
            string username = txtUsername.Text.ToString();
            string password = txtPassword.Text.ToString();
            //id
            if (isValidString(userID, 2, 15))
            {
                error.SetError(txtUid, "");
            }
            else
            {
                error.SetError(txtUid, "ID length 3-15 chacracters");
                result = false;
            }
            //name
            if (isValidString(fullname, 5, 40))
            {
                error.SetError(txtName, "");
            }
            else
            {
                error.SetError(txtName, "Name length 3-40 chacracters");
                result = false;
            }
            //role
            if (isValidString(role, 1, 20))
            {
                error.SetError(cbRole, "");
            }
            else
            {
                error.SetError(cbRole, "Select role");
                result = false;
            }
            //userName
            if (isValidString(username, 2, 30))
            {
                error.SetError(txtUsername, "");
            }
            else
            {
                error.SetError(txtUsername, "User name length 3-30 chacracters");
                result = false;
            }

            //userName
            if (isValidString(password, 2, 30))
            {
                error.SetError(txtPassword, "");
            }
            else
            {
                error.SetError(txtPassword, "Password length 3-30 chacracters");
                result = false;
            }


            return result;
        }


        private bool isValidString(string str, int min, int max)
        {
            if (str.Trim().Length <= min || str.Trim().Length >= max)
            {
                return false;
            }
            return true;
        }

        private bool isNumber(string number)
        {
            try
            {
                int value = int.Parse(number);
                if (value <= 0)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

    }
}
