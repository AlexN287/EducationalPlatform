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
    public class DeleteUpdateTeacherVM: ViewModelBase
    {
        public DeleteUpdateTeacherVM() { teachers = TeacherBLL.GetAllTeachers(); }

        private ObservableCollection<Teacher> teachers;

        public ObservableCollection<Teacher> Teachers
        {
            get { return teachers; }
            set
            {
                if (teachers != value)
                {
                    teachers = value;
                    NotifyPropertyChanged(nameof(teachers));
                }

            }
        }

        private Teacher selectedTeacher;
        public Teacher SelectedTeacher
        {
            get { return selectedTeacher; }
            set
            {
                if (selectedTeacher != value)
                {
                    selectedTeacher = value;
                    NotifyPropertyChanged(nameof(selectedTeacher));
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

        private ICommand updateTeacherCommand { get; set; }
        public ICommand UpdateTeacherCommand
        {
            get
            {
                if (updateTeacherCommand == null)
                {
                    updateTeacherCommand = new RelayCommand(this.updateTeacher);
                }

                return updateTeacherCommand;
            }
        }

        private void updateTeacher()
        {
            Teacher teacher = new Teacher(selectedTeacher.TeacherID, Firstname, Lastname, selectedTeacher.userID);
            TeacherBLL.UpdateTeacher(teacher);
            Teachers = TeacherBLL.GetAllTeachers();
            MessageBox.Show("Teacher Updated");
        }

        private ICommand deleteTeacherCommand { get; set; }
        public ICommand DeleteTeacherCommand
        {
            get
            {
                if (deleteTeacherCommand == null)
                {
                    deleteTeacherCommand = new RelayCommand(this.deleteTeacher);
                }

                return deleteTeacherCommand;
            }
        }

        private void deleteTeacher()
        {
            TeacherBLL.DeleteTeacher(selectedTeacher);
            Teachers = TeacherBLL.GetAllTeachers();
            MessageBox.Show("Teacher Deleted");
        }
    }
}
