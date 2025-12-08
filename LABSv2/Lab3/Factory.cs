using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3
{
    public class Factory
    {
        public President President { get; set; }
        public List<Manager> Managers { get; set; }
        public List<Worker> Workers { get; set; }

        public Factory()
        {
            (President president, List<Manager> managers, List<Worker> workers) personnal =
                PersonsGenerator.CreateEnterprisePersonnel(5, 50);
            President = personnal.president;
            Managers = personnal.managers;
            Workers = personnal.workers;
        }

        public int WorkerCount() => Workers.Count;

        public double TotalSalary()
        {
            double total = President.Salary;
            total += Managers.Sum(m => m.Salary);
            total += Workers.Sum(w => w.Salary);
            return total;
        }

        public Worker YoungestWithHigherEducationFromTop10()
        {
            List<Worker> top10ByExperience = Workers.OrderByDescending(w => w.ExperienceDays).Take(10).ToList();
            return top10ByExperience.Where(w => w.HasHigherEducation).OrderBy(w => w.Age).First();
        }

        public (Manager youngest, Manager oldest) YoungestAndOldestManagers()
        {
            var youngest = Managers.OrderBy(m => m.Age).First();
            var oldest = Managers.OrderByDescending(m => m.Age).First();
            return (youngest, oldest);
        }

        public List<Person> OctoberBornEmployees()
        {
            List<Person> result = new List<Person>();
            if (President.BirthDate.Month == 10) result.Add(President);
            result.AddRange(Managers.Where(m => m.BirthDate.Month == 10));
            result.AddRange(Workers.Where(w => w.BirthDate.Month == 10));
            return result;
        }

        public List<Person> AllVladimirs()
        {
            var vladimirs = new List<Person>();
            if (President.FirstName == "Володимир") vladimirs.Add(President);
            vladimirs.AddRange(Managers.Where(m => m.FirstName == "Володимир"));
            vladimirs.AddRange(Workers.Where(w => w.FirstName == "Володимир"));
            return vladimirs;
        }

        public Person YoungestVladimirWithBonus()
        {
            List<Person> vladimirs = AllVladimirs();
            Person youngest = vladimirs.OrderBy(v => v.Age).First();
            double bonus = youngest.Salary / 3;
            return youngest;
        }
    }
}