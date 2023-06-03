using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3_MVP.Models.DataAccessLayer;
using Tema3_MVP.Models.EntityLayer;

namespace Tema3_MVP.Models.BusinessLogicLayer
{
    public class SpecializationSubjectBLL
    {
        public SpecializationSubjectBLL() { }
        private static SpecializationSubjectDAL specializationSubjectDAL = new SpecializationSubjectDAL();
        public static void AddSpecializatioSubject(SpecializationSubject specializationSubject)
        {
            try
            {
                if (specializationSubject == null)
                {
                    throw new ArgumentNullException(nameof(specializationSubject), "Subject cannot be null.");
                }

                specializationSubjectDAL.AddSpecializationSubject(specializationSubject);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a SpecializationSubject: " + ex.Message);
                throw;
            }
        }

        public static bool GetThesisStatus(Subject subject)
        {
            return specializationSubjectDAL.GetThesisStatus(subject.SubjectID);
        }
    }
}
