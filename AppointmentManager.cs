using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Healthcare_System
{
    public class AppointmentManager
    {
        private List<Appointment> appointments = new List<Appointment>();

        public Appointment getAppointment(int ID)
        {
            return appointments.Find(a => a.ID == ID);
        }

        public void handleAppointmentOperation(PatientManager pm, DoctorManager dm){
            Console.WriteLine("1. Add Appointment");
            Console.WriteLine("2. Update Appointment");
            Console.WriteLine("3. Delete Appointment");
            Console.WriteLine("4. View Appointment");
            Console.WriteLine("5. View Appointments");
            int action = Convert.ToInt32(Console.ReadLine());
            switch(action){
                case 1:
                    AddAppointment(pm, dm);
                    break;
                case 2:
                    updateAppointment(pm, dm);
                    break;
                case 3:
                    deleteAppointment();
                    break;
                case 4:
                    Console.WriteLine("Enter appointment ID: ");
                    int appointmentID = Convert.ToInt32(Console.ReadLine());
                    viewAppointment(appointmentID);
                    break;
                case 5:
                    viewAppointments();
                    break;
                default:
                    Console.WriteLine("Invalid action.");
                    break;
            }
        }

        public void AddAppointment(Appointment appointment){
            appointments.Add(appointment);
        }
        public void AddAppointment(PatientManager pm, DoctorManager dm){
            Console.WriteLine("Enter the patient's ID: ");
            int patientID = Convert.ToInt32(Console.ReadLine());
            //verify patient exists
            if(pm.getPatient(patientID) == null){
                Console.WriteLine("Patient does not exist.");
                return;
            }
            Console.WriteLine("Enter the doctor's ID: ");
            int doctorID = Convert.ToInt32(Console.ReadLine());
            //verify doctor exists
            if (dm.getDoctor(doctorID) == null){
                Console.WriteLine("Doctor does not exist.");
                return;
            }
            Console.WriteLine("Enter the date of the appointment: ");
            DateTime date = Convert.ToDateTime(Console.ReadLine());
            Appointment appointment = new Appointment();
            appointment.ID = appointments.Count + 1;
            appointment.patientID = patientID;
            appointment.doctorID = doctorID;
            appointment.date = date;
            appointments.Add(appointment);
            // pm.GetPatient(patientID).appointments.Add(appointment);
            // dm.GetDoctor(doctorID).appointments.Add(appointment);
        }

        public void updateAppointment(PatientManager pm, DoctorManager dm){
            Console.WriteLine("Enter the ID of the appointment you would like to update: ");
            int ID = Convert.ToInt32(Console.ReadLine());
            Appointment appointment = appointments.Find(a => a.ID == ID);
            if(appointment == null){
                Console.WriteLine("Appointment does not exist.");
                return;
            }

            Console.WriteLine("Enter the new patient ID: ");
            int patientID = Convert.ToInt32(Console.ReadLine());
            if (pm.getPatient(patientID) == null){
                Console.WriteLine("Patient does not exist.");
                return;
            }
            appointment.patientID = patientID;

            Console.WriteLine("Enter the new doctor ID: ");
            int doctorID = Convert.ToInt32(Console.ReadLine());
            if (dm.getDoctor(doctorID) == null){
                Console.WriteLine("Doctor does not exist.");
                return;
            }

            Console.WriteLine("Enter the new date of the appointment: ");
            DateTime date = Convert.ToDateTime(Console.ReadLine());
            appointment.date = date;
            //show details of updated appointment
            Console.WriteLine($"Appointment updated successfully. Patient ID is: {appointment.patientID}, Doctor ID is: {appointment.doctorID}, Date is: {appointment.date}");
        }
        public void deleteAppointment(){
            Console.WriteLine("Enter the ID of the appointment you would like to delete: ");
            int ID = Convert.ToInt32(Console.ReadLine());
            Appointment appointment = appointments.Find(a => a.ID == ID);
            if(appointment == null){
                Console.WriteLine("Appointment does not exist.");
                return;
            }
            appointments.Remove(appointment);
            Console.WriteLine("Appointment deleted successfully.");
        }

        public void viewAppointment(int appointmentID){
            Appointment appointment = appointments.Find(a => a.ID == appointmentID);
            if(appointment == null){
                Console.WriteLine("Appointment does not exist.");
                return;
            }
            Console.WriteLine($"Appointment ID: {appointment.ID}, Patient ID: {appointment.patientID}, Doctor ID: {appointment.doctorID}, Date: {appointment.date}");
        }

        public void viewAppointments(){
            foreach(Appointment appointment in appointments){
                Console.WriteLine($"Appointment ID: {appointment.ID}, Patient ID: {appointment.patientID}, Doctor ID: {appointment.doctorID}, Date: {appointment.date}");
            }
        }
    }
}