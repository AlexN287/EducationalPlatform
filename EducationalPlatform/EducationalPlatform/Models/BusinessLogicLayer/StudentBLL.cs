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
    public class StudentBLL
    {
        public StudentBLL() { }
        private static StudentDAL studentDAL = new StudentDAL();
        public static int AddStudent(Student student)
        {
            try
            {
                if (student == null)
                {
                    throw new ArgumentNullException(nameof(student), "Student cannot be null.");
                }

                int? k = studentDAL.AddStudent(student);

                if (k.HasValue)
                {
                    return k.Value;
                }
                else
                {
                    throw new Exception("Failed to retrieve the user ID after adding the student.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a class: " + ex.Message);
                throw;
            }
        }

        public static ObservableCollection<Student> GetAllStudents()
        {
            return studentDAL.GetAllStudents();
        }

        public static ObservableCollection<Student> GetStudentsFromClass(Class c)
        {
            return studentDAL.GetStudentsFromClass(c);
        }

        public static Student GetStudentByUser(User user)
        {
            return studentDAL.GetStudentByUser(user);
        }

        public static void UpdateStudent(Student student)
        {
            try
            {
                if (student == null)
                {
                    throw new ArgumentNullException(nameof(student), "Student cannot be null.");
                }

                studentDAL.UpdateStudent(student);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating a student: " + ex.Message);
                throw;
            }
        }

        public static void DeleteStudent(Student student)
        {
            try
            {
                if (student == null)
                {
                    throw new ArgumentNullException(nameof(student), "Student cannot be null.");
                }

                studentDAL.DeleteStudent(student);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting a student: " + ex.Message);
                throw;
            }
        }
    }
}
