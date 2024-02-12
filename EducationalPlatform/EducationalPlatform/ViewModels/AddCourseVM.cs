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
    public class AddCourseVM: ViewModelBase
    {
        public AddCourseVM() 
        {
            classes = ClassBLL.GetAllClasses();
            subjects = SubjectBLL.GetAllSubjects();
            teachers = TeacherBLL.GetAllTeachers();
        }

        public ObservableCollection<Class> classes;

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

        private ICommand addCourseCommand { get; set; }
        public ICommand AddCourseCommand
        {
            get
            {
                if (addCourseCommand == null)
                {
                    addCourseCommand = new RelayCommand(this.AddCourse);
                }

                return addCourseCommand;
            }
        }

        private void AddCourse()
        {
            Courses newCourse = new Courses(selectedClass.classID, selectedSubject.subjectID, selectedTeacher.teacherID); 
            CourseBLL.AddCourseWithoutMaterial(newCourse);
            MessageBox.Show("Course Added");
        }
    }
}
