using System;
using System.Collections.Generic;

namespace Lab3
{
    public static class Printer
    {
        public static void PrintAllCompanies(CompanyCollection collection)
        {
            Console.WriteLine("=== Всі фірми ===");
            foreach (var company in collection.AllCompanies())
            {
                Console.WriteLine(company);
            }
            Console.WriteLine();
        }

        public static void PrintCompaniesByName(CompanyCollection collection, string name)
        {
            Console.WriteLine($"=== Фірми з назвою '{name}' ===");
            var companies = collection.CompaniesByName(name);
            if (companies.Count == 0)
            {
                Console.WriteLine("Фірми не знайдено");
            }
            else
            {
                foreach (var company in companies)
                {
                    Console.WriteLine(company);
                }
            }
            Console.WriteLine();
        }

        public static void PrintMarketingCompanies(CompanyCollection collection)
        {
            Console.WriteLine("=== Фірми у галузі маркетингу ===");
            var companies = collection.MarketingCompanies();
            if (companies.Count == 0)
            {
                Console.WriteLine("Фірми не знайдено");
            }
            else
            {
                foreach (var company in companies)
                {
                    Console.WriteLine(company);
                }
            }
            Console.WriteLine();
        }

        public static void PrintMarketingOrITCompanies(CompanyCollection collection)
        {
            Console.WriteLine("=== Фірми у галузі маркетингу або IT ===");
            var companies = collection.MarketingOrITCompanies();
            if (companies.Count == 0)
            {
                Console.WriteLine("Фірми не знайдено");
            }
            else
            {
                foreach (var company in companies)
                {
                    Console.WriteLine(company);
                }
            }
            Console.WriteLine();
        }

        public static void PrintCompaniesMoreThan(CompanyCollection collection, int count)
        {
            Console.WriteLine($"=== Фірми з кількістю співробітників > {count} ===");
            var companies = collection.CompaniesMoreThan(count);
            if (companies.Count == 0)
            {
                Console.WriteLine("Фірми не знайдено");
            }
            else
            {
                foreach (var company in companies)
                {
                    Console.WriteLine(company);
                }
            }
            Console.WriteLine();
        }

        public static void PrintCompaniesWithEmployeesBetween(CompanyCollection collection, int min, int max)
        {
            Console.WriteLine($"=== Фірми з кількістю співробітників від {min} до {max} ===");
            var companies = collection.CompaniesWithEmployeesBetween(min, max);
            if (companies.Count == 0)
            {
                Console.WriteLine("Фірми не знайдено");
            }
            else
            {
                foreach (var company in companies)
                {
                    Console.WriteLine(company);
                }
            }
            Console.WriteLine();
        }

        public static void PrintCompaniesInCity(CompanyCollection collection, string city)
        {
            Console.WriteLine($"=== Фірми в місті '{city}' ===");
            var companies = collection.CompaniesInCity(city);
            if (companies.Count == 0)
            {
                Console.WriteLine("Фірми не знайдено");
            }
            else
            {
                foreach (var company in companies)
                {
                    Console.WriteLine(company);
                }
            }
            Console.WriteLine();
        }

        public static void PrintCompaniesByDirectorLastName(CompanyCollection collection, string lastName)
        {
            Console.WriteLine($"=== Фірми з директором прізвища '{lastName}' ===");
            var companies = collection.CompaniesByDirectorLastName(lastName);
            if (companies.Count == 0)
            {
                Console.WriteLine("Фірми не знайдено");
            }
            else
            {
                foreach (var company in companies)
                {
                    Console.WriteLine(company);
                }
            }
            Console.WriteLine();
        }

        public static void PrintCompaniesOlderThanYears(CompanyCollection collection, int years)
        {
            Console.WriteLine($"=== Фірми засновані понад {years} років тому ===");
            var companies = collection.CompaniesOlderThanYears(years);
            if (companies.Count == 0)
            {
                Console.WriteLine("Фірми не знайдено");
            }
            else
            {
                foreach (var company in companies)
                {
                    Console.WriteLine(company);
                }
            }
            Console.WriteLine();
        }

        public static void PrintCompaniesOlderThanDays(CompanyCollection collection, int days)
        {
            Console.WriteLine($"=== Фірми засновані понад {days} днів тому ===");
            var companies = collection.CompaniesOlderThanDays(days);
            if (companies.Count == 0)
            {
                Console.WriteLine("Фірми не знайдено");
            }
            else
            {
                foreach (var company in companies)
                {
                    Console.WriteLine(company);
                }
            }
            Console.WriteLine();
        }

        public static void PrintCompaniesComplexQuery(CompanyCollection collection)
        {
            Console.WriteLine("=== Фірми: директор Black та назва містить White ===");
            var companies = collection.CompaniesComplexQuery();
            if (companies.Count == 0)
            {
                Console.WriteLine("Фірми не знайдено");
            }
            else
            {
                foreach (var company in companies)
                {
                    Console.WriteLine(company);
                }
            }
            Console.WriteLine();
        }

