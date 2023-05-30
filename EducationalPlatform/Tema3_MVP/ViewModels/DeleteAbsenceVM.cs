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
    public class DeleteAbsenceVM: ViewModelBase
    {
        public Teacher currentTeacher;
        public DeleteAbsenceVM(Teacher teacher)
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

        private ObservableCollection<Absence> absences;
        public ObservableCollection<Absence> Absences
        {
            get { return absences; }
            set
            {
                if (absences != value)
                {
                    absences = value;
                    NotifyPropertyChanged(nameof(absences));
                }
            }
        }

        private Absence selectedAbsence;
        public Absence SelectedAbsence
        {
            get { return selectedAbsence; }
            set
            {
                if (selectedAbsence != value)
                {
                    selectedAbsence = value;
                    NotifyPropertyChanged(nameof(selectedAbsence));
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
                    studentSelectionCommand = new RelayCommand<Student>(this.UpdateAbsences);
                }

                return studentSelectionCommand;
            }
        }

        public void UpdateAbsences(Student student)
        {
            Absences = AbsenceBLL.GetAllAbsencesByStudent(selectedStudent);
        }

        public ICommand motivateAbsenceCommand { get; set; }
        public ICommand MotivateAbsenceCommand
        {
            get
            {
                if (motivateAbsenceCommand == null)
                {
                    motivateAbsenceCommand = new RelayCommand<Absence>(this.MotivateAbsence);
                }

                return motivateAbsenceCommand;
            }
        }

        public void MotivateAbsence(Absence absence)
        {
            bool isMotivated = false;
            AbsenceBLL.MotivateAbsence(selectedAbsence);
            Absences = AbsenceBLL.GetAllAbsencesByStudent(selectedStudent);
            MessageBox.Show("Absence Motivated");
        }
    }
}
