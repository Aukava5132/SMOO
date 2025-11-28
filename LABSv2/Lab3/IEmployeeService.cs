using System.Collections.Generic;

namespace Lab3
{
    public interface IEmployeeService
    {
        int GetWorkerCount();
        decimal CalculateTotalSalary();
        IEnumerable<Employee> GetTopExperiencedWorkers(int count);
        (Employee youngest, Employee oldest) GetYoungestAndOldestManagers();
        IEnumerable<Employee> GetEmployeesBornInMonth(int month);
        IEnumerable<Employee> GetEmployeesByName(string name);
    }
}