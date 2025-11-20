namespace Lab1;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        StudentLibrary library = new StudentLibrary();
        StudentPrinter printer = new StudentPrinter();
        StudentInputManager inputManager = new StudentInputManager();
        StudentSerializationManager serializationManager = new StudentSerializationManager();
        
        inputManager.FillLibrary(library);
        
        Student[] allStudents = library.GetAllStudents();
        printer.PrintStudents(allStudents, "Всі студенти");
        printer.PrintStudentSummary(allStudents);

        serializationManager.ManageSerialization(allStudents, printer);
        
        Student[] successfulStudents = library.GetSuccessfulStudents(8.0);
        printer.PrintStudents(successfulStudents, "Успішні студенти (середній бал >= 8)");

        Console.ReadLine();
    }
}