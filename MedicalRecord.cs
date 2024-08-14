using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Healthcare_System
{
    public class MedicalRecord
    {
        public int ID { get; set; }
        public int patientID { get; set; }

        public int doctorID { get; set; }
        public string diagnosis { get; set; }
        public string treatment { get; set; }

        public MedicalRecord(int ID, int patientID, int doctorID, string diagnosis, string treatment)
        {
            this.ID = ID;
            this.patientID = patientID;
            this.doctorID = doctorID;
            this.diagnosis = diagnosis;
            this.treatment = treatment;
        }
    }
}