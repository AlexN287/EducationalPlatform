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

        public ICommand updateSpecializationCommand { get; set; }

        public ICommand UpdateSpecializationCommand
        {
            get
            {
                if (updateSpecializationCommand == null)
                {
                    updateSpecializationCommand = new RelayCommand<Specialization>(this.UpdateSpecialization);
                }

                return updateSpecializationCommand;
            }
        }

        public void UpdateSpecialization(Specialization subject)
        {
            Specialization subject1 = new Specialization(selectedSpecialization.SpecializationID, name);
            SpecializationBLL.UpdateSpecialization(subject1);
            Specializations = SpecializationBLL.GetAllSpecializations();
            MessageBox.Show("Specialization updated");
        }

        public ICommand deleteSpecializationCommand { get; set; }

        public ICommand DeleteSpecializationCommand
        {
            get
            {
                if (deleteSpecializationCommand == null)
                {
                    deleteSpecializationCommand = new RelayCommand<Specialization>(this.deleteSpecialization);
                }

                return deleteSpecializationCommand;
            }
        }

        public void deleteSpecialization(Specialization subject)
        {
            SpecializationBLL.DeleteSpecialization(selectedSpecialization);
            Specializations = SpecializationBLL.GetAllSpecializations();
            MessageBox.Show("Specialization Deleted");
        }
    }
}
