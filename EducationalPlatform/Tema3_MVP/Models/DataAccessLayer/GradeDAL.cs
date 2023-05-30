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
    public class GradeDAL
    {
        public void AddGrade(Grade grade)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddGrade", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@student_id", grade.StudentID);
                cmd.Parameters.AddWithValue("@semester", grade.Semester);
                cmd.Parameters.AddWithValue("@subject_id", grade.SubjectID);
                cmd.Parameters.AddWithValue("@value", grade.grade);   
                cmd.Parameters.AddWithValue("@date", grade.Date);
                cmd.Parameters.AddWithValue("@is_thesis", grade.isThesis);
                cmd.Parameters.AddWithValue("@is_canceled", grade.isCanceled);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void CancelGrade(Grade grade)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("CancelGrade", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@gradeId", grade.gradeID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public ObservableCollection<Grade> GetGradesByStudentSubject(Student student, Subject subject)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetStudentGrades", con);
                ObservableCollection<Grade> result = new ObservableCollection<Grade>();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@studentId", student.studentID);
                cmd.Parameters.AddWithValue("@subjectId", subject.subjectID);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Grade()
                        {
                            GradeID = (int)reader["grade_id"],
                            StudentID = (int)reader["student_id"],
                            Semester = (int)reader["semester"],
                            SubjectID = (int)reader["subject_id"],
                            grade = (float)(double)reader["value"],
                            Date = (DateTime)reader["date"],
                            isThesis = (bool)reader["is_thesis"],
                            isCanceled = (bool)reader["is_canceled"]
                        }
                        );
                }
                reader.Close();
                return result;

            }
        }
    }
}
