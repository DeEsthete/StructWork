using Task1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Task2;

namespace StructLessonWork
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task 1
            Associate[] associate = new Associate[0];

            bool switchForWhile = true;
            int h = 0;
            while (switchForWhile)
            {
                Console.WriteLine("1 - Вывести полную информацию обо всех сотрудниках.");
                Console.WriteLine("2 - Найти в массиве всех менеджеров, зарплата которых больше средней зарплаты всех клерков, вывести на экран полную информацию о таких менеджерах отсортированной по их фамилии");
                Console.WriteLine("3 - Распечатать информацию обо всех сотрудниках, принятых на работу позже босса, отсортированную в алфавитном порядке по фамилии сотрудника.");
                Console.WriteLine("4 - Заполнить массив сотрудниками.");
                Console.WriteLine("0 - Выход");
                h = int.Parse(Console.ReadLine());
                switch (h)
                {
                    case 1: TaskOneShow(associate); break;
                    case 2: TaskOneSearchSalary(associate); break;
                    case 3: TaskOneSearchTime(associate); break;
                    case 4: associate = TaskOneFilling(associate); break;
                    case 0: switchForWhile = false; break;
                }
            }
            #endregion
            Console.ReadLine();
            #region Task 2
            const int MRP = 21700;
            const int SIZEARRAY = 5;
            Student[] students = new Student[SIZEARRAY];
            students[0] = new Student("Leha", "Popov", "Ivanovich", "ППТ-12", 4, 30000, Gender.male, FormOfTraining.fullTime);
            students[1] = new Student("Ekaterina", "Anohina", "Ivanovna", "ППТ-11", 4.3, 45000, Gender.female, FormOfTraining.fullTime);
            students[2] = new Student("Alexander", "Simov", "Sergeevich", "ЭТП-13", 3.3, 41000, Gender.male, FormOfTraining.extramural);
            students[3] = new Student("Elena", "Romanova", "Stepanovich", "КТП-10", 4.9, 10000, Gender.female, FormOfTraining.fullTime);
            students[4] = new Student("Fedor", "Fedorov", "Fedorovich", "ЛТП-9", 2.9, 12500, Gender.male, FormOfTraining.fullTime);

            int k = 0;
            Student[] FinalStudents = new Student[SIZEARRAY];
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].MidleSalary < (MRP*2))
                {
                    FinalStudents[k] = students[i];
                    k++;
                    students[i].IsCreation = true;
                }
            }
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].IsCreation == false)
                {
                    FinalStudents[k] = students[i];
                    k++;
                }
            }
            for (int i = 0; i < FinalStudents.Length; i++)
            {
                Console.WriteLine("*****************************");
                Console.WriteLine("Имя - " + FinalStudents[i].Name);
                Console.WriteLine("Фамилия - " + FinalStudents[i].LastName);
                Console.WriteLine("Отчество - " + FinalStudents[i].Patronymic);
                Console.WriteLine("Группа - " + FinalStudents[i].Group);
                Console.WriteLine("Средний бал - " + FinalStudents[i].MidleScore);
                Console.WriteLine("Средний доход - " + FinalStudents[i].MidleSalary);
                Console.WriteLine("Пол - " + FinalStudents[i].Gender);
                Console.WriteLine("Форма обучения - " + FinalStudents[i].FormOfTraining);
            }

            #endregion
            Console.ReadLine();
        }
        #region Task 1 Method
        static void TaskOneShow(Associate[] associate)
        {
            for (int i = 0; i < associate.Length; i++)
            {
                Console.WriteLine("Имя - " + associate[i].Name);
                Console.WriteLine("Фамилия - " + associate[i].LastName);
                Console.WriteLine("Должность - " + associate[i].Position);
                Console.WriteLine("Зарплата - " + associate[i].Salary);
                Console.WriteLine("Дата приема на работу - " + associate[i].EmploymentDate);
                Console.WriteLine("****************************");
            }
        }

        static void TaskOneSearchSalary(Associate[] associate)
        {
            int midleSalary = 0;
            int countKlerk = 0;
            for (int i = 0; i < associate.Length; i++)
            {
                if (associate[i].Position == Position.klerk)
                {
                    midleSalary = midleSalary + associate[i].Salary;
                    countKlerk++;
                }
            }
            midleSalary = midleSalary / countKlerk;
            for (int i = 0; i < associate.Length; i++)
            {
                if (associate[i].Position == Position.manager)
                {
                    if (associate[i].Salary > midleSalary)
                    {
                        Console.WriteLine("Имя - " + associate[i].Name);
                        Console.WriteLine("Фамилия - " + associate[i].LastName);
                        Console.WriteLine("Должность - " + associate[i].Position);
                        Console.WriteLine("Зарплата - " + associate[i].Salary);
                        Console.WriteLine("Дата приема на работу - " + associate[i].EmploymentDate);
                        Console.WriteLine("****************************");
                    }
                }
            }
        }

        static void TaskOneSearchTime(Associate[] associate)
        {
            Associate boss = null;
            for (int i = 0; i < associate.Length; i++)
            {
                if (associate[i].Position == Position.boss)
                {
                    boss = associate[i];
                }
            }
            for (int i = 0; i < associate.Length; i++)
            {
                if (associate[i].EmploymentDate.Year >= boss.EmploymentDate.Year)
                {
                    if (associate[i].EmploymentDate.Month >= boss.EmploymentDate.Month)
                    {
                        if (associate[i].EmploymentDate.Day > boss.EmploymentDate.Day)
                        {
                            Console.WriteLine("Имя - " + associate[i].Name);
                            Console.WriteLine("Фамилия - " + associate[i].LastName);
                            Console.WriteLine("Должность - " + associate[i].Position);
                            Console.WriteLine("Зарплата - " + associate[i].Salary);
                            Console.WriteLine("Дата приема на работу - " + associate[i].EmploymentDate);
                            Console.WriteLine("****************************");
                        }
                    }
                }
            }
        }

        static Associate[] TaskOneFilling(Associate[] associate)
        {
            int oldSize = associate.Length;
            int newSize = associate.Length;
            int choice;
            Console.WriteLine("Введите новый размер массива. (Внимание! Вся предыдущая информация содержащееся в массиве не сохранится)");
            newSize = int.Parse(Console.ReadLine());
            Array.Resize(ref associate, newSize);
            //associate = new Associate[newSize];
            for (int i = oldSize; i < newSize; i++)
            {
                Console.WriteLine("Введите имя сотрудника.");
                string tmpName = Console.ReadLine();

                Console.WriteLine("Введите фамилию сотрудника.");
                string tmpLastName = Console.ReadLine();

                Console.WriteLine("Введите должность сотрудника.");
                Console.WriteLine("0 - Босс");
                Console.WriteLine("1 - Менеджер");
                Console.WriteLine("2 - Клерк");
                Console.WriteLine("3 - Уборщик");
                choice = int.Parse(Console.ReadLine());
                Position tmpPosition = (Position)choice;

                Console.WriteLine("Введите зарплату нового сотрудника.");
                choice = int.Parse(Console.ReadLine());
                int tmpSalary = choice;
                
                Console.WriteLine("Введите дату приема на работу. (DD, MM, YY)");
                Console.Write("DD - ");
                int tmpDD = int.Parse(Console.ReadLine());
                Console.Write("MM - ");
                int tmpMM = int.Parse(Console.ReadLine());
                Console.Write("YY - ");
                int tmpYY = int.Parse(Console.ReadLine());

                Associate tmp = new Associate(tmpName, tmpLastName, tmpPosition, tmpSalary, tmpDD, tmpMM, tmpYY);
                associate[i] = tmp;
            }
            return associate;
        }
        #endregion
    }
}
