using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Healthcare_System
{
    public class NurseManager
    {
        private List<Nurse> nurses = new List<Nurse>();

        public Nurse? getNurse(int nurseID){
            return nurses.Find(n => n.ID == nurseID);
        }

        public void handleNurseOperation(){
            Console.WriteLine("1. Add Nurse");
            Console.WriteLine("2. Update Nurse");
            Console.WriteLine("3. Delete Nurse");
            Console.WriteLine("4. View Nurse");
            Console.WriteLine("5. View Nurses");
            int action = Convert.ToInt32(Console.ReadLine());
            switch(action){
                case 1:
                    addNurse();
                    break;
                case 2:
                    Console.WriteLine("Enter nurse ID: ");
                    int nurseID = Convert.ToInt32(Console.ReadLine());
                    updateNurse(nurseID);
                    break;
                case 3:
                    Console.WriteLine("Enter nurse ID: ");
                    nurseID = Convert.ToInt32(Console.ReadLine());
                    deleteNurse(nurseID);
                    break;
                case 4:
                    Console.WriteLine("Enter nurse ID: ");
                    nurseID = Convert.ToInt32(Console.ReadLine());
                    viewNurse(nurseID);
                    break;
                case 5:
                    viewNurses();
                    break;
                default:
                    Console.WriteLine("Invalid action.");
                    break;
            }
        }

        public void addNurse(Nurse nurse){
            nurses.Add(nurse);
        }
        public void addNurse(){
            Console.WriteLine("Enter first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter last name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter department:");
            string department = Console.ReadLine();
            int ID = nurses.Count + 1;
            nurses.Add(new Nurse(ID, firstName, lastName, department));
        }

        public void updateNurse(int nurseID){
            Nurse nurse = nurses.Find(n => n.ID == nurseID);
            if(nurse == null){
                Console.WriteLine("Nurse does not exist.");
                return;
            }

            Console.WriteLine("Enter the new first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the new last name: ");
            string lastName = Console.ReadLine();
            nurse.firstName = firstName;
            nurse.lastName = lastName;
        }

        public void deleteNurse(int nurseID){
            Nurse nurse = nurses.Find(n => n.ID == nurseID);
            if (nurse == null){
                Console.WriteLine("Nurse does not exist.");
                return;
            }
            nurses.Remove(nurse);
        }

        public void viewNurse(int nurseID){
            Nurse nurse = nurses.Find(n => n.ID == nurseID);
            if(nurse == null){
                Console.WriteLine("Nurse does not exist.");
                return;
            }
            Console.WriteLine("Nurse ID: " + nurse.ID);
            Console.WriteLine("First Name: " + nurse.firstName);
            Console.WriteLine("Last Name: " + nurse.lastName);
            Console.WriteLine("Department: " + nurse.department);
        }

        public void viewNurses(){
            foreach(Nurse nurse in nurses){
                Console.WriteLine("Nurse ID: " + nurse.ID);
                Console.WriteLine("First Name: " + nurse.firstName);
                Console.WriteLine("Last Name: " + nurse.lastName);
                Console.WriteLine("Department: " + nurse.department);
            }
        }
    }
}