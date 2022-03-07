using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAppPro.Models;

namespace ConsoleAppProject.Interfaces
{
    internal interface IHumanResourceManager
    {
        Department[] Departments { get; }

        void AddDepartment(string name, int workerlimit, double salarylimit);
        Department[] GetDepartments();
        void EditDepartments(string olddepartment, string newdepartment);
        void AddEmployee(string fullname, string position, double salary, string departamentname);
        void RemoveEmployee(string no, string departamentname);
        void EditEmployee(string no, string fullname, string position, double salary);
    }
}

