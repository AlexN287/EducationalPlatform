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
using Tema3_MVP.Views;

namespace Tema3_MVP.ViewModels
{
    public class MainWindowVM: ViewModelBase
    {
        public MainWindowVM() { }
        private User currentUser { get; set; }

        private string username;
        public string Username
        {
            get { return username; }
            set 
            { 
                username = value;
                NotifyPropertyChanged("username"); 
            }

        }

        private string password;
        public string Password
        {
            get { return password; }
            set 
            {
                password = value;
                NotifyPropertyChanged("password");
            }
        }

        private void Login()
        {
            if (string.IsNullOrEmpty(Username))
            {
                MessageBox.Show("The username field is required");
                return;
            }
            else if (string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("The password field is required");
                return;
            }

            currentUser = UserBLL.GetUserByNameAndPassword(Username, Password);

            if (currentUser == null)
            {
                MessageBox.Show("Username or password incorrect");
                return;
            }

            else if (currentUser.role == "Admin")
            {

                AdminView adminView = new AdminView();
                adminView.Show();
                return;
            }
            else if(currentUser.role == "Teacher")
            {
                TeacherView teacherView = new TeacherView(currentUser);
                teacherView.Show();
                return;
            }
            else if(currentUser.role == "Student")
            {
                StudentView studentView = new StudentView(currentUser);
                studentView.Show();
                return;
            }


        }

        private ICommand loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                {
                    loginCommand = new RelayCommand(this.Login);
                }

                return loginCommand;
            }
        }
    }
}
