using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStoreProject
{

    public class User
    {
        public User()
        {
        }
        public String uid { get; set; }
        public String fullname { get; set; }
        public String role { get; set; }
        public String username { get; set; }
        public String password { get; set; }

        
        public User(String userid, String username, String userrole)
        {
            uid = userid;
            fullname = username;
            role = userrole;
        }
        public User(String userid, String name, String role, String username, String password)
        {
            uid = userid;
            fullname = name;
            this.role = role;
            this.username = username;
            this.password = password;
        }

    }
}
