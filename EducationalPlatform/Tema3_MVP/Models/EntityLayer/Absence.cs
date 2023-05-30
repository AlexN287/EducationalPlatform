using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3_MVP.Models.EntityLayer
{
    public class Absence: BasePropertyChanged
    {
        public int absenceID;
        public int studentID;
        public int semester;
        public int subjectID;
        public DateTime date;
        public bool isMotivated;

        public int AbsenceID
        {
            get { return absenceID; }
            set
            {
                if (absenceID != value)
                {
                    absenceID = value;
                    NotifyPropertyChanged(nameof(AbsenceID));
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
                    NotifyPropertyChanged(nameof(StudentID));
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
        public int Semester
        {
            get { return semester; }
            set
            {
                if (semester != value)
                {
                    semester = value;
                    NotifyPropertyChanged(nameof(Semester));
                }
            }
        }

        public DateTime Date
        {
            get { return date; }
            set
            {
                if (date != value)
                {
                    date = value;
                    NotifyPropertyChanged(nameof(Date));
                }
            }
        }

        public bool IsMotivated
        {
            get { return isMotivated; }
            set
            {
                if (isMotivated != value)
                {
                    isMotivated = value;
                    NotifyPropertyChanged(nameof(IsMotivated));
                }
            }
        }

        public Absence()
        {

        }

        public Absence(int studentID, int semester, int subjectID, DateTime date, bool isMotivated)
        {
            this.date = date;
            this.studentID = studentID;
            this.semester = semester;   
            this.subjectID = subjectID;
            this.isMotivated= isMotivated;
        }
    }
}
