using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3_MVP.Models.EntityLayer
{
    public class Grade: BasePropertyChanged
    {
        public int? gradeID;
        public int studentID;
        public int semester;
        public int subjectID;
        public DateTime date;
        public float grade;
        public bool isThesis; 
        public bool isCanceled;

        public int? GradeID
        {
            get { return gradeID; }
            set
            {
                if (gradeID != value)
                {
                    gradeID = value;
                    NotifyPropertyChanged(nameof(GradeID));
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

        public float Grade1
        {
            get { return grade; }
            set
            {
                if (grade != value)
                {
                    grade = value;
                    NotifyPropertyChanged(nameof(grade));
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

        public bool IsThesis
        {
            get { return isThesis; }
            set
            {
                if (isThesis != value)
                {
                    isThesis = value;
                    NotifyPropertyChanged(nameof(isThesis));
                }
            }
        }
        public bool IsCanceled
        {
            get { return isCanceled; }
            set
            {
                if (isCanceled != value)
                {
                    isCanceled = value;
                    NotifyPropertyChanged(nameof(isCanceled));
                }
            }
        }

        public Grade()
        {

        }

        public Grade(int studentID, int semester, int subjectID, DateTime date, float grade, bool isThesis, bool isCanceled)
        {
            this.studentID = studentID;
            this.semester = semester;   
            this.subjectID = subjectID;
            this.date = date;
            this.grade = grade;
            this.isThesis = isThesis;
            this.isCanceled = isCanceled;
        }
    }
}
