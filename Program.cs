using System;
using System.Collections.Generic;

namespace PatientFind
{
    class Program
    {
        static void Main(string[] args)
        {
            Patient p1 = new(Name: "Alex", SurName: " MItchel", age: 21, Status: "critical");
            Patient p2 = new(Name: "Kate", SurName: " Pupsvel", age: 18, Status: "critical");
            Patient p3 = new(Name: "Georgy", SurName: " Robbinson", age: 42, Status: "normal");
            Patient p4 = new(Name: "Lg", SurName: " Company", age: 30, Status: "critical");
            Patient p5 = new(Name: "Mikky", SurName: "Mouse", age: 120, Status: "normal");
            List<Patient> PatientList = new() { p1,p2,p3,p4,p5};
            //PatientList.Add(p1);
            //PatientList.Add(p2);
            //PatientList.Add(p3);
            //PatientList.Add(p4);
            //PatientList.Add(p5);
            Console.WriteLine("Enter criteria of finding");
            string criteria = Console.ReadLine();
            Console.WriteLine("Commands for input: ");
            Console.WriteLine("To search by name: Findbyname");
            Console.WriteLine("To search by surname: Findbysurname");
            Console.WriteLine("To search by status: Findcritical");
            Console.WriteLine("To search by status: Findlessthan");
            Console.WriteLine("To exit the program enter: Close program");
            Console.Write("Enter criteria of finding:");
            criteria = criteria.ToLower();
            criteria = criteria.Trim();
            bool factor = true;
            while (factor == true)
            {
                switch (criteria)
                {
                    case "findbysurname":
                        {
                            Console.WriteLine("Enter Surname:");
                            string surname = Console.ReadLine();
                            surname = surname.ToLower();
                            surname = surname.Trim();
                            if (FindBySurName(PatientList, surname, out Patient p))
                            {
                                Console.WriteLine(p.Name + " " + p.SurName);
                            }
                            else
                            {
                                Console.WriteLine("Patient not found");
                            }
                            break;
                        }

                    case "findbyname":
                        {
                            Console.WriteLine("Enter Name:");
                            string name = Console.ReadLine();
                            name = name.ToLower();
                            name = name.Trim();
                            if (FindByName(PatientList, name, out Patient p))
                            {
                                Console.WriteLine(p.Name + " " + p.SurName);

                            }
                            else
                            {
                                Console.WriteLine("Patient not found");
                            }
                            break;
                        }
                    case "findcritical":

                        {
                            if (FindCritical(PatientList, out List<Patient> p))
                            {
                                foreach (var c in p)
                                Console.WriteLine(c.Name + " " + c.SurName);
                            }
                            else
                            {
                                Console.WriteLine("Patient not found");
                            }
                            break;
                        }
                    case "findlessthan":
                        {
                            Console.WriteLine("Enter age:");
                            int age = int.Parse(Console.ReadLine());

                            if (LessThan(PatientList, age, out List<Patient> p))
                            {
                                foreach (var a in p)
                                    Console.WriteLine(a.Name + " " + a.SurName);
                            }
                            else
                            {
                                Console.WriteLine("Patient not found");
                            }
                            break;
                        }
                    case "close program":
                        {
                            factor = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Unknown command. Try again");
                            break;
                        }


                }
                Console.WriteLine("Enter command");
                criteria = Console.ReadLine();

            }


        }
        static bool FindCritical(List<Patient> patients, out List<Patient> Found)
        {
            Found = new();
            foreach (var p in patients)
            {
                if ("critical" == p.Status)
                {
                    Found.Add(p);

                }

            }
            if (Found.Count > 0)
                return true;
            else
                return false;

        }
        static bool LessThan(List<Patient> patients, int age, out List<Patient> Found)
        {
            Found = new();
            foreach (var p in patients)
            {
                if (age >= p.age)
                {
                    Found.Add(p);

                }

            }
            if (Found.Count > 0)
                return true;
            else
                return false;

        }
        static bool FindBySurName(List<Patient> patients, string surname, out Patient Found)
        {
            foreach (var p in patients)
            {
                if (surname == p.SurName.ToLower())
                {
                    Found = p;
                    return true;
                }
            }
            Found = null;
            return false;
        }
        static bool FindByName(List<Patient> patients, string name, out Patient Found)
        {
            foreach (var p in patients)
            {
                if (name == p.Name.ToLower())
                {
                    Found = p;
                    return true;
                }

            }
            Found = null;
            return false;
        }
    }
}
