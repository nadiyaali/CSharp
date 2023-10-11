// See https://aka.ms/new-console-template for more information
using System;
using System.ComponentModel;

namespace EmployeeFactoryPattern;
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<IEmployee> employeeList = new List<IEmployee>();
            SeedData(employeeList);

            foreach(IEmployee employee in employeeList)
            {
                    Console.WriteLine($"id : {employee.Id}\tName : {employee.FirstName} {employee.LastName} \tSalary : {employee.Salary}");
            }

            decimal totalSalaries = 0M;
            foreach (IEmployee employee in employeeList)
            {
                totalSalaries += employee.Salary;
            }

            Console.WriteLine($"Total Salaries : {totalSalaries}");
        
        }
   
        public static void SeedData(List<IEmployee> employees)
        {
            IEmployee teacher1 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 1,"Joe", "Jonas", 1000M );
            employees.Add(teacher1);

            IEmployee headmaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadMaster, 2,"Alan", "Alanna", 1000M );
            employees.Add(headmaster);
            
            IEmployee deputyheadmaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.DeputyHeadMaster, 3,"Ned", "Kelly", 1000M );
            employees.Add(deputyheadmaster);
            
            IEmployee headofdepartment = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadOfDepartment, 4,"Mina", "Mink", 1000M );
            employees.Add(headofdepartment);
            

        }

   
    }



