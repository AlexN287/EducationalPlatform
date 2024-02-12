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
    public class SpecializationBLL
    {
        public SpecializationBLL() { }

        private static SpecializationDAL specializationDAL = new SpecializationDAL();

        public static ObservableCollection<Specialization> GetAllSpecializations()
        {
            return specializationDAL.GetAllSpecializations();
        }
        public static int AddSpecialization(Specialization specialization)
        {
            try
            {
                if (specialization == null)
                {
                    throw new ArgumentNullException(nameof(specialization), "Specialization cannot be null.");
                }

                int? k = specializationDAL.AddSpecialization(specialization);

                if (k.HasValue)
                {
                    return k.Value;
                }
                else
                {
                    throw new Exception("Failed to retrieve the user ID after adding the specialization.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a subject: " + ex.Message);
                throw;
            }
        }

        public static void DeleteSpecialization(Specialization specialization)
        {
            try
            {
                if (specialization == null)
                {
                    throw new ArgumentNullException(nameof(specialization), "Specialization cannot be null.");
                }

                specializationDAL.DeleteSpecialization(specialization);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting a specialization: " + ex.Message);
                throw;
            }
        }

        public static void UpdateSpecialization(Specialization specialization)
        {
            try
            {
                if (specialization == null)
                {
                    throw new ArgumentNullException(nameof(specialization), "Specialization cannot be null.");
                }

                specializationDAL.UpdateSpecialization(specialization);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating a specialization: " + ex.Message);
                throw;
            }
        }
    }
}
