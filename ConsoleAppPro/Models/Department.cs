using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppPro.Models
{
    internal class Department
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                while (value.Length < 2)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Department adi minimul 2 herf olmalidir! Yeniden Daxil edin!");
                    Console.ResetColor();
                    value = Console.ReadLine();
                }
                _name = value.Trim().ToUpper();
            }
        }
        private int _workerlimit;
        public int WorkerLimit
        {
            get { return _workerlimit; }
            set
            {
                while (value < 1 || value > 100)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("WorkerLimit Min 1, Max 100 olmalidir! Yeniden daxil edin!");
                    Console.ResetColor();
                    while (!int.TryParse(Console.ReadLine().Trim(), out value))
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Duzgun deyer daxil edin!");
                        Console.ResetColor();
                    }
                }
                _workerlimit = value;
            }
        }
        private double _salarylimit;
        public double SalaryLimit
        {
            get { return _salarylimit; }
            set
            {
                while (value < WorkerLimit * 250)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"SalaryLimit {WorkerLimit} Employee ucun minimum {WorkerLimit * 250} olmalidir! Yeniden daxil edin!");
                    Console.ResetColor();
                    while (!double.TryParse(Console.ReadLine(), out value))
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Duzgun deyer daxil edin!");
                        Console.ResetColor();
                    }
                }
                _salarylimit = value;
            }
        }
        public Employee[] Employees;

        public Department(string name, int workerlimit, double salarylimit)
        {
            Employees = new Employee[0];
            Name = name.Trim().ToUpper();
            WorkerLimit = workerlimit;
            SalaryLimit = salarylimit;
        }
        public double CalcSalaryAverage()
        {
            if (Employees.Length > 0)
            {
                double sum = 0;
                foreach (Employee item in Employees)
                {
                    sum += item.Salary;
                }
                return (sum / Employees.Length);
            }
            return SalaryLimit;
        }
        public void AddEmployee(string fullname, string position, double salary, string departamentname)
        {
            if (Employees.Length <= WorkerLimit)
            {
                while (salary > (SalaryLimit - Employees.Length * CalcSalaryAverage()))
                {
                    Console.WriteLine($"SalaryLimit nezere alsaq Salary max {SalaryLimit - Employees.Length * CalcSalaryAverage()} ola biler!");

                    if ((SalaryLimit - Employees.Length * CalcSalaryAverage()) < 250)
                    {
                        Console.WriteLine("Bu gostericide Min emek haqqina ziddir!");
                        return;
                    }
                    Console.WriteLine("Duzgun deyer daxil edin!");
                    while (!double.TryParse(Console.ReadLine(), out salary))
                    {
                        Console.WriteLine("Duzgun deyer daxil edin!");
                    }

                }
                Array.Resize(ref Employees, Employees.Length + 1);
                Employees[Employees.Length - 1] = new Employee(fullname, position, salary, departamentname);
                Console.WriteLine("Employee ugurla elave edildi!");
                return;
            }
            else
            {
                Console.WriteLine("Departmentde yeni ishci elave etmek ucun yer yoxdur!");
            }
        }

        public override string ToString()
        {
            return $"Name:{Name} /Limit:{WorkerLimit} /Max Salary for all:{SalaryLimit}";
        }
    }
}
