namespace Lab1;
using System;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

public class StudentSerializer
{
    public void SerializeToXml(Student[] students, string filePath)
    {
        try
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Student[]));
            
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, students);
                Console.WriteLine("XML серіалізація виконана: " + filePath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка XML серіалізації: " + ex.Message);
        }
    }

    public Student[] DeserializeFromXml(string filePath)
    {
        try
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Student[]));
            
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                return (Student[])xmlSerializer.Deserialize(fs);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка XML десеріалізації: " + ex.Message);
            return new Student[0];
        }
    }

    public void SerializeToJson(Student[] students, string filePath)
    {
        try
        {
            string jsonString = JsonSerializer.Serialize(students, new JsonSerializerOptions 
            { 
                WriteIndented = true 
            });
            File.WriteAllText(filePath, jsonString);
            Console.WriteLine("JSON серіалізація виконана: " + filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка JSON серіалізації: " + ex.Message);
        }
    }

    public Student[] DeserializeFromJson(string filePath)
    {
        try
        {
            string jsonFromFile = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<Student[]>(jsonFromFile) ?? new Student[0];
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка JSON десеріалізації: " + ex.Message);
            return new Student[0];
        }
    }
}