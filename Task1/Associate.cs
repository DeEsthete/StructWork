using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Associate
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public Position Position { get; set; }
        public int Salary { get; set; }
        public DateTime EmploymentDate { get; set; }

        public Associate(string name, string lastName, Position position, int salary, int DD, int MM, int YY)
        {
            Name = name;
            LastName = lastName;
            Position = position;
            Salary = salary;
            DateTime tmpEmploymentDate = new DateTime(YY, MM, DD);
            EmploymentDate = tmpEmploymentDate;
        }
    }
}
