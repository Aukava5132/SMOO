namespace Lab2;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        StudentMenu studentMenu = new StudentMenu();
        studentMenu.Start();
    }
}