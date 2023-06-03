using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3_MVP.Models.EntityLayer
{
    public class ClassStudents: BasePropertyChanged
    {
        public int classID;
        public int studentID;

        public int ClassID
        {
            get { return classID; }
            set
            {
                if (classID != value)
                {
                    classID = value;
                    NotifyPropertyChanged(nameof(classID));
                }
            }
        }
        public int StudentID
        {
            get { return studentID; }
            set
            {
                if (studentID != value)
                {
                    studentID = value;
                    NotifyPropertyChanged(nameof(studentID));
                }
            }
        }

        public ClassStudents() { }
        public ClassStudents(int classID, int studentID)
        { 
            this.classID = classID;
            this.studentID = studentID;
        }

    }
}
