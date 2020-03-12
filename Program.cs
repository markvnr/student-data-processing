using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentData
{
    class Program
    {

       public static void Main(string[] args)
        {
            int i = 1;
            List<Student> students = new List<Student>();
            Student student = new Student();

            Console.WriteLine("Write Student name:");
            student.SetName(Console.ReadLine());

            Console.WriteLine("Write Student surname:");
            student.SetSurname(Console.ReadLine());

            Console.WriteLine("Write Student exam result:");
            student.SetExamResult(int.Parse(Console.ReadLine()));

            while (true) {
                Console.WriteLine("Write Student result for homework {0}:",i);
                student.AddHomeworkResult(int.Parse(Console.ReadLine()));
                students.Add(student);
                Console.WriteLine("more grades? y/n \n");
                char ch = Console.ReadKey().KeyChar;
                if (ch == 'n')
                {
                    break;
                }
                else {
                    i++;
                    Console.WriteLine();
                }
            }

            Console.WriteLine();

            Console.WriteLine("{0,-10} {1,-10} {2,20}", "Name", "Surname","Final Points (Avg.)");
            Console.WriteLine("-------------------------------------------------------------");
            double result = 0.7 * student.GetExamResult() + 0.3 * student.CalculateFinalPointsAverage();
            Console.WriteLine("{0,-10} {1,-10} {2,20}",student.GetName(),student.GetSurname(),result);
            Console.ReadKey();


        }
    }
}
