using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Healthcare_System
{
    public class Doctor : Person
    {
        public string specialty { get; set; }
        public Doctor(int ID, string firstName, string lastName, string specialty) : base(ID, firstName, lastName)
        {
            this.specialty = specialty;
        }
    }
}