using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Healthcare_System
{
    public class Patient : Person
    {
        public MedicalRecord[] medicalRecords { get; set; } = [];
        public Patient(int ID, string firstName, string lastName, MedicalRecord[] medicalRecords) : base(ID, firstName, lastName)
        {
        }
    }
}