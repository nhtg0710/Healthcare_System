using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Healthcare_System
{
    public class Nurse : Person
    {
        public string department {get;set;}
        public Nurse(int ID, string firstName, string lastName, string department) : base(ID, firstName, lastName)
        {
            this.department = department;
        }
    }
}