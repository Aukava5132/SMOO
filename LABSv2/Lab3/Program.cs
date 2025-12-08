using System;
using System.Collections.Generic;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            Console.WriteLine("=== ЛАБОРАТОРНА РОБОТА 3 ===");
            Console.WriteLine();
            
            RunCompanyPart();
            
            Console.WriteLine("\n" + new string('=', 60) + "\n");
            
            RunTelephonePart();
            
            Console.WriteLine("\n" + new string('=', 60) + "\n");
            
            RunFactoryPart();
            
            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
        
        static void RunCompanyPart()
        {
            Console.WriteLine("ЧАСТИНА 1: ФІРМИ");
            Console.WriteLine();
            
            var companies = new List<Company>();
            var companyCollection = new CompanyCollection(companies);
            CompanyGenerator.GenerateRandomCompanies(companyCollection, 10);
            Printer.PrintAllCompanies(companyCollection);
            Printer.PrintCompaniesByName(companyCollection, "Food");
            Printer.PrintMarketingCompanies(companyCollection);
            Printer.PrintMarketingOrITCompanies(companyCollection);
            Printer.PrintCompaniesMoreThan(companyCollection, 100);
            Printer.PrintCompaniesWithEmployeesBetween(companyCollection, 100, 300);
            Printer.PrintCompaniesInCity(companyCollection, "London");
            Printer.PrintCompaniesByDirectorLastName(companyCollection, "Black");
            Printer.PrintCompaniesOlderThanYears(companyCollection, 2);
            Printer.PrintCompaniesOlderThanDays(companyCollection, 150);
            Printer.PrintCompaniesComplexQuery(companyCollection);
        }
        
        static void RunTelephonePart()
        {
            Console.WriteLine("ЧАСТИНА 2: ТЕЛЕФОНИ");
            Console.WriteLine();
            var telephones = new List<Telephone>();
            var telephoneCollection = new TelephoneCollection(telephones);
            TelephoneGenerator.GenerateRandomTelephone(telephoneCollection, 15);
            Printer.PrintTelephoneCollectionInfo(telephoneCollection);
        }
        
        static void RunFactoryPart()
        {
            Console.WriteLine("ЧАСТИНА 3: ПІДПРИЄМСТВО");
            Console.WriteLine();
            var factory = new Factory();
            Printer.PrintFactoryInfo(factory);
        }
    }
}