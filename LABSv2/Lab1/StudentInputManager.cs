namespace Lab1;
using System;

public class StudentInputManager
{
    public void FillLibrary(StudentCollection collection)
    {
        Console.WriteLine("ОБЕРІТЬ СПОСІБ ЗАПОВНЕННЯ");
        Console.WriteLine("1 - Згенерувати випадкових студентів");
        Console.WriteLine("2 - Ввести студентів вручну");
        Console.Write("Ваш вибір: ");
        
        string choice = Console.ReadLine();
        
        switch (choice)
        {
            case "1":
                GenerateRandomStudents(collection);
                break;
            case "2":
                InputStudentsManually(collection);
                break;
            default:
                Console.WriteLine("Неправильний вибір. Генеруємо 5 випадкових студентів");
                StudentGenerator.GenerateRandomStudents(collection, 5);
                break;
        }
        
        Console.WriteLine("До бібліотеки додано " + collection.GetAllStudents().Length + " студентів");
    }

    private void GenerateRandomStudents(StudentCollection collection)
    {
        Console.Write("Скільки студентів згенерувати? ");
        string input = Console.ReadLine();
        
        if (!int.TryParse(input, out int count) || count <= 0 || count > 1000)
        {
            Console.WriteLine("Неправильна кількість. Використовується значення за замовчуванням: 5");
            count = 5;
        }
        
        StudentGenerator.GenerateRandomStudents(collection, count);
        Console.WriteLine("Згенеровано " + count + " студентів");
    }

    private void InputStudentsManually(StudentCollection collection)
    {
        Console.WriteLine("РУЧНИЙ ВВІД СТУДЕНТІВ");
        int studentCount = 0;
        
        while (true)
        {
            Console.WriteLine("Студент #" + (studentCount + 1));
            
            string fullName = InputFullName();
            if (fullName == null) break;
            
            string group = InputGroup();
            int[] grades = InputGrades();
            
            collection.AddStudent(new Student(fullName, group, grades));
            studentCount++;
            
            Console.WriteLine("Студента " + fullName + " додано успішно");
            
            if (!AskToContinue()) break;
        }
        
        Console.WriteLine("Додано " + studentCount + " студентів");
    }

    private string InputFullName()
    {
        while (true)
        {
            Console.Write("ПІБ (або 'exit' для виходу): ");
            string fullName = Console.ReadLine()?.Trim() ?? "";
            
            if (fullName.ToLower() == "exit")
                return null;
                
            if (string.IsNullOrWhiteSpace(fullName))
            {
                Console.WriteLine("ПІБ не може бути порожнім");
                continue;
            }
            
            return fullName;
        }
    }

    private string InputGroup()
    {
        while (true)
        {
            Console.Write("Група: ");
            string group = Console.ReadLine()?.Trim() ?? "";
            
            if (string.IsNullOrWhiteSpace(group))
            {
                Console.WriteLine("Група не може бути порожньою");
                continue;
            }
            
            return group;
        }
    }

    private int[] InputGrades()
    {
        Console.WriteLine("Введіть 5 оцінок через пробіл (числа від 0 до 10):");
        
        while (true)
        {
            Console.Write("Оцінки: ");
            string gradesInput = Console.ReadLine()?.Trim() ?? "";
            
            if (string.IsNullOrWhiteSpace(gradesInput))
            {
                Console.WriteLine("Необхідно ввести оцінки");
                continue;
            }
            
            int[] grades = ParseGrades(gradesInput);
            
            if (grades == null)
            {
                Console.WriteLine("Помилка у форматі оцінок. Спробуйте знову");
                continue;
            }
            
            bool allValid = true;
            for (int i = 0; i < grades.Length; i++)
            {
                if (grades[i] < 0 || grades[i] > 10)
                {
                    Console.WriteLine("Оцінка #" + (i + 1) + " (" + grades[i] + ") повинна бути від 0 до 10");
                    allValid = false;
                    break;
                }
            }
            
            if (allValid)
            {
                Console.WriteLine("Оцінки: " + string.Join(", ", grades));
                return grades;
            }
        }
    }

    private int[] ParseGrades(string gradesInput)
    {
        string[] gradeStrings = gradesInput.Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
        
        if (gradeStrings.Length != 5)
        {
            Console.WriteLine("Потрібно ввести рівно 5 оцінок. Ви ввели: " + gradeStrings.Length);
            return null;
        }
        
        int[] grades = new int[5];
        
        for (int i = 0; i < 5; i++)
        {
            if (!int.TryParse(gradeStrings[i], out int grade))
            {
                Console.WriteLine("Невірний формат оцінки: " + gradeStrings[i]);
                return null;
            }
            grades[i] = grade;
        }
        
        return grades;
    }

    private bool AskToContinue()
    {
        while (true)
        {
            Console.Write("Додати ще студента? (y/n): ");
            string continueInput = Console.ReadLine()?.Trim().ToLower() ?? "";
            
            if (continueInput == "y" || continueInput == "у" || continueInput == "yes" || continueInput == "так")
                return true;
                
            if (continueInput == "n" || continueInput == "н" || continueInput == "no" || continueInput == "ні")
                return false;
                
            Console.WriteLine("Будь ласка, введіть 'y' (так) або 'n' (ні)");
        }
    }
}