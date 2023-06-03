using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Tema3_MVP.Commands;
using Tema3_MVP.Models.BusinessLogicLayer;
using Tema3_MVP.Models.EntityLayer;

namespace Tema3_MVP.ViewModels
{
    public class AddUserVM: ViewModelBase
    {
        public AddUserVM()
        {

        }
        public User currentUser { get; set; }

        private static string username;
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
        private static string password;
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

        private static string role;
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

        private ICommand addUserCommand { get; set; }

        public ICommand AddUserCommand
        {
             get
             {
                 if (addUserCommand == null)
                 {
                    addUserCommand = new RelayCommand(this.AddUser);
                 }

                return addUserCommand;
             }
        }
       
        private void AddUser()
        {
            User newUser = new User(Username, Password, Role.ToString());
            UserBLL.AddUser(newUser);
            MessageBox.Show("Added new user");
        }

    }
}

