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
    public class ClassStudentDAL
    {
        public void AddClassStudent(ClassStudents classStudents)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddClassStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@class_id", classStudents.classID);
                cmd.Parameters.AddWithValue("@student_id", classStudents.studentID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateClassStudent(ClassStudents classStudent)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateClassStudents", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@class_id", classStudent.classID);
                cmd.Parameters.AddWithValue("@student_id", classStudent.StudentID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
