using Microsoft.Win32;
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
    public class AddMaterialVM: ViewModelBase
    {
        public Teacher currentTeacher;
        public AddMaterialVM(Teacher teacher)
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

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    NotifyPropertyChanged(nameof(name));
                }
            }
        }

        private string filepath;
        public string FilePath
        {
            get { return filepath; }
            set
            {
                if (filepath != value)
                {
                    filepath = value;
                    NotifyPropertyChanged(nameof(filepath));
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

        public void ChooseMaterial(TeacherMaterial teacherMaterial)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";

            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
            }
        }
        public void UpdateSubjects(Class subject)
        {
            Subjects = TeacherBLL.GetTeacherSubjectsByClass(currentTeacher, selectedClass);
        }

        public ICommand chooseMaterialCommand { get; set; }
        public ICommand ChooseMaterialCommand
        {
            get
            {
                if (chooseMaterialCommand == null)
                {
                    chooseMaterialCommand = new RelayCommand<TeacherMaterial>(this.ChooseMaterial);
                }

                return chooseMaterialCommand;
            }
        }

        public ICommand addMaterialCommand { get; set; }
        public ICommand AddMaterialCommand
        {
            get
            {
                if (addMaterialCommand == null)
                {
                    addMaterialCommand = new RelayCommand<TeacherMaterial>(this.AddMaterial);
                }

                return addMaterialCommand;
            }
        }

        public void AddMaterial(TeacherMaterial teacherMaterial)
        {
            Courses courses = new Courses(selectedClass.classID, selectedSubject.subjectID, currentTeacher.teacherID);
            TeacherMaterial teacherMaterial1 = new TeacherMaterial(Name, FilePath);
            CourseBLL.InsertTeacherMaterialAndSetCourse(courses, teacherMaterial1);
            MessageBox.Show("Material Added");
        }
    }
}
