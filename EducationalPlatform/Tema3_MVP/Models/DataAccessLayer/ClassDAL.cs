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
    public class ClassDAL
    {
        public void AddClass(Class item)
        {
            using (SqlConnection con =DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddClass", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@teacher_id", item.teacherID);
                cmd.Parameters.AddWithValue("@study_year", item.studyYear);
                cmd.Parameters.AddWithValue("specialization_id", item.specializationID);
                cmd.Parameters.AddWithValue("section", item.section);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public ObservableCollection<Class> GetAllClasses()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllClasses", con);
                ObservableCollection<Class> result = new ObservableCollection<Class>();

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Class()
                        {
                            ClassID = (int)reader["class_id"],
                            TeacherID = (int)reader["teacher_id"],
                            studyYear = (int)reader["study_year"],
                            SpecializationID = (int)reader["specialization_id"],
                            Section = reader["section"].ToString()[0]
                        }
                        );
                }
                reader.Close();
                return result;

            }
        }

        public Class GetStudentClass(Student student)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetStudentClass", con);
                ObservableCollection<Class> result = new ObservableCollection<Class>();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@studentId", student.StudentID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Class()
                        {
                            ClassID = (int)reader["class_id"],
                            TeacherID = (int)reader["teacher_id"],
                            studyYear = (int)reader["study_year"],
                            SpecializationID = (int)reader["specialization_id"],
                            Section = reader["section"].ToString()[0]
                        }
                        );
                }
                reader.Close();
                return result[0];

            }
        }

        public void DeleteClass(Class item)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteClass", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@class_id", item.ClassID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateClass(Class item)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateClass", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@class_id", item.ClassID);
                cmd.Parameters.AddWithValue("@teacher_id", item.TeacherID);
                cmd.Parameters.AddWithValue("@study_year", item.StudyYear);
                cmd.Parameters.AddWithValue("@specialization_id", item.SpecializationID);
                cmd.Parameters.AddWithValue("@section", item.Section);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
