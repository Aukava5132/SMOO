namespace Lab3;
using System;

public class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        CompanyCollection companyCollection = new CompanyCollection();
        
        // Генерируем компании
        CompanyGenerator.GenerateRandomCompanies(companyCollection, 5);
        
        // Выводим всю информацию
        Printer.PrintAllInfo(companyCollection);
        
        // Дополнительно: первая компания
        Console.WriteLine("=== ПЕРВАЯ КОМПАНИЯ ===");
        Printer.PrintCompany(companyCollection.First());
    }
}