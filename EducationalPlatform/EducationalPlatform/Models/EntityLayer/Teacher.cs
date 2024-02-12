using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3_MVP.Models.EntityLayer
{
    public class Teacher: BasePropertyChanged
    {
        public int teacherID;
        public string firstname;
        public string lastname;
        public int userID;
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

        public string FirstName
        {
            get { return firstname; }
            set
            {
                if (firstname != value)
                {
                    firstname = value;
                    NotifyPropertyChanged(nameof(FirstName));
                }
            }
        }

        public string LastName
        {
            get { return lastname; }
            set
            {
                if (lastname != value)
                {
                    lastname = value;
                    NotifyPropertyChanged(nameof(LastName));
                }
            }
        }

        public int UserID
        {
            get { return userID; }
            set
            {
                if (userID != value)
                {
                    userID = value;
                    NotifyPropertyChanged(nameof(UserID));
                }
            }
        }

        public Teacher()
        {

        }

        public Teacher(string firstname, string lastname, int userID)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.userID = userID;
        }

        public Teacher(int teacherID, string firstname, string lastname, int userID)
        {
            this.teacherID = teacherID;
            this.firstname = firstname;
            this.lastname = lastname;
            this.userID = userID;
        }
    }
}
