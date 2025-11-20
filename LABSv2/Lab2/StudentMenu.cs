namespace Lab2;
using System;

public class StudentMenu
{
    private StudentCollectionManager _collectionManager;

    public StudentMenu()
    {
        _collectionManager = new StudentCollectionManager();
    }

    public void Start()
    {
        bool running = true;
        
        while (running)
        {
            ShowMenu();
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    _collectionManager.ShowAllStudents();
                    break;
                case "2":
                    _collectionManager.AddStudentsMenu();
                    break;
                case "3":
                    _collectionManager.RemoveStudentsMenu();
                    break;
                case "4":
                    _collectionManager.EditStudent();
                    break;
                case "5":
                    _collectionManager.SearchStudentsMenu();
                    break;
                case "6":
                    _collectionManager.ClearCollection();
                    break;
                case "0":
                    Console.WriteLine("До побачення!");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Неправильний вибір! Введіть число від 0 до 6");
                    break;
            }
            
            if (running)
            {
                Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
                Console.ReadKey();
            }
        }
    }

    private void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("=== УПРАВЛІННЯ КОЛЕКЦІЄЮ СТУДЕНТІВ ===");
        Console.WriteLine("1 - Показати всіх студентів");
        Console.WriteLine("2 - Додати студентів");
        Console.WriteLine("3 - Видалити студентів");
        Console.WriteLine("4 - Редагувати студента");
        Console.WriteLine("5 - Пошук студентів");
        Console.WriteLine("6 - Очистити колекцію");
        Console.WriteLine("0 - Вийти");
        Console.Write("Ваш вибір: ");
    }
}