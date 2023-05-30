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
    public class StudentDAL
    {
        public int? AddStudent(Student student)
        {
            int? teacherID = null;

            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@firstname", student.firstname);
                cmd.Parameters.AddWithValue("@lastname", student.lastname);
                cmd.Parameters.AddWithValue("@user_id", student.userID);

                SqlParameter outputParameter = new SqlParameter("@newStudentID", SqlDbType.Int);
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

        public ObservableCollection<Student> GetAllStudents()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllStudents", con);
                ObservableCollection<Student> result = new ObservableCollection<Student>();

                cmd.CommandType = CommandType.StoredProcedure;

                
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Student()
                        {
                            StudentID = (int)reader["student_id"],
                            FirstName = reader["firstname"].ToString(),
                            LastName = reader["lastname"].ToString(),
                            UserID = (int)reader["user_id"]
                        }
                        );
                }
                reader.Close();
                return result;
            }
        }

        public ObservableCollection<Student> GetStudentsFromClass(Class c)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetStudentsByClass", con);
                ObservableCollection<Student> result = new ObservableCollection<Student>();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@classId", c.classID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Student()
                        {
                            StudentID = (int)reader["student_id"],
                            FirstName = reader["firstname"].ToString(),
                            LastName = reader["lastname"].ToString(),
                            UserID = (int)reader["user_id"]
                        }
                        );
                }
                reader.Close();
                return result;
            }
        }

        public void UpdateStudent(Student student)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@student_id", student.StudentID);
                cmd.Parameters.AddWithValue("@firstname", student.FirstName);
                cmd.Parameters.AddWithValue("@lastname", student.LastName);
                cmd.Parameters.AddWithValue("@user_id", student.UserID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteStudent(Student student)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@student_id", student.StudentID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Student GetStudentByUser(User user)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetStudentByUserId", con);
                Student result = new Student();

                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@userId", user.userID);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    result = new Student()
                    {
                        StudentID = (int)reader["student_id"],
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
