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
    public class SubjectBLL
    {
        public SubjectBLL() { }
        private static SubjectDAL subjectDAL = new SubjectDAL();


        public void AddSubject(Subject subject)
        {
            try
            {
                if (subject == null)
                {
                    throw new ArgumentNullException(nameof(subject), "Subject cannot be null.");
                }

                subjectDAL.AddSubject(subject);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a subject: " + ex.Message);
                throw;
            }
        }

        public static ObservableCollection<Subject> GetAllSubjects()
        {
            return subjectDAL.GetAllSubjects();
        }

        public static ObservableCollection<Subject> GetStudentSubjects(Student student)
        {
            return subjectDAL.GetStudentSubjects(student);
        }

        public static void DeleteSubject(Subject subject)
        {
            try
            {
                if (subject == null)
                {
                    throw new ArgumentNullException(nameof(subject), "Subject cannot be null.");
                }

                subjectDAL.DeleteSubject(subject);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting a subject: " + ex.Message);
                throw;
            }
        }

        public static void UpdateSubject(Subject subject)
        {
            try
            {
                if (subject == null)
                {
                    throw new ArgumentNullException(nameof(subject), "Subject cannot be null.");
                }

                subjectDAL.UpdateSubject(subject);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating a subject: " + ex.Message);
                throw;
            }
        }
    }
}
