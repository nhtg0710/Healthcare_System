using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Healthcare_System
{
    public abstract class Person
    {
        public int ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public Person(int ID, string firstName, string lastName)
        {
            this.ID = ID;
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}