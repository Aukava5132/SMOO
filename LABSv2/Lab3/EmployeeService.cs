using System;
using System.Collections.Generic;
using System.Linq;
using Lab3.Models;
using Lab3.Interfaces;

namespace Lab3.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly List<Employee> _employees;
        
        public EmployeeService(List<Employee> employees)
        {
            _employees = employees;
        }
        
        public int GetWorkerCount()
        {
            return _employees.OfType<Worker>().Count();
        }
        
        public decimal CalculateTotalSalary()
        {
            return _employees.Sum(e => e.Salary);
        }
        
        public IEnumerable<Employee> GetTopExperiencedWorkers(int count)
        {
            return _employees.OfType<Worker>()
                .OrderByDescending(w => w.WorkExperience)
                .Take(count);
        }
        
        public (Employee youngest, Employee oldest) GetYoungestAndOldestManagers()
        {
            var managers = _employees.OfType<Manager>().ToList();
            var youngest = managers.OrderBy(m => m.Age).FirstOrDefault();
            var oldest = managers.OrderByDescending(m => m.Age).FirstOrDefault();
            
            return (youngest, oldest);
        }
        
        public IEnumerable<Employee> GetEmployeesBornInMonth(int month)
        {
            return _employees.Where(e => e.BirthDate.Month == month);
        }
        
        public IEnumerable<Employee> GetEmployeesByName(string name)
        {
            return _employees.Where(e => e.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}