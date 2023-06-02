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
    public class DeleteUpdateSubjectVM: ViewModelBase
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

        public DeleteUpdateSubjectVM()
        {
            subjects = SubjectBLL.GetAllSubjects();
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

        private ICommand updateSubjectCommand { get; set; }
        public ICommand UpdateSubjectCommand
        {
            get
            {
                if (updateSubjectCommand == null)
                {
                    updateSubjectCommand = new RelayCommand(this.UpdateSubject);
                }

                return updateSubjectCommand;
            }
        }
        private void UpdateSubject()
        {
            Subject subject = new Subject(selectedSubject.SubjectID, name);
            SubjectBLL.UpdateSubject(subject);
            Subjects = SubjectBLL.GetAllSubjects();
            MessageBox.Show("Subject updated");
        }

        private ICommand deleteSubjectCommand { get; set; }
        public ICommand DeleteSubjectCommand
        {
            get
            {
                if (deleteSubjectCommand == null)
                {
                    deleteSubjectCommand = new RelayCommand(this.deleteSubject);
                }

                return deleteSubjectCommand;
            }
        }

        private void deleteSubject()
        {
            SubjectBLL.DeleteSubject(selectedSubject);
            Subjects = SubjectBLL.GetAllSubjects();
            MessageBox.Show("Subject Deleted");
        }
    }
}
