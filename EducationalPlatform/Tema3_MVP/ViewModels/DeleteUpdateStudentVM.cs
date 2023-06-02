using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Tema3_MVP.Commands;
using Tema3_MVP.Models.BusinessLogicLayer;
using Tema3_MVP.Models.DataAccessLayer;
using Tema3_MVP.Models.EntityLayer;
using CommunityToolkit.Mvvm.Input;

namespace Tema3_MVP.ViewModels
{
    public class DeleteUpdateStudentVM: ViewModelBase
    {
        public DeleteUpdateStudentVM()
        { 
            students = StudentBLL.GetAllStudents();
            classes = ClassBLL.GetAllClasses();
        }

        private ObservableCollection<Student> students;
        public ObservableCollection<Student> Students
        {
            get { return students; }
            set
            {
                if (students != value)
                {
                    students = value;
                    NotifyPropertyChanged(nameof(students));
                }
            }
        }

        private Student selectedStudent;
        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                if (selectedStudent != value)
                {
                    selectedStudent = value;
                    NotifyPropertyChanged(nameof(selectedStudent));
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

        private ICommand updateStudentCommand { get; set; }

        public ICommand UpdateStudentCommand
        {
            get
            {
                if (updateStudentCommand == null)
                {
                    updateStudentCommand = new RelayCommand(this.updateStudent);
                }

                return updateStudentCommand;
            }
        }

        private ObservableCollection<Class> classes;

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
        private void updateStudent()
        {
            Student student = new Student(selectedStudent.StudentID, firstname, lastname, selectedStudent.userID);
            StudentBLL.UpdateStudent(student);
            ClassStudents classStudents = new ClassStudents(selectedClass.classID, selectedStudent.userID);
            ClassStudentBLL.UpdateClassStudent(classStudents);
            Students = StudentBLL.GetAllStudents();
            MessageBox.Show("Student Updated");
        }

        private ICommand deleteStudentCommand { get; set; }
        public ICommand DeleteStudentCommand
        {
            get
            {
                if (deleteStudentCommand == null)
                {
                    deleteStudentCommand = new RelayCommand(this.deleteStudent);
                }

                return deleteStudentCommand;
            }
        }
        public void deleteStudent()
        {
            StudentBLL.DeleteStudent(selectedStudent);
            Students = StudentBLL.GetAllStudents();
            MessageBox.Show("Student Deleted");
        }
    }
}
