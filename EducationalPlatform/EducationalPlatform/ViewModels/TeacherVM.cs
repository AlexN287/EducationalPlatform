using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tema3_MVP.Commands;
using Tema3_MVP.Models.BusinessLogicLayer;
using Tema3_MVP.Models.EntityLayer;
using Tema3_MVP.Views;

namespace Tema3_MVP.ViewModels
{
    public class TeacherVM: ViewModelBase
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

        public Teacher currentTeacher;
        public TeacherVM(User user)
        {
            MenuItemSelectedCommand = new RelayCommand<string>(OnMenuItemSelected);
            currentTeacher = TeacherBLL.GetTeacherByUser(user);
        }
        private void OnMenuItemSelected(string menuItem)
        {
            switch (menuItem)
            {
                case "AddAbsence":
                    AddAbsenceView addAbsenceView = new AddAbsenceView(currentTeacher);
                    addAbsenceView.Show();
                    break;
                case "MotivateAbsence":
                    DeleteAbsenceView deleteAbsenceView = new DeleteAbsenceView(currentTeacher);
                    deleteAbsenceView.Show();   
                    break;
                case "AddGrade":
                    AddGradeView addGradeView = new AddGradeView(currentTeacher);
                    addGradeView.Show();
                    break;
                case "CancelGrade":
                    CancelGradeView cancelGradeView = new CancelGradeView(currentTeacher);
                    cancelGradeView.Show();
                    break;
                case "AddMaterial":
                    AddMaterialView addMaterialView = new AddMaterialView(currentTeacher);  
                    addMaterialView.Show();
                    break;
                case "DeleteMaterial":
                    DeleteMaterialView deleteMaterialView = new DeleteMaterialView(currentTeacher); 
                    deleteMaterialView.Show();
                    break;
                case "AddCourse":
                    AddCourseView addCourseView = new AddCourseView();
                    addCourseView.Show();
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
