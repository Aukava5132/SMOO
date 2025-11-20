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
                Console.WriteLine($"XML serialisation successful: {filePath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"XML err serialisation: {ex.Message}");
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
            Console.WriteLine($"XML err deserialisation: {ex.Message}");
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
            Console.WriteLine($"JSON serialisation successful: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"JSON err deserialisation: {ex.Message}");
        }
    }

    public Student[] DeserializeFromJson(string filePath)
    {
        try
        {
            string jsonFromFile = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<Student[]>(jsonFromFile);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"JSON err deserialisation: {ex.Message}");
            return new Student[0];
        }
    }
}