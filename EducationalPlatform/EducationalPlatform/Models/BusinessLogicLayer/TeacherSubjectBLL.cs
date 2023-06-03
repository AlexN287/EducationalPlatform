using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Tema3_MVP.Models.DataAccessLayer;
using Tema3_MVP.Models.EntityLayer;

namespace Tema3_MVP.Models.BusinessLogicLayer
{
    public class TeacherSubjectBLL
    {
        public TeacherSubjectBLL()
        {
            
        }

        private static TeacherSubjectDAL teacherSubjectDAL = new TeacherSubjectDAL();
        public static void AddTeacherSubject(TeacherSubject teacherSubject)
        {
            try
            {
                if (teacherSubject == null)
                {
                    throw new ArgumentNullException(nameof(teacherSubject), "teacherSubject cannot be null.");
                }

                teacherSubjectDAL.AddTeacherSubject(teacherSubject);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a teacherSubject: " + ex.Message);
                throw;
            }
        }
    }
}
