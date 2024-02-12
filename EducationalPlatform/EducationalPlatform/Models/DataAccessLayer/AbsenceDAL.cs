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
    public class AbsenceDAL
    {
        public void AddAbsence(Absence absence)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddAbsence", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@student_id", absence.StudentID);
                cmd.Parameters.AddWithValue("@semester", absence.Semester);
                cmd.Parameters.AddWithValue("@subject_id", absence.SubjectID);
                cmd.Parameters.AddWithValue("@date", absence.Date);
                cmd.Parameters.AddWithValue("@is_motivated", absence.IsMotivated);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void MotivateAbsence(Absence absence)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("MotivateAbsence", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@absence_id", absence.absenceID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public ObservableCollection<Absence> GetAbsencesByStudent(Student student)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAbsencesByStudent", con);
                ObservableCollection<Absence> result = new ObservableCollection<Absence>();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@studentId", student.studentID);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Absence()
                        {
                            AbsenceID = (int)reader["absence_id"],
                            StudentID = (int)reader["student_id"],
                            Semester = (int)reader["semester"],
                            SubjectID = (int)reader["subject_id"],
                            Date = (DateTime)reader["date"],
                            isMotivated = (bool)reader["is_motivated"]
                        }
                        );
                }
                reader.Close();
                return result;

            }
        }

        public ObservableCollection<Absence> GetStudentSubjectAbsences(Student student, Subject subject)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetStudentSubjectAbsences", con);
                ObservableCollection<Absence> result = new ObservableCollection<Absence>();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@studentId", student.studentID);
                cmd.Parameters.AddWithValue("@subjectId", subject.subjectID);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Absence()
                        {
                            AbsenceID = (int)reader["absence_id"],
                            StudentID = (int)reader["student_id"],
                            Semester = (int)reader["semester"],
                            SubjectID = (int)reader["subject_id"],
                            Date = (DateTime)reader["date"],
                            isMotivated = (bool)reader["is_motivated"]
                        }
                        );
                }
                reader.Close();
                return result;

            }
        }
    }
}
