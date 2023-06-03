using CommunityToolkit.Mvvm.Input;
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
        private Teacher currentTeacher;
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

        private ICommand classSelectionCommand { get; set; }
        public ICommand ClassSelectionCommand
        {
            get
            {
                if (classSelectionCommand == null)
                {
                    classSelectionCommand = new RelayCommand(this.UpdateSubjectsListView);
                }

                return classSelectionCommand;
            }
        }

        private void ChooseMaterial()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";

            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
            }
        }
        private void UpdateSubjectsListView()
        {
            Subjects = TeacherBLL.GetTeacherSubjectsByClass(currentTeacher, selectedClass);
        }

        private ICommand chooseMaterialCommand { get; set; }
        public ICommand ChooseMaterialCommand
        {
            get
            {
                if (chooseMaterialCommand == null)
                {
                    chooseMaterialCommand = new RelayCommand(this.ChooseMaterial);
                }

                return chooseMaterialCommand;
            }
        }

        private ICommand addMaterialCommand { get; set; }
        public ICommand AddMaterialCommand
        {
            get
            {
                if (addMaterialCommand == null)
                {
                    addMaterialCommand = new RelayCommand(this.AddMaterial);
                }

                return addMaterialCommand;
            }
        }

        public void AddMaterial()
        {
            Courses course = new Courses(selectedClass.classID, selectedSubject.subjectID, currentTeacher.teacherID);
            TeacherMaterial newTeacherMaterial = new TeacherMaterial(Name, FilePath);
            CourseBLL.InsertTeacherMaterialAndSetCourse(course, newTeacherMaterial);
            MessageBox.Show("Material Added");
        }
    }
}
