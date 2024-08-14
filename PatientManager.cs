using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Healthcare_System
{
    public class PatientManager
    {
        private List<Patient> patients = new List<Patient>();

        public Patient getPatient(int ID)
        {
            return patients.Find(p => p.ID == ID);
        }

        public void handlePatientOperation(){
            Console.WriteLine("1. Add Patient");
            Console.WriteLine("2. Update Patient");
            Console.WriteLine("3. Delete Patient");
            Console.WriteLine("4. View Patient");
            Console.WriteLine("5. View Patients");
            int action = Convert.ToInt32(Console.ReadLine());
            switch(action){
                case 1:
                    addPatient();
                    break;
                case 2:
                    Console.WriteLine("Enter patient ID: ");
                    int patientID = Convert.ToInt32(Console.ReadLine());
                    updatePatient(patientID);
                    break;
                case 3:
                    Console.WriteLine("Enter patient ID: ");
                    patientID = Convert.ToInt32(Console.ReadLine());
                    deletePatient(patientID);
                    break;
                case 4:
                    Console.WriteLine("Enter patient ID: ");
                    patientID = Convert.ToInt32(Console.ReadLine());
                    viewPatient(patientID);
                    break;
                case 5:
                    viewPatients();
                    break;
                default:
                    Console.WriteLine("Invalid action.");
                    break;
            }
        }

        public void addPatient(Patient patient){
            patients.Add(patient);
        }
        public void addPatient(){
            Console.WriteLine("Enter patient first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter patient last name: ");
            string lastName = Console.ReadLine();
            int ID = patients.Count + 1;
          

            patients.Add(new Patient(ID, firstName, lastName, []));
        }

        public void updatePatient(int patientID){
            Patient patient = getPatient(patientID);
            if(patient == null){
                Console.WriteLine("Patient does not exist.");
                return;
            }

            Console.WriteLine("Enter the new first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the new last name: ");
            string lastName = Console.ReadLine();
            patient.firstName = firstName;
            patient.lastName = lastName;
        }

        public void deletePatient(int patientID){
            Patient patient = getPatient(patientID);
            if(patient == null){
                Console.WriteLine("Patient does not exist.");
                return;
            }
            patients.Remove(patient);
        }

        public void viewPatient(int patientID){
            Patient patient = getPatient(patientID);
            if(patient == null){
                Console.WriteLine("Patient does not exist.");
                return;
            }
            Console.WriteLine("Patient ID: " + patient.ID);
            Console.WriteLine("First Name: " + patient.firstName);
            Console.WriteLine("Last Name: " + patient.lastName);
            Console.WriteLine("Medical Records: ");
            foreach(MedicalRecord record in patient.medicalRecords){
                Console.WriteLine("Diagnosis: " + record.diagnosis);
            }
        }

        public void viewPatients(){
            foreach(Patient patient in patients){
                Console.WriteLine("Patient ID: " + patient.ID);
                Console.WriteLine("First Name: " + patient.firstName);
                Console.WriteLine("Last Name: " + patient.lastName);
                Console.WriteLine("Medical Records: ");
                foreach(MedicalRecord record in patient.medicalRecords){
                    Console.WriteLine("Diagnosis: " + record.diagnosis);
                }
            }
        }
    }
}