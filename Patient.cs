using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientFind
{
    class Patient
    {
        public String Name;
        public String SurName;
        public int age;
        public String Status;
        public Patient(string Name, string SurName, string Status, int age)
        {
            this.Name = Name;
            this.SurName = SurName;
            this.age = age;
            this.Status = Status;
        }
    }
}
