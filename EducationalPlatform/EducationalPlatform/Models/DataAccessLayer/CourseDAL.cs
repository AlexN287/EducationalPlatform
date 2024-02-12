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
    public class CourseDAL
    {
        public void AddCourse(Courses courses)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddCourse", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@class_id", courses.classID);
                cmd.Parameters.AddWithValue("@subject_id", courses.subjectID);
                cmd.Parameters.AddWithValue("@teacher_id", courses.teacherID);
                cmd.Parameters.AddWithValue("@material_id", courses.materialID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void AddCourseWithoutMaterial(Courses courses)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddCourseWithoutMaterial", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@class_id", courses.classID);
                cmd.Parameters.AddWithValue("@subject_id", courses.subjectID);
                cmd.Parameters.AddWithValue("@teacher_id", courses.teacherID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void InsertTeacherMaterialAndSetCourse(Courses courses, TeacherMaterial teacherMaterial)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertTeacherMaterialAndSetCourse", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@classId", courses.classID);
                cmd.Parameters.AddWithValue("@subjectId", courses.subjectID);
                cmd.Parameters.AddWithValue("@teacherId", courses.teacherID);
                cmd.Parameters.AddWithValue("@name", teacherMaterial.Name);
                cmd.Parameters.AddWithValue("@filepath", teacherMaterial.FilePath);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public ObservableCollection<TeacherMaterial> GetTeacherMaterialForClassAndSubject(Class c, Subject subject)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetTeacherMaterialForClassAndSubject", con);
                ObservableCollection<TeacherMaterial> result = new ObservableCollection<TeacherMaterial>();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@classId", c.classID);
                cmd.Parameters.AddWithValue("@subjectId", subject.subjectID);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new TeacherMaterial()
                        {
                            MaterialID = (int)reader["material_id"],
                            Name = reader["name"].ToString().Trim(),
                            FilePath = reader["filepath"].ToString().Trim()
                        }
                        );
                }
                reader.Close();
                return result;

            }
        }

        public ObservableCollection<TeacherMaterial> GetMaterialForClassSubjectTeacher(Courses c)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetMaterialForClassSubjectTeacher", con);
                ObservableCollection<TeacherMaterial> result = new ObservableCollection<TeacherMaterial>();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@classId", c.classID);
                cmd.Parameters.AddWithValue("@subjectId", c.subjectID);
                cmd.Parameters.AddWithValue("@teacherId", c.teacherID);


                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new TeacherMaterial()
                        {
                            MaterialID = (int)reader["material_id"],
                            Name = reader["name"].ToString().Trim(),
                            FilePath = reader["filepath"].ToString().Trim()
                        }
                        );
                }
                reader.Close();
                return result;

            }
        }

        public void DeleteMaterial(TeacherMaterial item)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteMaterial", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@materialId", item.MaterialID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
