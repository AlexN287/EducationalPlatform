using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3_MVP.Models.DataAccessLayer;
using Tema3_MVP.Models.EntityLayer;

namespace Tema3_MVP.Models.BusinessLogicLayer
{
    public class CourseBLL
    {
        public CourseBLL() { }

        private static CourseDAL courseDAL = new CourseDAL();
        public static void AddCourse(Courses courses)
        {
            try
            {
                if (courses == null)
                {
                    throw new ArgumentNullException(nameof(courses), "Course cannot be null.");
                }

                courseDAL.AddCourse(courses);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a course: " + ex.Message);
                throw;
            }
        }

        public static void AddCourseWithoutMaterial(Courses courses)
        {
            try
            {
                if (courses == null)
                {
                    throw new ArgumentNullException(nameof(courses), "Course cannot be null.");
                }

                courseDAL.AddCourseWithoutMaterial(courses);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a course: " + ex.Message);
                throw;
            }
        }

        public static ObservableCollection<TeacherMaterial> GetTeacherMaterialForClassAndSubject(Class c, Subject subject)
        {
            return courseDAL.GetTeacherMaterialForClassAndSubject(c, subject);
        }

        public static void InsertTeacherMaterialAndSetCourse(Courses courses, TeacherMaterial teacherMaterial)
        {
            courseDAL.InsertTeacherMaterialAndSetCourse(courses, teacherMaterial);
        }

        public static ObservableCollection<TeacherMaterial> GetMaterialForClassSubjectTeacher(Courses c)
        {
            return courseDAL.GetMaterialForClassSubjectTeacher(c);
        }

        public static void DeleteMaterial(TeacherMaterial teacherMaterial)
        {
            courseDAL.DeleteMaterial(teacherMaterial);
        }
    }
}
