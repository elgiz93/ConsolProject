using System;
using ConsoleAppPro.Models;
using ConsoleAppPro.Services;

namespace ConsoleAppPro
{
    internal class Program
    {
        static void Main(string[] args)
        {

            HumanResourceManager humanresourcemanager = new HumanResourceManager();


            do
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n===============Xos Gelmisiniz==============");
                Console.ResetColor();
                Console.WriteLine("1. Departameantlerin siyahisini gostermek:");
                Console.WriteLine("2. Departamenet yaratmaq");
                Console.WriteLine("3. Departmanetde deyisiklik etmek");
                Console.WriteLine("4. Iscilerin siyahisini gostermek:");
                Console.WriteLine("5. Departamentdeki iscilerin siyahisini gostermrek:");
                Console.WriteLine("6. Isci elave etmek:");
                Console.WriteLine("7. Isci uzerinde deyisiklik etmek:");
                Console.WriteLine("8. Departamentden isci silinmesi:");
                Console.WriteLine("9. Sistemden Cixis:\n");
                Console.WriteLine("Acilan Menu Pencerisnde Bir Secim Edin. Reqem Daxil Edin:");

                string choose = Console.ReadLine();
                int chooseNum;

                while (!int.TryParse(choose, out chooseNum) || chooseNum < 1 || chooseNum > 9)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Duzgun Secim Edin:");
                    Console.ResetColor();
                    choose = Console.ReadLine();
                }

                Console.Clear();

                switch (chooseNum)
                {
                    case 1:
                        ShowDepartments(ref humanresourcemanager);
                        break;
                    case 2:
                        CreateDepartment(ref humanresourcemanager);
                        break;
                    case 3:
                        EditDepartment(ref humanresourcemanager);
                        break;
                    case 4:
                        ShowAllEmployees(ref humanresourcemanager);
                        break;
                    case 5:
                        ShowDepartmentEmployees(ref humanresourcemanager);
                        break;
                    case 6:
                        AddEmployee(ref humanresourcemanager);
                        break;
                    case 7:
                        EditEmployee(ref humanresourcemanager);
                        break;
                    case 8:
                        RemoveEmployee(ref humanresourcemanager);
                        break;
                    case 9:
                        return;
                }

            } while (true);


