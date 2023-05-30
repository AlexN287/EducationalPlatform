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

namespace Tema3_MVP.ViewModels
{
    public class AddSubjectVM: ViewModelBase
    {
        public AddSubjectVM() { }
        public SubjectBLL subjectBLL = new SubjectBLL();
        public Subject newSubject;

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

        public ICommand addSubjectCommand { get; set; }

        public ICommand AddSubjectCommand
        {
            get
            {
                if (addSubjectCommand == null)
                {
                    addSubjectCommand = new RelayCommand<Subject>(this.AddSubject);
                }

                return addSubjectCommand;
            }
        }

        public void AddSubject(Subject subject)
        {
            Subject subject1 = new Subject(Name);
            subjectBLL.AddSubject(subject1);
            MessageBox.Show("Subject Added");
        }
    }
}
