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
    public class TeacherBLL
    {
        public TeacherBLL() { }
        private static TeacherDAL teacherDAL = new TeacherDAL();

        public static ObservableCollection<Teacher> GetAllTeachers()
        {
            return teacherDAL.GetAllTeachers();
        }

        public static ObservableCollection<Subject> GetTeacherSubjects(Teacher teacher)
        {
            return teacherDAL.GetTeacherSubjects(teacher);
        }

        public static ObservableCollection<Class> GetTeacherClasses(Teacher teacher)
        {
            return teacherDAL.GetTeacherClasses(teacher);
        }

        public static ObservableCollection<Subject> GetTeacherSubjectsByClass(Teacher teacher, Class c)
        {
            return teacherDAL.GetTeacherSubjectsByClass(teacher,c);
        }

        public static Teacher GetTeacherByUser(User user)
        {
            return teacherDAL.GetTeacherByUser(user);
        }
        public static int AddTeacher(Teacher teacher)
        {
            try
            {
                if (teacher == null)
                {
                    throw new ArgumentNullException(nameof(teacher), "Teacher cannot be null.");
                }

                int? k = teacherDAL.AddTeacher(teacher);

                if (k.HasValue)
                {
                    return k.Value;
                }
                else
                {
                    throw new Exception("Failed to retrieve the user ID after adding the teacher.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a teacher: " + ex.Message);
                throw;
            }
        }
        public static void DeleteTeacher(Teacher teacher)
        {
            try
            {
                if (teacher == null)
                {
                    throw new ArgumentNullException(nameof(teacher), "Teacher cannot be null.");
                }

                teacherDAL.DeleteTeacher(teacher);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting a teacher: " + ex.Message);
                throw;
            }
        }

        public static void UpdateTeacher(Teacher teacher)
        {
            try
            {
                if (teacher == null)
                {
                    throw new ArgumentNullException(nameof(teacher), "Teacher cannot be null.");
                }

                teacherDAL.UpdateTeacher(teacher);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating a teacher: " + ex.Message);
                throw;
            }
        }
    }
}
