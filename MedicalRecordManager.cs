using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Healthcare_System
{
    public class MedicalRecordManager
    {
        private List<MedicalRecord> medicalRecords = new List<MedicalRecord>();

        public MedicalRecord? getMedicalRecord(int recordID){
            return medicalRecords.Find(r => r.ID == recordID);
        }

        public void handleMedicalRecordOperation(){
            Console.WriteLine("1. Add Medical Record");
            Console.WriteLine("2. Update Medical Record");
            Console.WriteLine("3. Delete Medical Record");
            Console.WriteLine("4. View Medical Record");
            Console.WriteLine("5. View Medical Records");
            int action = Convert.ToInt32(Console.ReadLine());
            switch(action){
                case 1:
                    addMedicalRecord();
                    break;
                case 2:
                    Console.WriteLine("Enter record ID: ");
                    int recordID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter diagnosis: ");
                    string diagnosis = Console.ReadLine();
                    Console.WriteLine("Enter treatment: ");
                    string treatment = Console.ReadLine();
                    updateMedicalRecord(recordID, diagnosis, treatment);
                    break;
                case 3:
                    Console.WriteLine("Enter record ID: ");
                    recordID = Convert.ToInt32(Console.ReadLine());
                    deleteMedicalRecord(recordID);
                    break;
                case 4:
                    Console.WriteLine("Enter patient ID: ");
                    int patientID = Convert.ToInt32(Console.ReadLine());
                    viewMedicalRecord(patientID);
                    break;
                case 5:
                    viewMedicalRecords();
                    break;
                default:
                    Console.WriteLine("Invalid action.");
                    break;
            }
        }

        public void addMedicalRecord(MedicalRecord record){
            medicalRecords.Add(record);
        }   
        public void addMedicalRecord(){
            Console.WriteLine("Enter the patient ID:");
            int patientID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the doctor ID:");
            int doctorID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the diagnosis:");
            string diagnosis = Console.ReadLine();
            Console.WriteLine("Enter the treatment:");
            string treatment = Console.ReadLine();
            medicalRecords.Add(new MedicalRecord(medicalRecords.Count + 1, patientID, doctorID, diagnosis, treatment));

        }

        public void updateMedicalRecord(int recordID, string diagnosis, string treatment){
            MedicalRecord record = medicalRecords.Find(r => r.ID == recordID);
            if(record == null){
                Console.WriteLine("Medical record does not exist.");
                return;
            }
            record.diagnosis = diagnosis;
            record.treatment = treatment;
        }

        public void deleteMedicalRecord(int recordID){
            MedicalRecord record = medicalRecords.Find(r => r.ID == recordID);
            if(record == null){
                Console.WriteLine("Medical record does not exist.");
                return;
            }
            medicalRecords.Remove(record);
        }

        public void viewMedicalRecord(int patientID){
            List<MedicalRecord> records = medicalRecords.FindAll(r => r.patientID == patientID);
            if(records.Count == 0){
                Console.WriteLine("No medical records found for patient.");
                return;
            }
            foreach(MedicalRecord record in records){
                Console.WriteLine("Record ID: " + record.ID);
                Console.WriteLine("Doctor ID: " + record.doctorID);
                Console.WriteLine("Diagnosis: " + record.diagnosis);
                Console.WriteLine("Treatment: " + record.treatment);
            }
        }

        public void viewMedicalRecords(){
            foreach(MedicalRecord record in medicalRecords){
                Console.WriteLine("Record ID: " + record.ID);
                Console.WriteLine("Patient ID: " + record.patientID);
                Console.WriteLine("Doctor ID: " + record.doctorID);
                Console.WriteLine("Diagnosis: " + record.diagnosis);
                Console.WriteLine("Treatment: " + record.treatment);
            }
        }

    }
}