using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Tema3_MVP.Commands;
using Tema3_MVP.Models.BusinessLogicLayer;
using Tema3_MVP.Models.EntityLayer;
using CommunityToolkit.Mvvm.Input;

namespace Tema3_MVP.ViewModels
{
    public class AddTeacherVM: ViewModelBase
    {
        public AddTeacherVM()
        {
            users = UserBLL.GetUsersByRole(role);
        }

        private string role = "Teacher";
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

        private string firstname;
        private string lastname;
        public string Firstname
        {
            get { return firstname; }
            set
            {
                if (firstname != value)
                {
                    firstname = value;
                    NotifyPropertyChanged(nameof(Firstname));
                }

            }
        }

        public string Lastname
        {
            get { return lastname; }
            set
            {
                if (lastname != value)
                {
                    lastname = value;
                    NotifyPropertyChanged(nameof(Lastname));
                }

            }
        }
        private ICommand addTeacherCommand { get; set; }
        public ICommand AddTeacherCommand
        {
            get
            {
                if (addTeacherCommand == null)
                {
                    addTeacherCommand = new RelayCommand(this.AddTeacher);
                }

                return addTeacherCommand;
            }
        }

        private void AddTeacher()
        {
            if (selectedUser != null)
            {
                Teacher newTeacher = new Teacher(Firstname, Lastname, selectedUser.userID);
                int newTeacherID = TeacherBLL.AddTeacher(newTeacher);
                MessageBox.Show("teacher Added");
            }
            else
            {
                MessageBox.Show("Please Select a user");
            }
        }
    }
}
