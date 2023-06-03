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
    public class ClassBLL
    {
        public ClassBLL() { }
        private static ClassDAL classDAL = new ClassDAL();

        public static ObservableCollection<Class> GetAllClasses()
        {
            return classDAL.GetAllClasses();
        }
        public static void AddClass(Class item)
        {
            try
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item), "class cannot be null.");
                }

                classDAL.AddClass(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a class: " + ex.Message);
                throw;
            }
        }

        public static void DeleteClass(Class item)
        {
            try
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item), "Class cannot be null.");
                }

                classDAL.DeleteClass(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting a class: " + ex.Message);
                throw;
            }
        }
        public static void UpdateClass(Class item)
        {
            try
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item), "Class cannot be null.");
                }

                classDAL.UpdateClass(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating a class: " + ex.Message);
                throw;
            }
        }

        public static Class GetStudentClass(Student student)
        {
            return classDAL.GetStudentClass(student);
        }
    }
}
