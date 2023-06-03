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
using Tema3_MVP.ViewModels;

namespace Tema3_MVP.Models.DataAccessLayer
{
    public class TeacherDAL
    {
        public int? AddTeacher(Teacher teacher)
        {
            int? teacherID = null;

            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddTeacher", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@firstname", teacher.firstname);
                cmd.Parameters.AddWithValue("@lastname", teacher.lastname);
                cmd.Parameters.AddWithValue("@user_id", teacher.userID);

                SqlParameter outputParameter = new SqlParameter("@newTeacherID", SqlDbType.Int);
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

        public ObservableCollection<Teacher> GetAllTeachers()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllTeachers", con);
                ObservableCollection<Teacher> result = new ObservableCollection<Teacher>();

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Teacher()
                        {
                            TeacherID = (int)reader["teacher_id"],
                            FirstName = reader["firstname"].ToString().Trim(),
                            LastName = reader["lastname"].ToString().Trim(),
                            UserID = (int)reader["user_id"]
                        }
                        );
                }
                reader.Close();
                return result;

            }
        }

        public ObservableCollection<Subject> GetTeacherSubjects(Teacher teacher)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetTeacherSubjects", con);
                ObservableCollection<Subject> result = new ObservableCollection<Subject>();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@teacherId", teacher.teacherID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Subject()
                        {
                            SubjectID = (int)reader["subject_id"],
                            Name = reader["name"].ToString().Trim()
                        }
                        );
                }
                reader.Close();
                return result;

            }
        }

        public ObservableCollection<Subject> GetTeacherSubjectsByClass(Teacher teacher, Class c)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetTeacherSubjectsByClass", con);
                ObservableCollection<Subject> result = new ObservableCollection<Subject>();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@teacherId", teacher.teacherID);
                cmd.Parameters.AddWithValue("@classId", c.classID);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Subject()
                        {
                            SubjectID = (int)reader["subject_id"],
                            Name = reader["name"].ToString().Trim()
                        }
                        );
                }
                reader.Close();
                return result;

            }
        }

        public ObservableCollection<Class> GetTeacherClasses(Teacher teacher)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetTeacherClasses", con);
                ObservableCollection<Class> result = new ObservableCollection<Class>();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@teacherId", teacher.teacherID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Class()
                        {
                            ClassID = (int)reader["class_id"],
                            TeacherID = (int)reader["teacher_id"],
                            StudyYear = (int)reader["study_year"],
                            SpecializationID = (int)reader["specialization_id"],
                            Section = reader["section"].ToString().Trim()[0]
                        }
                        );
                }
                reader.Close();
                return result;

            }
        }

        public void DeleteTeacher(Teacher teacher)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteTeacher", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@teacher_id", teacher.TeacherID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateTeacher(Teacher teacher)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateTeacher", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@teacher_id", teacher.TeacherID);
                cmd.Parameters.AddWithValue("@firstname", teacher.FirstName);
                cmd.Parameters.AddWithValue("@lastname", teacher.LastName);
                cmd.Parameters.AddWithValue("@user_id", teacher.UserID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Teacher GetTeacherByUser(User user)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetTeacherByUserId", con);
                Teacher result = new Teacher();

                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@userId", user.userID);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    result = new Teacher()
                    {
                        TeacherID = (int)reader["teacher_id"],
                        FirstName = reader["firstname"].ToString().Trim(),
                        LastName = reader["lastname"].ToString().Trim(),
                        UserID = (int)reader["user_id"]
                    };
                        
                }
                reader.Close();
                return result;

            }
        }
    }
}
