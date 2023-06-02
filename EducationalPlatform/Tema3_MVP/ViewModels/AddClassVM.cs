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
using Tema3_MVP.Models.EntityLayer;
using System.Xml.Serialization;
using CommunityToolkit.Mvvm.Input;

namespace Tema3_MVP.ViewModels
{
    public class AddClassVM : ViewModelBase
    {
        public AddClassVM()
        {
            teachers = TeacherBLL.GetAllTeachers();
            specializations = SpecializationBLL.GetAllSpecializations();
        }

        private ObservableCollection<Teacher> teachers;
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
        private ICommand addClassCommand { get; set; }
        public ICommand AddClassCommand
        {
            get
            {
                if (addClassCommand == null)
                {
                    addClassCommand = new RelayCommand(this.AddClass);
                }

                return addClassCommand;
            }
        }

        private void AddClass()
        {
            if (selectedTeacher != null)
            {
                Class newClass = new Class(selectedTeacher.teacherID, int.Parse(studyYear), selectedSpecialization.specializationID, section[0]);
                ClassBLL.AddClass(newClass);
                MessageBox.Show("class Added");
            }
            else
            {
                MessageBox.Show("Please Select a teacher");
            }
        }
    }
}

    

