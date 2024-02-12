using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3_MVP.Models.EntityLayer
{
    public class Student: BasePropertyChanged
    {
        public int studentID;
        public string firstname;
        public string lastname;
        public int userID;

        public Student(string firstname, string lastname, int userID)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.userID = userID;
        }

        public Student(int studentID, string firstname, string lastname, int userID)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.userID = userID;
            this.studentID = studentID;
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

        public Student()
        {

        }
    }
}
