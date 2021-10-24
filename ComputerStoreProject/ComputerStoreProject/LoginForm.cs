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
    public partial class fmLogin : Form
    {
        public fmLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String username = txtUsername.Text;
            String password = txtPassword.Text;
            if(username == null || password == null)
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
            else
            {
                AccountDB acc = new AccountDB();
                String uid = acc.checkLogin(username, password);
                if (uid !=null)
                {
                    UserDB userDB = new UserDB();
                    User user = new User();
                    user = userDB.getUser(uid);
                    if (user.role.Contains("admin"))
                    {
                        this.Hide();
                        AdminForm adminForm = new AdminForm(user);
                        adminForm.Closed += (s, arg) => this.Close();
                        adminForm.Show();
                    }else if (user.role.Contains("staff"))
                    {
                        this.Hide();
                        EmpForm empForm = new EmpForm(user);
                        empForm.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password. Please try again.");
                }
            }
        }
    }
}
