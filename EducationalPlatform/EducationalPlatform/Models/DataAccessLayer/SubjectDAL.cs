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
using System.Xml.Linq;

namespace Tema3_MVP.Models.DataAccessLayer
{
    public class SubjectDAL
    {
        public void AddSubject(Subject subject)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@subject_name", subject.Name);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public ObservableCollection<Subject> GetAllSubjects()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllSubjects", con);
                ObservableCollection<Subject> result = new ObservableCollection<Subject>();

                cmd.CommandType = CommandType.StoredProcedure;
                
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Subject()
                        {
                            subjectID = (int)reader["subject_id"],
                            name = reader["name"].ToString().Trim()
                        }
                        );
                }
                reader.Close();
                return result;

            }
        }

        public ObservableCollection<Subject> GetStudentSubjects(Student student)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetStudentSubjects", con);
                ObservableCollection<Subject> result = new ObservableCollection<Subject>();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@studentId", student.studentID);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Subject()
                        {
                            subjectID = (int)reader["subject_id"],
                            name = reader["subject_name"].ToString().Trim()
                        }
                        );
                }
                reader.Close();
                return result;
            }
        }

        public void UpdateSubject(Subject subject)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@subject_id", subject.SubjectID);
                cmd.Parameters.AddWithValue("@name", subject.Name);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteSubject(Subject subject)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@subject_id", subject.SubjectID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
