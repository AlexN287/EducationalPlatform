using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tema3_MVP.Commands;
using Tema3_MVP.Models.EntityLayer;
using Tema3_MVP.Views;

namespace Tema3_MVP.ViewModels
{
    public class AdminVM: ViewModelBase
    {
        
        private object selectedMenuItemContent;

        public object SelectedMenuItemContent
        {
            get { return selectedMenuItemContent; }
            set
            {
                selectedMenuItemContent = value;
                NotifyPropertyChanged(nameof(SelectedMenuItemContent));
            }
        }
        public ICommand MenuItemSelectedCommand { get; set; }
        public AdminVM()
        {
            MenuItemSelectedCommand = new RelayCommand<string>(OnMenuItemSelected);
        }
        private void OnMenuItemSelected(string menuItem)
        {
            switch (menuItem)
            {
                case "AddStudent":
                    AddStudentView addStudentView = new AddStudentView();
                    addStudentView.Show();                    
                    break;
                case "AddTeacher":
                    AddTeacherView addTeacherView = new AddTeacherView();
                    addTeacherView.Show();
                    break;
                case "AddSubject":
                    AddSubjectView addSubjectView = new AddSubjectView();   
                    addSubjectView.Show();
                    break;
                case "AddClass":
                    AddClassView addClassView = new AddClassView();
                    addClassView.Show();
                    break;
                case "AddSpecialization":
                    AddSpecializationView addSpecializationView = new AddSpecializationView();  
                    addSpecializationView.Show();
                    break;
                case "AddUser":
                    AddUserView addUserView = new AddUserView();
                    addUserView.Show();
                    break;
                case "AddCourse":
                    AddCourseView addCourseView = new AddCourseView();  
                    addCourseView.Show();
                    break;
                case "AddSpecializationSubject":
                    AddSpecializationSubjectView addSpecializationSubjectView = new AddSpecializationSubjectView();
                    addSpecializationSubjectView.Show();
                    break;
                case "DeleteStudent":
                    DeleteUpdateStudent deleteUpdateStudent = new DeleteUpdateStudent();
                    deleteUpdateStudent.Show();
                    break;
                case "DeleteTeacher":
                    DeleteUpdateTeacherView deleteUpdate = new DeleteUpdateTeacherView();
                    deleteUpdate.Show();
                    break;
                case "DeleteSubject":
                    DeleteUpdateSubjectView deleteUpdateSubjectView = new DeleteUpdateSubjectView();
                    deleteUpdateSubjectView.Show();
                    break;
                case "DeleteClass":
                    DeleteUpdateClassView deleteUpdateClassView = new DeleteUpdateClassView();
                    deleteUpdateClassView.Show();
                    break;
                case "DeleteSpecialization":
                    DeleteUpdateSpecialization deleteUpdateSpecialization = new DeleteUpdateSpecialization();
                    deleteUpdateSpecialization.Show();
                    break;
                case "DeleteUser":
                    DeleteUpdateUserView deleteUpdateUserView = new DeleteUpdateUserView();
                    deleteUpdateUserView.Show();
                    break;
                case "DeleteCourse":
                    DeleteUpdateCoursesView deleteUpdateCourse = new DeleteUpdateCoursesView();
                    deleteUpdateCourse.Show();
                    break;
                default:
                    // Handle unrecognized menu item
                    break;
            }
        }
      
    }
}
