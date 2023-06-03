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
    public class TeacherSubjectDAL
    {
        public void AddTeacherSubject(TeacherSubject teacherSubject)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddTeacherSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@teacher_id", teacherSubject.teacherID);
                cmd.Parameters.AddWithValue("@subject_id", teacherSubject.subjectID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
