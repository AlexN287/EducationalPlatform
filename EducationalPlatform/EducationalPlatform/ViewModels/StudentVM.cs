using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tema3_MVP.Commands;
using Tema3_MVP.Models.BusinessLogicLayer;
using Tema3_MVP.Models.EntityLayer;
using System.Runtime.InteropServices;
using System.Windows;
using CommunityToolkit.Mvvm.Input;

namespace Tema3_MVP.ViewModels
{
    public class StudentVM: ViewModelBase
    {
        private Student currentStudent;
        public StudentVM(User user)
        {
            currentStudent = StudentBLL.GetStudentByUser(user);
            Subjects = SubjectBLL.GetStudentSubjects(currentStudent);
            studentClass = ClassBLL.GetStudentClass(currentStudent);
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

        private ObservableCollection<TeacherMaterial> materials;
        public ObservableCollection<TeacherMaterial> Materials
        {
            get { return materials; }
            set
            {
                if (materials != value)
                {
                    materials = value;
                    NotifyPropertyChanged(nameof(materials));
                }

            }
        }

        private TeacherMaterial selectedMaterial;
        public TeacherMaterial SelectedMaterial
        {
            get { return selectedMaterial; }
            set
            {
                if (selectedMaterial != value)
                {
                    selectedMaterial = value;
                    NotifyPropertyChanged(nameof(SelectedMaterial));
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

        [DllImport("shell32.dll", SetLastError = true)]
        private static extern bool ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd);
        private void DownloadMaterial()
        {

            if (SelectedSubject == null)
            {
                MessageBox.Show("You must select a subject");
                return;
            }

            if (SelectedMaterial == null)
            {
                MessageBox.Show("You must select a material");
                return;
            }

            string filePath = SelectedMaterial.FilePath;

            try
            {
                ShellExecute(IntPtr.Zero, "open", filePath, null, null, 5);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured downloading material");
            }
        }

        public ICommand openCommand { get; set; }
        public ICommand OpenCommand
        {
            get
            {
                if (openCommand == null)
                {
                    openCommand = new RelayCommand(this.DownloadMaterial);
                }

                return openCommand;
            }
        }

        private ICommand subjectSelectionCommand { get; set; }
        public ICommand SubjectSelectionCommand
        {
            get
            {
                if (subjectSelectionCommand == null)
                {
                    subjectSelectionCommand = new RelayCommand(this.UpdateListViews);
                }

                return subjectSelectionCommand;
            }
        }

        private Class studentClass;
        private void UpdateListViews()
        {
            Grades = GradeBLL.GetGradesByStudentSubject(currentStudent, selectedSubject); 
            Absences = AbsenceBLL.GetStudentSubjectAbsences(currentStudent, selectedSubject);
            Materials = CourseBLL.GetTeacherMaterialForClassAndSubject(studentClass, selectedSubject);
        }

        
    }
}
