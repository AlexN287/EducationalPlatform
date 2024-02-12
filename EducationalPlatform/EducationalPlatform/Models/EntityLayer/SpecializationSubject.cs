using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3_MVP.Models.EntityLayer
{
    public class SpecializationSubject: BasePropertyChanged
    {
        public int specializationID;
        public int subjectID;
        public bool hasThesis;

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

        public int SpecializationID
        {
            get { return specializationID; }
            set
            {
                if (specializationID != value)
                {
                    specializationID = value;
                    NotifyPropertyChanged(nameof(SpecializationID));
                }
            }
        }

        public bool HasThesis
        {
            get { return hasThesis; }
            set
            {
                if (hasThesis != value)
                {
                    hasThesis = value;
                    NotifyPropertyChanged(nameof(HasThesis));
                }
            }
        }

        public SpecializationSubject() { }
        public SpecializationSubject(int specializationID, int subjectID, bool hasThesis)
        {
            this.specializationID = specializationID;
            this.subjectID = subjectID;
            this.hasThesis = hasThesis;
        }   
    }
}
