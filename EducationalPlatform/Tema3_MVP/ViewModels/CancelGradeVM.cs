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
    public class CancelGradeVM: ViewModelBase
    {
        public Teacher currentTeacher;
        public CancelGradeVM(Teacher teacher)
        {
            this.currentTeacher = teacher;
            subjects = TeacherBLL.GetTeacherSubjects(currentTeacher);
            classes = TeacherBLL.GetTeacherClasses(currentTeacher);
        }

        private ObservableCollection<Subject> subjects;
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

        private ObservableCollection<Grade> grades;
        public ObservableCollection<Grade> Grades
        {
            get { return grades; }
            set
            {
                if (grades != value)
                {
                    grades = value;
                    NotifyPropertyChanged(nameof(grades));
                }
            }
        }

        private Grade selectedGrade;
        public Grade SelectedGrade
        {
            get { return selectedGrade; }
            set
            {
                if (selectedGrade != value)
                {
                    selectedGrade = value;
                    NotifyPropertyChanged(nameof(selectedGrade));
                }
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

        public ICommand classSelectionCommand { get; set; }
        public ICommand ClassSelectionCommand
        {
            get
            {
                if (classSelectionCommand == null)
                {
                    classSelectionCommand = new RelayCommand<Class>(this.UpdateSubjects);
                }

                return classSelectionCommand;
            }
        }

        public void UpdateSubjects(Class subject)
        {
            Subjects = TeacherBLL.GetTeacherSubjectsByClass(currentTeacher, selectedClass);
            Students = StudentBLL.GetStudentsFromClass(selectedClass);

        }

        public ICommand studentSelectionCommand { get; set; }
        public ICommand StudentSelectionCommand
        {
            get
            {
                if (studentSelectionCommand == null)
                {
                    studentSelectionCommand = new RelayCommand<Student>(this.UpdateGrades);
                }

                return studentSelectionCommand;
            }
        }

        public void UpdateGrades(Student student)
        {
            Grades = GradeBLL.GetGradesByStudentSubject(selectedStudent, selectedSubject);
        }

        public ICommand cancelGradeCommand { get; set; }
        public ICommand CancelGradeCommand
        {
            get
            {
                if (cancelGradeCommand == null)
                {
                    cancelGradeCommand = new RelayCommand<Grade>(this.CancelGrade);
                }

                return cancelGradeCommand;
            }
        }

        public void CancelGrade(Grade grade)
        {
            GradeBLL.CancelGrade(SelectedGrade);
            Grades = GradeBLL.GetGradesByStudentSubject(selectedStudent, selectedSubject);
            MessageBox.Show("Grade Canceled");
        }
    }
}
