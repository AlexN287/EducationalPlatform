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
    public class AbsenceBLL
    {
        public AbsenceBLL() { }
        private static AbsenceDAL absenceDAL = new AbsenceDAL();
        public static void AddAbsence(Absence absence)
        {
            try
            {
                if (absence == null)
                {
                    throw new ArgumentNullException(nameof(absence), "Absence cannot be null.");
                }

                absenceDAL.AddAbsence(absence);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a absence: " + ex.Message);
                throw;
            }
        }

        public static void MotivateAbsence(Absence absence)
        {
            try
            {
                if (absence == null)
                {
                    throw new ArgumentNullException(nameof(absence), "Absence cannot be null.");
                }

                absenceDAL.MotivateAbsence(absence);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while motivating an absence: " + ex.Message);
                throw;
            }
        }

        public static ObservableCollection<Absence> GetAllAbsencesByStudent(Student student)
        {
            return absenceDAL.GetAbsencesByStudent(student);
        }

        public static ObservableCollection<Absence> GetStudentSubjectAbsences(Student student, Subject subject)
        {
            return absenceDAL.GetStudentSubjectAbsences(student, subject);
        }

    }
}
