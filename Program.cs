using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

//design document
//enter role: doctor, nurse, admin
//if doctor
   //have a go back to previous control option
   //loop until valid input
   //after finish 1 operation, go back to the list of operations on the same level
       //eg. finish adding a patient, go back to the list of patient operations

//if nurse
 


//if admin
  

namespace Healthcare_System
{
    public class Program
    {
        static void Main(string[] args){
            // Patient patient = new Patient(1, "John", "Doe", []);
            // Doctor doctor = new Doctor(1, "John", "Doe", "Cardiology");
            // Nurse nurse = new Nurse(2, "Jane", "Doe", "Cardiology");
            // MedicalRecord record = new MedicalRecord(1, 1, 1, "Heart Attack", "Surgery");
            // Console.WriteLine("Doctor: " + doctor.firstName + " " + doctor.lastName + " " + doctor.specialty);
            // Console.WriteLine("Nurse: " + nurse.firstName + " " + nurse.lastName + " " + nurse.department);
            // Console.WriteLine("Medical Record: " + record.patientID + " " + record.doctorID + " " + record.diagnosis + " " + record.treatment);
            DoctorManager dm = new DoctorManager();
            dm.addDoctor(new Doctor(1, "John", "Doe", "Cardiology"));
            PatientManager pm = new PatientManager();
            pm.addPatient(new Patient(1, "Jane", "Dove", [new MedicalRecord(1, 1, 1, "Heart Attack", "Surgery")]));
            NurseManager nm = new NurseManager();
            nm.addNurse(new Nurse(1, "Jess", "Nose", "Cardiology"));
            AppointmentManager am = new AppointmentManager();   
            MedicalRecordManager mrm = new MedicalRecordManager();

            // logging in for each role
            Console.WriteLine("Welcome to the Healthcare System! Please enter your role:");
            Console.WriteLine("1. Doctor");
            Console.WriteLine("2. Nurse");
            Console.WriteLine("3. Admin");
            role:
            int role = Convert.ToInt32(Console.ReadLine());
            switch (role){
                case 1:
                    Console.WriteLine("Welcome Doctor! Please enter your ID:");
                    int doctorID = 0;
                    Doctor? doctor = null;
                    while (doctorID == 0){
                        try{
                            doctorID = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException){
                            Console.WriteLine("Invalid ID. Please enter a valid ID:");
                        }
                        // doctorID = Convert.ToInt32(Console.ReadLine());
                        doctor = dm.getDoctor(doctorID);
                        if(doctor == null){
                            doctorID = 0;
                            Console.WriteLine("Doctor does not exist. Please enter a valid ID:");
                        }
                    }
                    Console.WriteLine("Welcome " + doctor.firstName + " " + doctor.lastName + "! What would you like to do?");
                    Console.WriteLine("1. Patient Management");
                    Console.WriteLine("2. Nurse Management");
                    Console.WriteLine("3. Appointment Management");
                    Console.WriteLine("4. Medical Record Management");
                    doctorAction:
                    int doctorAction = Convert.ToInt32(Console.ReadLine());
                    switch (doctorAction){
                        case 1:
                            pm.handlePatientOperation();
                            break;
                        case 2:
                            nm.handleNurseOperation();
                            break;
                        case 3:
                            am.handleAppointmentOperation(pm, dm);
                            break;
                        case 4:
                            mrm.handleMedicalRecordOperation();
                            break;
                        default:
                            Console.WriteLine("Invalid action. Enter the correct action:");
                            Console.WriteLine("1. Patient Management");
                            Console.WriteLine("2. Nurse Management");
                            Console.WriteLine("3. Appointment Management");
                            Console.WriteLine("4. Medical Record Management");
                            goto doctorAction;
                    }
                    break;
                case 2:
                    Console.WriteLine("Welcome Nurse! Please enter your ID:");
                    int nurseID = 0;
                    Nurse? nurse = null;
                    while (nurseID == 0){
                        try{
                            nurseID = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException){
                            Console.WriteLine("Invalid ID. Please enter a valid ID:");
                        }
                        nurse = nm.getNurse(nurseID);
                        if(nurse == null){
                            nurseID = 0;
                            Console.WriteLine("Nurse does not exist. Please enter a valid ID:");
                        }
                    }
                    Console.WriteLine("Welcome " + nurse.firstName + " " + nurse.lastName + "! What would you like to do?");
                    Console.WriteLine("1. Patient Management");
                    Console.WriteLine("2. Appointment Management");
                    Console.WriteLine("3. Medical Record Management");
                    nurseAction:
                    int nurseAction = Convert.ToInt32(Console.ReadLine());
                    switch (nurseAction){
                        case 1:
                            pm.handlePatientOperation();
                            break;
                        case 2:
                            am.handleAppointmentOperation(pm, dm);
                            break;
                        case 3:
                            mrm.handleMedicalRecordOperation();
                            break;
                        default:
                            Console.WriteLine("Invalid action. Enter the correct action:");
                            Console.WriteLine("1. Patient Management");
                            Console.WriteLine("2. Appointment Management");
                            Console.WriteLine("3. Medical Record Management");
                            goto nurseAction;
                    }
                    break;
                case 3:
                    Console.WriteLine("Welcome Admin! Please enter the password:");
                    string password = "";
                    while (password != "password"){
                        password = Console.ReadLine();
                        if(password != "password"){
                            password = "";
                            Console.WriteLine("Incorrect password. Please try again:");
                        }
                    }
                    Console.WriteLine("Welcome Admin! What would you like to do?");
                    Console.WriteLine("1. Patient Management");
                    Console.WriteLine("2. Doctor Management");
                    Console.WriteLine("3. Nurse Management");
                    Console.WriteLine("4. Appointment Management");
                    Console.WriteLine("5. Medical Record Management");
                    adminAction:
                    int adminAction = Convert.ToInt32(Console.ReadLine());
                    switch(adminAction){
                        case 1:
                            pm.handlePatientOperation();
                            break;
                        case 2:
                            dm.handleDoctorOperation();
                            break;
                        case 3:
                            nm.handleNurseOperation();
                            break;
                        case 4:
                            am.handleAppointmentOperation(pm, dm);
                            break;
                        case 5:
                            mrm.handleMedicalRecordOperation();
                            break;
                        default:
                            Console.WriteLine("Invalid action. Enter the correct action:");
                            Console.WriteLine("1. Patient Management");
                            Console.WriteLine("2. Doctor Management");
                            Console.WriteLine("3. Nurse Management");
                            Console.WriteLine("4. Appointment Management");
                            Console.WriteLine("5. Medical Record Management");
                            goto adminAction;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid role. Choose your correct role:");
                    Console.WriteLine("1. Doctor");
                    Console.WriteLine("2. Nurse");
                    Console.WriteLine("3. Admin");
                    goto role;
            }

        }
    }
}