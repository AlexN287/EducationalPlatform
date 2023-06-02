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
    public class DeleteUpdateSpecializationVM: ViewModelBase
    {
        
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

        public DeleteUpdateSpecializationVM()
        {
            specializations = SpecializationBLL.GetAllSpecializations();
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
                    NotifyPropertyChanged(nameof(Specialization));
                }

            }
        }

        private ICommand updateSpecializationCommand { get; set; }
        public ICommand UpdateSpecializationCommand
        {
            get
            {
                if (updateSpecializationCommand == null)
                {
                    updateSpecializationCommand = new RelayCommand(this.UpdateSpecialization);
                }

                return updateSpecializationCommand;
            }
        }

        private void UpdateSpecialization()
        {
            Specialization specialization = new Specialization(selectedSpecialization.SpecializationID, name);
            SpecializationBLL.UpdateSpecialization(specialization);
            Specializations = SpecializationBLL.GetAllSpecializations();
            MessageBox.Show("Specialization updated");
        }

        private ICommand deleteSpecializationCommand { get; set; }

        public ICommand DeleteSpecializationCommand
        {
            get
            {
                if (deleteSpecializationCommand == null)
                {
                    deleteSpecializationCommand = new RelayCommand(this.deleteSpecialization);
                }

                return deleteSpecializationCommand;
            }
        }

        private void deleteSpecialization()
        {
            SpecializationBLL.DeleteSpecialization(selectedSpecialization);
            Specializations = SpecializationBLL.GetAllSpecializations();
            MessageBox.Show("Specialization Deleted");
        }
    }
}
