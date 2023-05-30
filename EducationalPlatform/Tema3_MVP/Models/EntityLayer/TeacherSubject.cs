using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3_MVP.Models.EntityLayer
{
    public class TeacherSubject: BasePropertyChanged
    {
        public int teacherID;
        public int subjectID;

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
                    NotifyPropertyChanged(nameof(subjectID));
                }
            }
        }

        public TeacherSubject()
        {

        }

        public TeacherSubject(int teacherID, int subjectID)
        {
            this.teacherID = teacherID;
            this.subjectID = subjectID;
            
        }
    }
}
