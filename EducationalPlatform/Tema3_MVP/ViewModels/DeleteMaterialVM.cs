using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
using Tema3_MVP.Commands;
using Tema3_MVP.Models.BusinessLogicLayer;
using Tema3_MVP.Models.EntityLayer;

namespace Tema3_MVP.ViewModels
{
    public class DeleteMaterialVM: ViewModelBase
    {
        private Teacher currentTeacher;
        public DeleteMaterialVM(Teacher teacher)
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

        private ICommand classSelectionCommand { get; set; }
        public ICommand ClassSelectionCommand
        {
            get
            {
                if (classSelectionCommand == null)
                {
                    classSelectionCommand = new RelayCommand(this.UpdateSubjects);
                }

                return classSelectionCommand;
            }
        }

        private void UpdateSubjects()
        {
            Subjects = TeacherBLL.GetTeacherSubjectsByClass(currentTeacher, selectedClass);
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

        private ICommand subjectSelectionCommand { get; set; }
        public ICommand SubjectSelectionCommand
        {
            get
            {
                if (subjectSelectionCommand == null)
                {
                    subjectSelectionCommand = new RelayCommand(this.UpdateMaterialsListView);
                }

                return subjectSelectionCommand;
            }
        }

        private void UpdateMaterialsListView()
        {
            Courses c = new Courses(selectedClass.classID, selectedSubject.subjectID, currentTeacher.teacherID); ;
            Materials = CourseBLL.GetMaterialForClassSubjectTeacher(c);
        }
        private ICommand deleteMaterialCommand { get; set; }
        public ICommand DeleteMaterialCommand
        {
            get
            {
                if (deleteMaterialCommand == null)
                {
                    deleteMaterialCommand = new RelayCommand(this.DeleteMaterial);
                }

                return deleteMaterialCommand;
            }
        }

        private void DeleteMaterial()
        {
            CourseBLL.DeleteMaterial(selectedMaterial);
            
            MessageBox.Show("Material deleted");
        }
    }
}
