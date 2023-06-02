using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class DeleteUpdateUserVM: ViewModelBase
    {
        public DeleteUpdateUserVM() {
            users = UserBLL.GetAllUsers();
        }
        private ObservableCollection<User> users;  
        public ObservableCollection<User> Users
        {
            get { return users; }
            set
            {
                if (users != value)
                {
                    users = value;
                    NotifyPropertyChanged(nameof(users));
                }

            }
        }

        private User selectedUser;

        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                if (selectedUser != value)
                {
                    selectedUser = value;
                    NotifyPropertyChanged(nameof(selectedUser));
                }
            }
        }

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

        private ICommand updateUserCommand { get; set; }

        public ICommand UpdateUserCommand
        {
            get
            {
                if (updateUserCommand == null)
                {
                    updateUserCommand = new RelayCommand(this.updateUser);
                }

                return updateUserCommand;
            }
        }

        private void updateUser()
        {
            User user = new User(selectedUser.userID, username, password, role);
            UserBLL.UpdateUser(user);
            MessageBox.Show("User Updated");
        }

        private ICommand deleteUserCommand { get; set; }

        public ICommand DeleteUserCommand
        {
            get
            {
                if (deleteUserCommand == null)
                {
                    deleteUserCommand = new RelayCommand(this.deleteUser);
                }

                return deleteUserCommand;
            }
        }
        private void deleteUser()
        {
            UserBLL.DeleteUser(selectedUser);
            MessageBox.Show("User Deleted");
        }
    }
}
