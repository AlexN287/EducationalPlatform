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
    public class AddAbsenceVM: ViewModelBase
    {
        public Teacher currentTeacher;
        public AddAbsenceVM(Teacher teacher) 
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

        private string semester;
        public string Semester
        {
            get { return semester; }
            set
            {
                if (semester != value)
                {
                    semester = value;
                    NotifyPropertyChanged(nameof(semester));
                }

            }
        }

        private string date;
        public string Date
        {
            get { return date; }
            set
            {
                if (date != value)
                {
                    date = value;
                    NotifyPropertyChanged(nameof(date));
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

        public ICommand addAbsenceCommand { get; set; }
        public ICommand AddAbsenceCommand
        {
            get
            {
                if (addAbsenceCommand == null)
                {
                    addAbsenceCommand = new RelayCommand<Absence>(this.AddAbsence);
                }

                return addAbsenceCommand;
            }
        }

        public void AddAbsence(Absence absence)
        {
            bool isMotivated = false;
            Absence absence1 = new Absence(selectedStudent.studentID, int.Parse(semester),selectedSubject.subjectID, DateTime.Parse(date), isMotivated);
            AbsenceBLL.AddAbsence(absence1);
            MessageBox.Show("Absence Added");
        }
    }
}
