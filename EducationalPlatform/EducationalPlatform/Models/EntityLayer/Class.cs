using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Tema3_MVP.Models.EntityLayer
{
    public class Class: BasePropertyChanged
    {
        public int classID;
        public int teacherID;
        public int studyYear;
        public int specializationID;
        public char section;

        public Class(int teacherID, int studyYear, int specializationID, char section)
        {
            this.teacherID = teacherID;
            this.studyYear = studyYear; 
            this.specializationID = specializationID;   
            this.section = section; 
        }
        public Class(int class_id, int teacherID, int studyYear, int specializationID, char section)
        {
            this.classID = class_id;
            this.teacherID = teacherID;
            this.studyYear = studyYear;
            this.specializationID = specializationID;
            this.section = section;
        }
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

        public int TeacherID
        {
            get { return teacherID; }
            set
            {
                if (teacherID != value)
                {
                    teacherID = value;
                    NotifyPropertyChanged(nameof(teacherID));
                }
            }
        }

        public int SpecializationID
        {
            get { return specializationID; }
            set
            {
                if (specializationID != value)
                {
                    specializationID = value;
                    NotifyPropertyChanged(nameof(classID));
                }
            }
        }
        public char Section
        {
            get { return section; }
            set
            {
                if (section != value)
                {
                    section = value;
                    NotifyPropertyChanged(nameof(section));
                }
            }
        }

        public int StudyYear
        {
            get { return studyYear; }
            set
            {
                if (studyYear != value)
                {
                    studyYear = value;
                    NotifyPropertyChanged(nameof(studyYear));
                }
            }
        }
        public Class()
        {

        }
    }
}
