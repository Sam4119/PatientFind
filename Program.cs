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
            criteria = criteria.ToLower();
            criteria = criteria.Trim();
            
            switch (criteria)
            {
                
                case "findbyname":
                    {
                        Console.WriteLine("Enter Name:");
                        string name = Console.ReadLine();
                        if(FindName(PatientList, name, out Patient p))
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
                            foreach(var c in p)
                                
                            Console.WriteLine(c.Name + " " + c.SurName);
                        }
                        else
                        {
                            Console.WriteLine("Patient not found");
                        }
                        break;
                }
                case "findlesstham":
                    {
                        Console.WriteLine("Enter age:");
                        int age = int.Parse(Console.ReadLine());

                        if (LessTham(PatientList,age, out List<Patient> p))

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
                default:
                    {
                        Console.WriteLine("Unknown command");
                        break;
                    }

            }

        }
        static bool FindCritical(List<Patient>patients, out List<Patient> Found)
        {
            Found = new();
            foreach (var p in patients)
            {
                if ("critical"==p.Status)
                {
                    Found.Add(p);
                    
                }

            }
            if (Found.Count > 0)
                return true;
            else
                return false;
            
        }
        static bool LessTham(List<Patient> patients, int age, out List<Patient> Found)
        {
            Found = new();
            foreach (var p in patients)
            {
                if (age>=p.age)
                {
                    Found.Add(p);

                }

            }
            if (Found.Count > 0)
                return true;
            else
                return false;

        }
        static bool FindName(List<Patient>patients,string name, out Patient Found)
        {
            foreach(var p in patients)
            {
                if(name==p.Name)
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
