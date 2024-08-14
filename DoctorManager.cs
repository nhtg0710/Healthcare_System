using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Healthcare_System
{
    public class DoctorManager
    {
        private List<Doctor> doctors = new List<Doctor>();
        
        public Doctor getDoctor(int ID)
        {
            return doctors.Find(d => d.ID == ID);
        }
    
        public void handleDoctorOperation(){
            Console.WriteLine("1. Add Doctor");
            Console.WriteLine("2. Update Doctor");
            Console.WriteLine("3. Delete Doctor");
            Console.WriteLine("4. View Doctor");
            Console.WriteLine("5. View Doctors");
            int action = Convert.ToInt32(Console.ReadLine());
            switch(action){
                case 1:
                    addDoctor();
                    break;
                case 2:
                    Console.WriteLine("Enter doctor ID: ");
                    int doctorID = Convert.ToInt32(Console.ReadLine());
                    updateDoctor(doctorID);
                    break;
                case 3:
                    Console.WriteLine("Enter doctor ID: ");
                    doctorID = Convert.ToInt32(Console.ReadLine());
                    deleteDoctor(doctorID);
                    break;
                case 4:
                    Console.WriteLine("Enter doctor ID: ");
                    doctorID = Convert.ToInt32(Console.ReadLine());
                    viewDoctor(doctorID);
                    break;
                case 5:
                    viewDoctors();
                    break;
                default:
                    Console.WriteLine("Invalid action.");
                    break;
            }
        }

        public void addDoctor(Doctor doctor){
            doctors.Add(doctor);
        }
        public void addDoctor(){
            Console.WriteLine("Enter Doctor ID: ");
            int ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Doctor First Name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Doctor Last Name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Doctor Specialty: ");
            string specialty = Console.ReadLine();
            doctors.Add(new Doctor(ID, firstName, lastName, specialty));
        }

        public void updateDoctor(int doctorID){
            Doctor doctor = getDoctor(doctorID);
            if(doctor == null){
                Console.WriteLine("Doctor does not exist.");
                return;
            }

            Console.WriteLine("Enter the new first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the new last name: ");
            string lastName = Console.ReadLine();
            doctor.firstName = firstName;
            doctor.lastName = lastName;
        }

        public void deleteDoctor(int doctorID){
            Doctor doctor = getDoctor(doctorID);
            if(doctor == null){
                Console.WriteLine("Doctor does not exist.");
                return;
            }
            doctors.Remove(doctor);
        }

        public void viewDoctor(int doctorID){
            Doctor doctor = getDoctor(doctorID);
            if(doctor == null){
                Console.WriteLine("Doctor does not exist.");
                return;
            }
            Console.WriteLine("Doctor ID: " + doctor.ID);
            Console.WriteLine("First Name: " + doctor.firstName);
            Console.WriteLine("Last Name: " + doctor.lastName);
        }

        public void viewDoctors(){
            foreach(Doctor doctor in doctors){
                Console.WriteLine("Doctor ID: " + doctor.ID);
                Console.WriteLine("First Name: " + doctor.firstName);
                Console.WriteLine("Last Name: " + doctor.lastName);
            }
        }
    }
}