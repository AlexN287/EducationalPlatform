using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3_MVP.Models.EntityLayer
{
    public class Admin: BasePropertyChanged
    {
        public int? adminID;
        public string firstname;
        public string lastname;
        public int userID;

        public int? AdminID
        {
            get { return adminID; }
            set
            {
                if (adminID != value)
                {
                    adminID = value;
                    NotifyPropertyChanged(nameof(AdminID));
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

        public string Lastname
        {
            get { return lastname; }
            set
            {
                if (lastname != value)
                {
                    lastname = value;
                    NotifyPropertyChanged(nameof(Lastname));
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

        public Admin()
        {

        }
    }
}
