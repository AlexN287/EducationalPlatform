using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3_MVP.Models.EntityLayer
{
    public class User: BasePropertyChanged
    {
        public User()
        {

        }
        public User(int userID, string username, string password, string role)
        {
            this.userID = userID;
            this.username = username;
            this.password = password;
            this.role = role;
        }

        public User(string username, string password, string role)
        {
            this.username = username;
            this.password = password;
            this.role = role;
        }

        public int userID;
        public int UserID
        {
            get
            {
                return userID;
            }
            set
            {
                userID = value;
                NotifyPropertyChanged("userID");
            }
        }
        public string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                NotifyPropertyChanged("username");
            }
        }
        public string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                NotifyPropertyChanged("password");
            }
        }

        public string role;
        public string Role
        {
            get
            {
                return role;
            }
            set
            {
                role = value;
                NotifyPropertyChanged("role");
            }
        }
    }
}
