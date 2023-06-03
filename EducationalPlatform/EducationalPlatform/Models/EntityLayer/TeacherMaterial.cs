using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3_MVP.Models.EntityLayer
{
    public class TeacherMaterial: BasePropertyChanged
    {
        private int materialID;
        private string name;
        private string filePath;

        public int MaterialID
        {
            get { return materialID; }
            set
            {
                if (materialID != value)
                {
                    materialID = value;
                    NotifyPropertyChanged(nameof(MaterialID));
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

        public string FilePath
        {
            get { return filePath; }
            set
            {
                if (filePath != value)
                {
                    filePath = value;
                    NotifyPropertyChanged(nameof(FilePath));
                }
            }
        }

        public TeacherMaterial() { }
        public TeacherMaterial(string name, string filePath)
        {
            this.name = name;
            this.filePath = filePath;
        }
    }
}
