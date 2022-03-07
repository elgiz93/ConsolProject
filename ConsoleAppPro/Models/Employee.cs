using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppPro.Models
{
    internal class Employee
    {
        public string No;
        public string FullName;
        private string _position;
        public string Position
        {
            get { return _position; }
            set
            {
                while (value.Length < 2)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Position minimum 2 herf olmalidir! Yeniden daxil edin!");
                    Console.ResetColor();
                    value = Console.ReadLine().Trim().ToUpper();
                }
                _position = value.ToUpper();
            }
        }
        private double _salary;
        public double Salary
        {
            get { return _salary; }
            set
            {
                while (value < 250)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Minimal emek haqqi 250AZN olmalidir! Yeniden daxil edin!");
                    Console.ResetColor();
                    while (!double.TryParse(Console.ReadLine(), out value))
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Duzgun deyer daxil edin!");
                        Console.ResetColor();

                    }
                }
                _salary = value;
            }
        }
        public string DepartamentName;
        static int _count = 1000;

        public Employee(string fullname, string position, double salary, string departamentname)
        {
            _count++;
            No = $"{char.ToUpper(departamentname[0])}{char.ToUpper(departamentname[1])}{_count}";
            FullName = fullname.Trim().ToUpper();
            Position = position.Trim().ToUpper();
            Salary = salary;
            DepartamentName = departamentname.Trim().ToUpper();

        }
        public override string ToString()
        {
            return $"Nomresi:{No} /Adi:{FullName} /Vezifesi:{Position} /Maasi:{Salary} /Department:{DepartamentName}";
        }
    }
}
