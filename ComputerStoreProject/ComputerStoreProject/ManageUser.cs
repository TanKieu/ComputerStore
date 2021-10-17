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
    public partial class ManageUser : Form
    {
        public ManageUser()
        {
            InitializeComponent();
        }
        DataTable dtUser;
        private void ManageUser_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            UserDB userDB = new UserDB();
            dtUser = userDB.getAllUser();
            dtUser.PrimaryKey = new DataColumn[] { dtUser.Columns["uid"] };
            bsUser.DataSource = dtUser;

            txtUid.DataBindings.Clear();
            txtName.DataBindings.Clear();
            txtRole.DataBindings.Clear();
            txtUsername.DataBindings.Clear();
            txtPassword.DataBindings.Clear();

            txtUid.DataBindings.Add("Text", bsUser, "uid");
            txtName.DataBindings.Add("Text", bsUser, "staff_name");
            txtRole.DataBindings.Add("Text", bsUser, "role");
            txtUsername.DataBindings.Add("Text", bsUser, "username");
            txtPassword.DataBindings.Add("Text", bsUser, "password");

            dgvUserList.DataSource = bsUser;
            bsUser.Sort= "uid DESC";
            bnUser.BindingSource = bsUser;
        }

        private void dgvUserList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            String uid = String.Empty;
            String name = String.Empty;
            String role = "staff";
            String username = String.Empty;
            String password = String.Empty;
            User user = new User(uid, name, role, username, password);
            frmUserDetails UserDetail = new frmUserDetails(true, user);
            DialogResult r = UserDetail.ShowDialog();
            if(r == DialogResult.OK)
            {
                user = UserDetail.UserAddOrEdit;
                dtUser.Rows.Add(user.uid, user.fullname, user.role, user.username, user.password);
            }
        }
    }
}
