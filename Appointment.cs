using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Healthcare_System
{
    public class Appointment
    {
        public int ID { get; set; }
        public int patientID { get; set; }
        public int doctorID { get; set; }
        public DateTime date { get; set; }
    }
}