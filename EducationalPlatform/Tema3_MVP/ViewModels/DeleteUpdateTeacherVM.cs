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

        public ObservableCollection<Teacher> teachers;

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

        public ICommand updateTeacherCommand { get; set; }
        public ICommand UpdateTeacherCommand
        {
            get
            {
                if (updateTeacherCommand == null)
                {
                    updateTeacherCommand = new RelayCommand<Teacher>(this.updateTeacher);
                }

                return updateTeacherCommand;
            }
        }

        public void updateTeacher(Teacher teacher)
        {
            Teacher teacher1 = new Teacher(selectedTeacher.TeacherID, Firstname, Lastname, selectedTeacher.userID);
            TeacherBLL.UpdateTeacher(teacher1);
            Teachers = TeacherBLL.GetAllTeachers();
            MessageBox.Show("Teacher Updated");
        }

        public ICommand deleteTeacherCommand { get; set; }
        public ICommand DeleteTeacherCommand
        {
            get
            {
                if (deleteTeacherCommand == null)
                {
                    deleteTeacherCommand = new RelayCommand<Teacher>(this.deleteTeacher);
                }

                return deleteTeacherCommand;
            }
        }

        public void deleteTeacher(Teacher teacher)
        {
            TeacherBLL.DeleteTeacher(selectedTeacher);
            Teachers = TeacherBLL.GetAllTeachers();
            MessageBox.Show("Teacher Deleted");
        }
    }
}
