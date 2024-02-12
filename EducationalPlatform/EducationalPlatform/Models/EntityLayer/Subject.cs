using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3_MVP.Models.EntityLayer
{
    public class Subject: BasePropertyChanged
    {
        public int subjectID;
        public string name;
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

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    NotifyPropertyChanged(nameof(Name));
                }
            }
        }

        public Subject()
        {

        }
        public Subject(string name)
        {
            this.name = name;
        }

        public Subject(int subjectID, string name)
        {
            this.subjectID = subjectID;
            this.name = name;
        }
    }
}
