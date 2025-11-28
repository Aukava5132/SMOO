using System;
using System.Collections.Generic;
using System.Linq;
using Lab3.Models;
using Lab3.Services;
using Lab3.Interfaces;
using Lab3.Filters;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Данные для компаний
            var companies = new List<Company>
            {
                new Company { Name = "Food Corp", BusinessProfile = "Food", EmployeeCount = 150, 
                            Address = "London", DirectorName = "John White", FoundationDate = new DateTime(2020, 1, 1) },
                new Company { Name = "Tech Solutions", BusinessProfile = "IT", EmployeeCount = 200, 
                            Address = "New York", DirectorName = "Mike Black", FoundationDate = new DateTime(2022, 1, 1) }
            };
            
            // 2. Данные для телефонов
            var phones = new List<Phone>
            {
                new Phone { Model = "iPhone 13", Manufacturer = "Apple", Price = 999, ReleaseDate = new DateTime(2021, 9, 1) },
                new Phone { Model = "Galaxy S22", Manufacturer = "Samsung", Price = 799, ReleaseDate = new DateTime(2022, 2, 1) }
            };
            
            // 3. Данные для сотрудников
            var employees = new List<Employee>
            {
                new Worker { Name = "Vladimir Ivanov", Age = 25, BirthDate = new DateTime(1998, 10, 15), 
                           Salary = 1000, WorkExperience = 5, HasHigherEducation = true },
                new Manager { Name = "Vladimir Petrov", Age = 35, BirthDate = new DateTime(1988, 3, 20), 
                            Salary = 2000, WorkExperience = 10, HasHigherEducation = true }
            };
            
            // 4. Использование сервисов
            var companyService = new CompanyService(companies);
            var phoneService = new PhoneService(phones);
            var employeeService = new EmployeeService(employees);
            
            // Примеры запросов:
            Console.WriteLine("=== КОМПАНИИ ===");
            var foodCompanies = companyService.GetCompaniesByProfile("Food");
            foreach (var company in foodCompanies)
            {
                Console.WriteLine($"Food company: {company.Name}");
            }
            
            Console.WriteLine("\n=== ТЕЛЕФОНЫ ===");
            Console.WriteLine($"Total phones: {phoneService.GetPhoneCount()}");
            Console.WriteLine($"Average price: {phoneService.GetAveragePrice():C}");
            
            Console.WriteLine("\n=== СОТРУДНИКИ ===");
            var vladimirs = employeeService.GetEmployeesByName("Vladimir");
            foreach (var emp in vladimirs)
            {
                Console.WriteLine($"Vladimir found: {emp.Name}");
            }
        }
    }
}