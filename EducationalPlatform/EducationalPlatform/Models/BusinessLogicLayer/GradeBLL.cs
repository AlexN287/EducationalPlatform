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
    public class GradeBLL
    {
        public GradeBLL() { }
        private static GradeDAL gradeDAL = new GradeDAL();

        public static void AddGrade(Grade grade)
        {
            try
            {
                if (grade == null)
                {
                    throw new ArgumentNullException(nameof(grade), "Grade cannot be null.");
                }

                gradeDAL.AddGrade(grade);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a grade: " + ex.Message);
                throw;
            }
        }

        public static void CancelGrade(Grade grade)
        {
            try
            {
                if (grade == null)
                {
                    throw new ArgumentNullException(nameof(grade), "Grade cannot be null.");
                }

                gradeDAL.CancelGrade(grade);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while canceling a grade: " + ex.Message);
                throw;
            }
        }

        public static ObservableCollection<Grade> GetGradesByStudentSubject(Student student, Subject subject)
        {
            return gradeDAL.GetGradesByStudentSubject(student, subject);
        }
    }
}
