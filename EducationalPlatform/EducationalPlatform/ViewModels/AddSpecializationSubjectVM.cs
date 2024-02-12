using CommunityToolkit.Mvvm.Input;
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
    public class AddSpecializationSubjectVM: ViewModelBase
    {
        public AddSpecializationSubjectVM() 
        {
            subjects = SubjectBLL.GetAllSubjects();
            specializations = SpecializationBLL.GetAllSpecializations();
        }
        private ICommand addSpecializationCommand { get; set; }
        public ICommand AddSpecializationCommand
        {
            get
            {
                if (addSpecializationCommand == null)
                {
                    addSpecializationCommand = new RelayCommand(this.AddSpecialization);
                }

                return addSpecializationCommand;
            }
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

        private bool _hasThesis;
        public bool HasThesis
        {
            get { return _hasThesis; }
            set
            {
                if (_hasThesis != value)
                {
                    _hasThesis = value;
                    NotifyPropertyChanged(nameof(HasThesis));
                }
            }
        }

        private void AddSpecialization()
        {
            SpecializationSubject newSpecializationSubject = new SpecializationSubject(selectedSpecialization.specializationID, selectedSubject.subjectID, _hasThesis);
            SpecializationSubjectBLL.AddSpecializatioSubject(newSpecializationSubject);
            MessageBox.Show("Specialization Added");
        }
    }
}
