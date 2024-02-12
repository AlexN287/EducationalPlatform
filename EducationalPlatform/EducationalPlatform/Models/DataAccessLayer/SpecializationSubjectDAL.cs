using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3_MVP.Models.EntityLayer;
using Tema3_MVP.Models.Models;

namespace Tema3_MVP.Models.DataAccessLayer
{
    public class SpecializationSubjectDAL
    {
        public void AddSpecializationSubject(SpecializationSubject specializationSubject)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddSpecializationSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@subject_id", specializationSubject.subjectID);
                cmd.Parameters.AddWithValue("@specialization_id", specializationSubject.specializationID);
                cmd.Parameters.AddWithValue("@has_thesis", specializationSubject.hasThesis);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public bool GetThesisStatus(int subjectId)
        {
            bool isFinal = false;

            using (SqlConnection connection = DALHelper.Connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand("GetThesisStatus", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@subjectId", subjectId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        isFinal = (bool)reader["has_thesis"];
                    }
                }
            }

            return isFinal == true;
        }
    }


}
