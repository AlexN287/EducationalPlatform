using System;
using System.Collections.Generic;
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
    public class AddSubjectVM: ViewModelBase
    {
        public AddSubjectVM() { }
        private SubjectBLL subjectBLL = new SubjectBLL();

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

        private ICommand addSubjectCommand { get; set; }
        public ICommand AddSubjectCommand
        {
            get
            {
                if (addSubjectCommand == null)
                {
                    addSubjectCommand = new RelayCommand(this.AddSubject);
                }

                return addSubjectCommand;
            }
        }

        private void AddSubject()
        {
            Subject newSubject = new Subject(Name);
            subjectBLL.AddSubject(newSubject);
            MessageBox.Show("Subject Added");
        }
    }
}
