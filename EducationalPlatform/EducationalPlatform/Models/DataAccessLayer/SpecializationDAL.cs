using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3_MVP.Models.EntityLayer;
using Tema3_MVP.Models.Models;
using System.Collections.ObjectModel;

namespace Tema3_MVP.Models.DataAccessLayer
{
    public class SpecializationDAL
    {
        public SpecializationDAL() { }
        public int? AddSpecialization(Specialization specialization)
        {
            int? teacherID = null;

            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddSpecialization", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", specialization.name);

                SqlParameter outputParameter = new SqlParameter("@newSpecializationID", SqlDbType.Int);
                outputParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outputParameter);

                con.Open();
                cmd.ExecuteNonQuery();

                if (outputParameter.Value != DBNull.Value)
                {
                    teacherID = Convert.ToInt32(outputParameter.Value);
                }

                con.Close();
            }

            return teacherID;
        }

        public ObservableCollection<Specialization> GetAllSpecializations()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllSpecializations", con);
                ObservableCollection<Specialization> result = new ObservableCollection<Specialization>();

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Specialization()
                        {
                            SpecializationID = (int)reader["specialization_id"],
                            Name = (string)reader["name"].ToString().Trim()
                            
                        }
                        );
                }
                reader.Close();
                return result;

            }
        }

        public void DeleteSpecialization(Specialization specialization)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteSpecialization", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@specialization_id", specialization.SpecializationID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateSpecialization(Specialization specialization)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateSpecialization", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@specialization_id", specialization.SpecializationID);
                cmd.Parameters.AddWithValue("@name", specialization.Name);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}
