using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Xml.Linq;
using Tema3_MVP.Commands;
using Tema3_MVP.Models.BusinessLogicLayer;
using Tema3_MVP.Models.EntityLayer;
using System.Collections.ObjectModel;
using Tema3_MVP.Models.DataAccessLayer;
using CommunityToolkit.Mvvm.Input;

namespace Tema3_MVP.ViewModels
{
    public class AddStudentVM: ViewModelBase
    {
        private string role = "Student";
        private ObservableCollection<User> users;
        public AddStudentVM()
        {
            users = UserBLL.GetUsersByRole(role);
            classes = ClassBLL.GetAllClasses();
        }
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
        public ObservableCollection<Class> classes;

        public ObservableCollection<Class> Classes
        {
            get { return classes; }
            set
            {
                if (classes != value)
                {
                    classes = value;
                    NotifyPropertyChanged(nameof(classes));
                }

            }
        }

        private Class selectedClass;

        public Class SelectedClass
        {
            get { return selectedClass; }
            set
            {
                if (selectedClass != value)
                {
                    selectedClass = value;
                    NotifyPropertyChanged(nameof(selectedClass));
                }
            }
        }
        private ICommand addStudentCommand { get; set; }
        public ICommand AddStudentCommand
        {
            get
            {
                if (addStudentCommand == null)
                {
                    addStudentCommand = new RelayCommand(this.AddStudent);
                }

                return addStudentCommand;
            }
        }

        private void AddStudent()
        {
            if(selectedUser!=null)
            {
                Student newStudent = new Student(Firstname, Lastname, selectedUser.userID);
                int student_id = StudentBLL.AddStudent(newStudent);
                ClassStudents classStudents = new ClassStudents(selectedClass.classID, student_id);
                ClassStudentBLL.AddClassStudent(classStudents);
                MessageBox.Show("Student Added");
            }
            else
            {
                MessageBox.Show("Please Select a user");
            }
        }
    }
}
