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

namespace Tema3_MVP.ViewModels
{
    public class AddTeacherVM: ViewModelBase
    {
        string role = "Teacher";
        public UserBLL userBLL = new UserBLL();
        public TeacherBLL teacherBLL = new TeacherBLL();
        public ObservableCollection<User> users;

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
        public AddTeacherVM()
        {
            users = UserBLL.GetUsersByRole(role);
            //subjects = SubjectBLL.GetAllSubjects();
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

        /*private ObservableCollection<Subject> subjects;
        public ObservableCollection<Subject> Subjects
        {
            get { return subjects; }
            set
            {
                if (subjects != value)
                {
                    subjects = value;
                    NotifyPropertyChanged(nameof(subjects));
                }

            }
        }

        private Subject selectedSubject;
        public Subject SelectedSubject
        {
            get { return selectedSubject; }
            set
            {
                if (selectedSubject != value)
                {
                    selectedSubject = value;
                    NotifyPropertyChanged(nameof(SelectedSubject));
                }

            }
        }*/

        private TeacherSubjectBLL teacherSubjectBLL { get; set; }
        public ICommand addTeacherCommand { get; set; }
        public ICommand AddTeacherCommand
        {
            get
            {
                if (addTeacherCommand == null)
                {
                    addTeacherCommand = new RelayCommand<Teacher>(this.AddTeacher);
                }

                return addTeacherCommand;
            }
        }

        public void AddTeacher(Teacher teacher)
        {
            if (selectedUser != null)
            {
                Teacher teacher1 = new Teacher(Firstname, Lastname, selectedUser.userID);
                int newTeacherID = TeacherBLL.AddTeacher(teacher1);
                //TeacherSubject newTeacherSubject = new TeacherSubject(newTeacherID, selectedSubject.subjectID);
                //TeacherSubjectBLL.AddTeacherSubject(newTeacherSubject);
                MessageBox.Show("teacher Added");
            }
            else
            {
                MessageBox.Show("Please Select a user");
            }
        }
    }
}
