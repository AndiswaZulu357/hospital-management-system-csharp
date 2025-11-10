using System;

namespace HospitalManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital(3, 4); // Creating a hospital with 3 wards, each with a capacity of 4 patients

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Hospital Management System Menu:");
                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. Display Patients");
                Console.WriteLine("3. Discharge Patient");
                Console.WriteLine("4. Display Ward Information");
                Console.WriteLine("5. Search Patient");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddPatientMenu(hospital);
                            break;
                        case 2:
                            hospital.DisplayPatients();
                            break;
                        case 3:
                            DischargePatientMenu(hospital);
                            break;
                        case 4:
                            hospital.DisplayWardInformation();
                            break;
                        case 5:
                            SearchPatientMenu(hospital);
                            break;
                        case 6:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number from 1 to 6.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                Console.WriteLine();
            }
        }

        static void AddPatientMenu(Hospital hospital)
        {
            Console.WriteLine("Enter patient details:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Condition: ");
            string condition = Console.ReadLine();
            hospital.AddPatient(name, age, condition);
        }

        static void DischargePatientMenu(Hospital hospital)
        {
            Console.Write("Enter the name of the patient to discharge: ");
            string name = Console.ReadLine();
            hospital.DischargePatient(name);
        }

        static void SearchPatientMenu(Hospital hospital)
        {
            Console.Write("Enter the name of the patient to search: ");
            string name = Console.ReadLine();
            hospital.SearchPatient(name);
        }
    }

    class Patient
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Condition { get; set; }

        public Patient(string name, int age, string condition)
        {
            Name = name;
            Age = age;
            Condition = condition;
        }

        public override string ToString()
        {
            return $"{Name}, {Age}, {Condition}";
        }
    }

    class Hospital
    {
        private Patient[,] wards;

        public Hospital(int numberOfWards, int wardCapacity)
        {
            wards = new Patient[numberOfWards, wardCapacity];
        }

        public void AddPatient(string name, int age, string condition)
        {
            for (int i = 0; i < wards.GetLength(0); i++)
            {
                for (int j = 0; j < wards.GetLength(1); j++)
                {
                    if (wards[i, j] == null)
                    {
                        wards[i, j] = new Patient(name, age, condition);
                        Console.WriteLine($"Patient {name} added to Ward {i + 1}, Bed {j + 1}.");
                        return;
                    }
                }
            }
            Console.WriteLine("All wards are full. Cannot add patient.");
        }

        public void DisplayPatients()
        {
            Console.WriteLine("Patients in the hospital:");
            for (int i = 0; i < wards.GetLength(0); i++)
            {
                Console.WriteLine($"Ward {i + 1}:");
                for (int j = 0; j < wards.GetLength(1); j++)
                {
                    if (wards[i, j] != null)
                    {
                        Console.WriteLine($"Bed {j + 1}: {wards[i, j]}");
                    }
                    else
                    {
                        Console.WriteLine($"Bed {j + 1}: Empty");
                    }
                }
            }
        }

        public void DischargePatient(string name)
        {
            for (int i = 0; i < wards.GetLength(0); i++)
            {
                for (int j = 0; j < wards.GetLength(1); j++)
                {
                    if (wards[i, j] != null && wards[i, j].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"Patient {name} discharged from Ward {i + 1}, Bed {j + 1}.");
                        wards[i, j] = null;
                        return;
                    }
                }
            }
            Console.WriteLine($"Patient {name} not found in any ward.");
        }

        public void DisplayWardInformation()
        {
            Console.WriteLine("Ward Information:");
            for (int i = 0; i < wards.GetLength(0); i++)
            {
                int occupiedBeds = 0;
                for (int j = 0; j < wards.GetLength(1); j++)
                {
                    if (wards[i, j] != null)
                    {
                        occupiedBeds++;
                    }
                }
                Console.WriteLine($"Ward {i + 1}: {occupiedBeds}/{wards.GetLength(1)} beds occupied.");
            }
        }

        public void SearchPatient(string name)
        {
            Console.WriteLine($"Searching for patient {name}...");
            bool found = false;
            for (int i = 0; i < wards.GetLength(0); i++)
            {
                for (int j = 0; j < wards.GetLength(1); j++)
                {
                    if (wards[i, j] != null && wards[i, j].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"Patient {name} found in Ward {i + 1}, Bed {j + 1}: {wards[i, j]}");
                        found = true;
                    }
                }
            }
            if (!found)
            {
                Console.WriteLine($"Patient {name} not found in any ward.");
            }
        }
    }
}
