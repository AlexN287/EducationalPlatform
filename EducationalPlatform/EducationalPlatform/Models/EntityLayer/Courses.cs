using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Tema3_MVP.Models.EntityLayer
{
    public class Courses: BasePropertyChanged
    {
        public int classID;
        public int teacherID;
        public int subjectID;
        public int? materialID;

        public int ClassID
        {
            get { return classID; }
            set
            {
                if (classID != value)
                {
                    classID = value;
                    NotifyPropertyChanged(nameof(ClassID));
                }

            }
        }

        public int TeacherID
        {
            get { return teacherID; }
            set
            {
                if (teacherID != value)
                {
                    teacherID = value;
                    NotifyPropertyChanged(nameof(TeacherID));
                }
            }
        }

        public int SubjectID
        {
            get { return subjectID; }
            set
            {
                if (subjectID != value)
                {
                    subjectID = value;
                    NotifyPropertyChanged(nameof(SubjectID));
                }
            }
        }

        public int? MaterialID
        {
            get { return materialID; }
            set
            {
                if (materialID != value)
                {
                    materialID = value;
                    NotifyPropertyChanged(nameof(MaterialID));
                }
            }
        }

        public Courses() { }
        public Courses(int classID, int teacherID, int subjectID, int? material_id)
        {
            this.classID = classID;
            this.teacherID = teacherID;
            this.subjectID = subjectID;
            this.materialID = material_id;
        }

        public Courses(int classID, int subjectID,int teacherID)
        {
            this.classID = classID;
            this.teacherID = teacherID;
            this.subjectID = subjectID;
        }
    }
}