            static void ShowDepartments(ref HumanResourceManager humanresourcemanager)
            {
                if (humanresourcemanager.GetDepartments().Length < 1)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Hal hazirda yaradilmis Department yoxdur");
                    Console.ResetColor();
                    return;
                }
                foreach (Department item in humanresourcemanager.GetDepartments())
                {
                    Console.WriteLine(item);
                }

            }
            static void CreateDepartment(ref HumanResourceManager humanresourcemanager)
            {

                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Departament yaratmaq ucun asagidakilari daxil edin:");
                Console.ResetColor();
                Console.WriteLine("Departamentin adi");

                string name = Console.ReadLine().Trim().ToUpper();

                Console.WriteLine("Departamentin maximal ishci sayini qeyd edin");
                int workerlimit;
                while (!int.TryParse(Console.ReadLine().Trim(), out workerlimit))
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Duzgun deyer daxil edin!");
                    Console.ResetColor();
                }
                Console.WriteLine("Departamentin maximal salary limit qeyd edin");
                double salarylimit;
                while (!double.TryParse(Console.ReadLine().Trim(), out salarylimit))
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Duzgun deyer daxil edin!");
                    Console.ResetColor();
                }
                humanresourcemanager.AddDepartment(name, workerlimit, salarylimit);
                Console.WriteLine("Department ugurla yaradildi!");
            }
            static void EditDepartment(ref HumanResourceManager humanresourcemanager)
            {
                if (humanresourcemanager.Departments.Length < 1)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Department movcud deyil!");
                    Console.ResetColor();
                    return;
                }

                ShowDepartments(ref humanresourcemanager);

                Console.WriteLine("Adini deyismek istediyiniz Departmentin adini qeyd edin!");
                string oldname = Console.ReadLine().Trim().ToUpper();

                foreach (Department item in humanresourcemanager.Departments)
                {
                    if (item.Name == oldname)
                    {
                        Console.WriteLine("Yeni adi qeyd edin!");
                        string newname = Console.ReadLine();
                        humanresourcemanager.EditDepartments(oldname, newname);
                        return;
                    }
                }
                Console.WriteLine("Daxil edilen adda Department yoxdur!");
            }
            static void ShowAllEmployees(ref HumanResourceManager humanresourcemanager)
            {

                if (humanresourcemanager.Departments.Length < 1)
                {
                    Console.WriteLine("Deportment olmadi ucun Employee-de yoxdur!");
                }
                foreach (Department department in humanresourcemanager.Departments)
                {
                    if (department.Employees.Length > 0)
                    {
                        Console.WriteLine($"{department.Name}-departamentindeki Employee siyahisi");
                        foreach (Employee item in department.Employees)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{department.Name}-departamentinde Employee yoxdur");
                    }
                }
            }
            static void ShowDepartmentEmployees(ref HumanResourceManager humanresourcemanager)
            {
                if (humanresourcemanager.Departments.Length < 1)
                {
                    Console.WriteLine("Departament movcud deyil");
                    return;
                }
                ShowDepartments(ref humanresourcemanager);
                Console.WriteLine("Ishcilerini gostermek istediyiniz Department adini qeyd edin!");
                string department = Console.ReadLine().Trim().ToUpper();
                foreach (Department item in humanresourcemanager.Departments)
                    if (item.Name == department)
                    {
                        if (item.Employees.Length > 0)
                        {
                            foreach (Employee ishci in item.Employees)
                            {
                                Console.WriteLine(ishci);
                            }
                            return;
                        }
                        Console.WriteLine("Daxil edilen Departmentde ishci movcud deyil!");
                        return;
                    }

                Console.WriteLine("Daxil edilen adda Department yoxdur!");


            }
            static void AddEmployee(ref HumanResourceManager humanresourcemanager)
            {
                if (humanresourcemanager.Departments.Length < 1)
                {
                    Console.WriteLine("Department movcud deyil! Ilk once Department yaradin!");
                    return;
                }
                foreach (Department depa in humanresourcemanager.Departments)
                { Console.WriteLine($"{depa}"); }

                Console.WriteLine("Ishcini elave etmek istediyiniz Department adini daxil edin!");
                string department = Console.ReadLine().Trim().ToUpper();

                Console.WriteLine("Yeni ishcinin adini qeyd edin!");
                string fullname = Console.ReadLine().Trim().ToUpper();

                Console.WriteLine("Yeni ishcinin maasini qeyd edin!");
                double salary = 0;
                while (!double.TryParse(Console.ReadLine(), out salary))
                {
                    Console.WriteLine("Duzugun deyer edin!");
                }

                Console.WriteLine("Yeni ishcinin pozisiyasini qeyd edin!");
                string position = Console.ReadLine().Trim().ToUpper();

                humanresourcemanager.AddEmployee(fullname, position, salary, department);

            }
            static void EditEmployee(ref HumanResourceManager humanresourcemanager)
            {
                if (humanresourcemanager.Departments.Length < 1)
                {
                    Console.WriteLine("Departament movcud deyil! Employee-de yoxdur!");
                    return;
                }
                ShowAllEmployees(ref humanresourcemanager);

                Console.WriteLine("Deyishmek istediyiniz ishcinin nomresini daxil edin!");
                string no = Console.ReadLine().Trim().ToUpper();

                foreach (Department item in humanresourcemanager.Departments)
                {
                    foreach (Employee empl in item.Employees)
                    {
                        if (empl.No == no)
                        {
                            Console.WriteLine(empl);
                            Console.WriteLine("Ishcinin yeni maasini qeyd edin!");
                            Console.WriteLine($"Daxil edile bilen max deyer:{item.SalaryLimit + empl.Salary - (item.Employees.Length * item.CalcSalaryAverage())}");
                            double salary = 0;
                            while (!double.TryParse(Console.ReadLine(), out salary) || salary > (item.SalaryLimit + empl.Salary - (item.Employees.Length * item.CalcSalaryAverage())))
                            {
                                Console.WriteLine($"Duzugun deyer daxil edin!");
                            }
                            Console.WriteLine("Ishcinin yeni pozisiyasini qeyd edin!");
                            string position = Console.ReadLine().Trim().ToUpper();
                            humanresourcemanager.EditEmployee(no, empl.FullName, position, salary);
                            return;
                        }


                    }
                }
                Console.WriteLine("Bu nomreli ishci tapilmadi");
                return;
            }
            static void RemoveEmployee(ref HumanResourceManager humanresourcemanager)
            {
                if (humanresourcemanager.Departments.Length < 1)
                {
                    Console.WriteLine("Department movcud deyil!");
                    return;
                }
                foreach (Department depa in humanresourcemanager.Departments)
                {
                    Console.WriteLine($"{depa}");
                }

                Console.WriteLine("Ishcini silmek istediyiniz Department adini daxil edin!");
                string department = Console.ReadLine().Trim().ToUpper();

                foreach (Department item in humanresourcemanager.Departments)
                {
                    if (item.Name == department)
                    {
                        if (item.Employees.Length < 1)
                        {
                            Console.WriteLine("Departamentde Employee yoxdur!");
                            return;
                        }
                        foreach (Employee isci in item.Employees)
                        {
                            Console.WriteLine($"{isci}");
                        }
                        Console.WriteLine("Silmek istediyiniz ishcinin nomresini daxil edin");
                        string no = Console.ReadLine().Trim().ToUpper();
                        humanresourcemanager.RemoveEmployee(no, department);
                        return;
                    }
                }
                Console.WriteLine("Daxil edilen adda department yoxdur");

            }
        }
    }
}
