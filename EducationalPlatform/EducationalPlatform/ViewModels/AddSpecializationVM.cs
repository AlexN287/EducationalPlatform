using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Packaging;
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
    public class AddSpecializationVM: ViewModelBase
    {
        public AddSpecializationVM()
        {
            subjects = SubjectBLL.GetAllSubjects();
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
                    NotifyPropertyChanged(nameof(Name));
                }
            }
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
            Specialization newSpecialization = new Specialization(Name);
            int specializationID = SpecializationBLL.AddSpecialization(newSpecialization);
            MessageBox.Show("Specialization Added");
        }
    }
}
