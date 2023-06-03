using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3_MVP.Models.DataAccessLayer;
using Tema3_MVP.Models.EntityLayer;

namespace Tema3_MVP.Models.BusinessLogicLayer
{
    public class ClassStudentBLL
    {
        public ClassStudentBLL() { }
        private static ClassStudentDAL classStudentDAL = new ClassStudentDAL();
        public static void AddClassStudent(ClassStudents classStudents)
        {
            try
            {
                if (classStudents == null)
                {
                    throw new ArgumentNullException(nameof(classStudents), "ClassStudent cannot be null.");
                }

                classStudentDAL.AddClassStudent(classStudents);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a classStudent: " + ex.Message);
                throw;
            }
        }

        public static void UpdateClassStudent(ClassStudents classStudent)
        {
            try
            {
                if (classStudent == null)
                {
                    throw new ArgumentNullException(nameof(classStudent), "ClassStudent cannot be null.");
                }

                classStudentDAL.UpdateClassStudent(classStudent);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating a classStudent: " + ex.Message);
                throw;
            }
        }
    }
}
