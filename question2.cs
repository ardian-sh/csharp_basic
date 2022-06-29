using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Solution
{
    public class Solution
    {
        public static Dictionary<string, int> AverageAgeForEachCompany(List<Employee> employees)
        {
            Dictionary<string, int> averageAgeEmployees = new Dictionary<string, int>();

            foreach(Employee emp in employees.OrderBy(a => a.Company))
            {
                if(!averageAgeEmployees.ContainsKey(emp.Company))
                {
                    double averageAge = Math.Round(employees.Where(a => a.Company == emp.Company).Select(a => a.Age).ToList().Average());
                    averageAgeEmployees.Add(emp.Company, Convert.ToInt32(averageAge));
                }
            }

            return averageAgeEmployees;
        }

        public static Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
        {
            Dictionary<string, int> countOfEmployees = new Dictionary<string, int>();

            foreach (Employee emp in employees.OrderBy(a=> a.Company))
            {
                if (!countOfEmployees.ContainsKey(emp.Company))
                {
                    int countEmployee = employees.Where(a => a.Company == emp.Company).Count();

                    countOfEmployees.Add(emp.Company, countEmployee);
                }
            }

            return countOfEmployees;
        }

        public static Dictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
        {
            Dictionary<string, Employee> oldestAgeEmployees = new Dictionary<string, Employee>();

            foreach (Employee emp in employees.OrderBy(a => a.Company))
            {
                if (!oldestAgeEmployees.ContainsKey(emp.Company))
                {
                    int oldestAge = employees.Where(a => a.Company == emp.Company).OrderByDescending(a => a.Age).Select(a => a.Age).FirstOrDefault();

                    var ageEmployees = employees.Where(a => a.Company == emp.Company && a.Age == oldestAge).ToList();

                    foreach(var e in ageEmployees)
                    {
                        oldestAgeEmployees.Add(emp.Company, e);
                    }             
                }
            }

            return oldestAgeEmployees;
        }

        public static void Main()
        {
            int countOfEmployees = int.Parse(Console.ReadLine());

            var employees = new List<Employee>();

            for (int i = 0; i < countOfEmployees; i++)
            {
                string str = Console.ReadLine();
                string[] strArr = str.Split(' ');
                employees.Add(new Employee
                {
                    FirstName = strArr[0],
                    LastName = strArr[1],
                    Company = strArr[2],
                    Age = int.Parse(strArr[3])
                });
            }

            foreach (var emp in AverageAgeForEachCompany(employees))
            {
                Console.WriteLine($"The average age for company {emp.Key} is {emp.Value}");
            }

            foreach (var emp in CountOfEmployeesForEachCompany(employees))
            {
                Console.WriteLine($"The count of employees for company {emp.Key} is {emp.Value}");
            }

            foreach (var emp in OldestAgeForEachCompany(employees))
            {
                Console.WriteLine($"The oldest employee of company {emp.Key} is {emp.Value.FirstName} {emp.Value.LastName} having age {emp.Value.Age}");

            }

        }
    }

    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }
    }
}