        public static void PrintTelephoneCollectionInfo(TelephoneCollection collection)
        {
            Console.WriteLine("=== Інформація про телефони ===");
            Console.WriteLine($"Загальна кількість телефонів: {collection.Count()}");
            Console.WriteLine($"Кількість телефонів з ціною > 100: {collection.CountPriceGreaterThan(100)}");
            Console.WriteLine($"Кількість телефонів з ціною від 400 до 700: {collection.CountPriceBetween(400, 700)}");
            Console.WriteLine($"Кількість телефонів Samsung: {collection.CountName("Samsung")}");
            Console.WriteLine($"Телефон з мінімальною ціною: {collection.MinPrice()}");
            Console.WriteLine($"Телефон з максимальною ціною: {collection.MaxPrice()}");
            Console.WriteLine($"Найстаріший телефон: {collection.Oldest()}");
            Console.WriteLine($"Найновіший телефон: {collection.Newest()}");
            Console.WriteLine($"Середня ціна телефонів: {collection.AveragePrice():F2}");
            
            Console.WriteLine("\n=== 5 найдорожчих телефонів ===");
            foreach (var phone in collection.MaxPriceTop5())
            {
                Console.WriteLine($"  {phone}");
            }
            
            Console.WriteLine("\n=== 5 найдешевших телефонів ===");
            foreach (var phone in collection.MinPriceTop5())
            {
                Console.WriteLine($"  {phone}");
            }
            
            Console.WriteLine("\n=== 3 найстаріших телефони ===");
            foreach (var phone in collection.Top3Oldest())
            {
                Console.WriteLine($"  {phone}");
            }
            
            Console.WriteLine("\n=== 3 найновіших телефони ===");
            foreach (var phone in collection.Top3Newest())
            {
                Console.WriteLine($"  {phone}");
            }
            
            Console.WriteLine("\n=== Статистика за виробниками ===");
            foreach (var stat in collection.BrandStatistics())
            {
                Console.WriteLine($"  {stat.Key}: {stat.Value} шт.");
            }
            
            Console.WriteLine("\n=== Статистика за роками випуску ===");
            foreach (var stat in collection.ManufactureDateStatistics())
            {
                Console.WriteLine($"  {stat.Key:yyyy}: {stat.Value} шт.");
            }
            Console.WriteLine();
        }

        public static void PrintFactoryInfo(Factory factory)
        {
            Console.WriteLine("=== Інформація про підприємство ===");
            Console.WriteLine($"Кількість робітників: {factory.WorkerCount()}");
            Console.WriteLine($"Загальний обсяг зарплат: {factory.TotalSalary():F2} грн.");
            
            var youngestWithHigherEd = factory.YoungestWithHigherEducationFromTop10();
            Console.WriteLine($"\nНаймолодший робітник з вищою освітою з ТОП-10 за стажем:");
            Console.WriteLine($"  {youngestWithHigherEd.FirstName} {youngestWithHigherEd.LastName}, " +
                            $"Вік: {youngestWithHigherEd.Age}, Стаж: {youngestWithHigherEd.ExperienceYears} років, " +
                            $"Освіта: {(youngestWithHigherEd.HasHigherEducation ? "Вища" : "Без вищої")}");
            
            var (youngestManager, oldestManager) = factory.YoungestAndOldestManagers();
            Console.WriteLine($"\nСамий молодий менеджер: {youngestManager.FirstName} {youngestManager.LastName}, " +
                            $"Вік: {youngestManager.Age}, Департамент: {youngestManager.Department}");
            Console.WriteLine($"Самий старший менеджер: {oldestManager.FirstName} {oldestManager.LastName}, " +
                            $"Вік: {oldestManager.Age}, Департамент: {oldestManager.Department}");
            
            var octoberBorn = factory.OctoberBornEmployees();
            Console.WriteLine($"\nСпівробітники, які народилися у жовтні ({octoberBorn.Count} чол.):");
            foreach (var person in octoberBorn)
            {
                Console.WriteLine($"  {person.GetPosition()}: {person.FirstName} {person.LastName}, " +
                                $"Дата народження: {person.BirthDate:dd.MM.yyyy}");
            }
            
            var vladimirs = factory.AllVladimirs();
            Console.WriteLine($"\nВсі Володимири на підприємстві ({vladimirs.Count} чол.):");
            foreach (var vladimir in vladimirs)
            {
                Console.WriteLine($"  {vladimir.GetPosition()}: {vladimir.FirstName} {vladimir.LastName}, " +
                                $"Вік: {vladimir.Age}, Зарплата: {vladimir.Salary:F2} грн.");
            }
            
            if (vladimirs.Count > 0)
            {
                var youngestVladimir = factory.YoungestVladimirWithBonus();
                double bonus = youngestVladimir.Salary / 3;
                Console.WriteLine($"\nПоздоровлення з премією наймолодшому Володимиру:");
                Console.WriteLine($"  {youngestVladimir.GetPosition()}: {youngestVladimir.FirstName} {youngestVladimir.LastName}");
                Console.WriteLine($"  Вік: {youngestVladimir.Age}");
                Console.WriteLine($"  Премія: {bonus:F2} грн. (1/3 від окладу {youngestVladimir.Salary:F2} грн.)");
            }
            Console.WriteLine();
        }
    }
}