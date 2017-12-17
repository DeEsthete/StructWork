using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Student
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Group { get; set; }
        public double MidleScore { get; set; }
        public int MidleSalary { get; set; }
        public Gender Gender { get; set; }
        public FormOfTraining FormOfTraining { get; set; }
        public bool IsCreation { get; set; }

        public Student(string name, string lastName, string patronymic, string group, double midleScore, int midleSalary, Gender gender, FormOfTraining formOfTraining)
        {
            Name = name;
            LastName = lastName;
            Patronymic = patronymic;
            Group = group;
            MidleScore = midleScore;
            MidleSalary = midleSalary;
            Gender = gender;
            FormOfTraining = formOfTraining;
            IsCreation = false;
        }
    }
}
