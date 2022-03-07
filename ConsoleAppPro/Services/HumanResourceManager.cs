using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAppPro.Models;
using ConsoleAppProject.Interfaces;

namespace ConsoleAppPro.Services
{
        internal class HumanResourceManager : IHumanResourceManager
        {

            private Department[] _departments;
            public Department[] Departments { get { return _departments; } }

            public HumanResourceManager()
            {
                _departments = new Department[0];
            }

            public void AddDepartment(string name, int workerlimit, double salarylimit)
            {
                bool check = true;
                while (check)
                {
                    check = false;
                    foreach (Department item in Departments)
                        if (item.Name == name)
                        {
                            Console.WriteLine("Daxil edilen departament adi artiq movcuddur! Bashqa ad daxil edin!");
                            name = Console.ReadLine().Trim().ToUpper();
                            check = true;
                        }
                }
                Array.Resize(ref _departments, _departments.Length + 1);

                _departments[_departments.Length - 1] = new Department(name, workerlimit, salarylimit);
            }

            public void AddEmployee(string fullname, string position, double salary, string departamentname)
            {

                foreach (Department item in _departments)
                {
                    if (item.Name == departamentname.Trim().ToUpper())
                    {
                        if (item.Employees.Length < item.WorkerLimit)
                        {
                            item.AddEmployee(fullname, position, salary, departamentname);
                            return;
                        }
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Daxil edilmish Departmentde yer yoxdur!");
                        Console.ResetColor();
                        return;
                    }
                }
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Daxil edilmish adda Department yoxdur duzgun daxil edin!");
                Console.ResetColor();
            }

            public void EditDepartments(string oldname, string newname)
            {
                bool check = true;
                while (check)
                {
                    check = false;
                    foreach (Department item in _departments)
                    {
                        if (item.Name == newname.Trim().ToUpper())
                        {
                            Console.WriteLine("Yeni vermek istediyiniz adda Department artiq movcuddur! Basqa ad secin");
                            newname = Console.ReadLine();
                            check = true;
                        }
                    }
                }
                foreach (Department item in _departments)
                {
                    if (item.Name == oldname.Trim().ToUpper())
                    {
                        item.Name = newname.Trim().ToUpper();

                        foreach (Employee empl in item.Employees)
                        {
                            empl.No = $"{item.Name[0]}{item.Name[1]}{empl.No[2]}{empl.No[3]}{empl.No[4]}{empl.No[5]}";
                            empl.DepartamentName = item.Name;
                        }
                        return;
                    }
                }
            }

            public void EditEmployee(string no, string fullname, string position, double salary)
            {
                foreach (Department item in _departments)
                {
                    foreach (Employee employee in item.Employees)
                    {
                        if (employee.No == no.Trim().ToUpper())
                        {
                            employee.Salary = salary;
                            employee.Position = position.Trim().ToUpper();
                            employee.FullName = fullname.Trim().ToUpper();
                            return;
                        }
                    }
                }
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Daxil edilmish adda hec bir Departmentde Employee yoxdur duzgun daxil edin!");
                Console.ResetColor();
            }

            public Department[] GetDepartments()
            {

                return _departments;

            }

            public void RemoveEmployee(string no, string departamentname)
            {
                foreach (Department department in _departments)
                {
                    if (department.Name == departamentname.Trim().ToUpper())
                    {
                        for (int i = 0; i < department.Employees.Length; i++)
                        {
                            if (department.Employees[i].No == no.Trim().ToUpper())
                            {
                                department.Employees[i] = department.Employees[department.Employees.Length - 1];
                                Array.Resize(ref department.Employees, department.Employees.Length - 1);
                                return;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Daxil edilen departamentde bu adda ishci yoxdur!");
                                Console.ResetColor();
                                return;
                            }
                        }
                    }

                }
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Daxil edilmish adda hec bir Department yoxdur duzgun daxil edin!");
                Console.ResetColor();
            }
        }
}
