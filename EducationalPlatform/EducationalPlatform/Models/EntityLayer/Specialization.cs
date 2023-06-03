using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3_MVP.Models.EntityLayer
{
    public class Specialization: BasePropertyChanged
    {
        public int specializationID;
        public string name;
        public int SpecializationID
        {
            get { return specializationID; }
            set
            {
                if (specializationID != value)
                {
                    specializationID = value;
                    NotifyPropertyChanged(nameof(specializationID));
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

        public Specialization()
        {

        }
        public Specialization(string name)
        {
            this.name = name;
        }

        public Specialization(int specializationID, string name)
        {
            this.specializationID = specializationID;
            this.name = name;
        }
    }
}
