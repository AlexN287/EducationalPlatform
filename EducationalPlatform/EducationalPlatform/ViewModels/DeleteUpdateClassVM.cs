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
using CommunityToolkit.Mvvm.Input;

namespace Tema3_MVP.ViewModels
{
    public class DeleteUpdateClassVM: ViewModelBase
    {
        public DeleteUpdateClassVM()
        {
            classes = ClassBLL.GetAllClasses();
            teachers = TeacherBLL.GetAllTeachers();
            specializations = SpecializationBLL.GetAllSpecializations();
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

        private string studyYear;
        private string section;
        public string StudyYear
        {
            get { return studyYear; }
            set
            {
                if (studyYear != value)
                {
                    studyYear = value;
                    NotifyPropertyChanged(nameof(StudyYear));
                }

            }
        }
        public string Section
        {
            get { return section; }
            set
            {
                if (section != value)
                {
                    section = value;
                    NotifyPropertyChanged(nameof(Section));
                }

            }
        }

        private ObservableCollection<Specialization> specializations;
        public ObservableCollection<Specialization> Specializations
        {
            get { return specializations; }
            set
            {
                if (specializations != value)
                {
                    specializations = value;
                    NotifyPropertyChanged(nameof(specializations));
                }

            }
        }

        private Specialization selectedSpecialization;
        public Specialization SelectedSpecialization
        {
            get { return selectedSpecialization; }
            set
            {
                if (selectedSpecialization != value)
                {
                    selectedSpecialization = value;
                    NotifyPropertyChanged(nameof(SelectedSpecialization));
                }

            }
        }
        private ICommand updateClassCommand { get; set; }
        public ICommand UpdateClassCommand
        {
            get
            {
                if (updateClassCommand == null)
                {
                    updateClassCommand = new RelayCommand(this.UpdateClass);
                }

                return updateClassCommand;
            }
        }

        private void UpdateClass()
        {
            if (selectedTeacher != null)
            {
                Class classToUpdate = new Class(selectedClass.ClassID,selectedTeacher.teacherID, int.Parse(studyYear), selectedSpecialization.specializationID, section[0]);
                ClassBLL.UpdateClass(classToUpdate);
                MessageBox.Show("class updated");
            }
            else
            {
                MessageBox.Show("Please Select a teacher");
            }
        }

        private ICommand deleteClassCommand { get; set; }
        public ICommand DeleteClassCommand
        {
            get
            {
                if (deleteClassCommand == null)
                {
                    deleteClassCommand = new RelayCommand(this.DeleteClass);
                }

                return deleteClassCommand;
            }
        }

        private void DeleteClass()
        {
            ClassBLL.DeleteClass(selectedClass);
            MessageBox.Show("Class Deleted");
        }

    }
}
