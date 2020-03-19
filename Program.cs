using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Data_Processing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            while (true) {
                int i = 1;
                Student student = new Student();

                Console.WriteLine("Write Student name:");
                student.SetName(Console.ReadLine());

                Console.WriteLine("Write Student surname:");
                student.SetSurname(Console.ReadLine());

                Console.WriteLine("Write Student exam result:");
                student.SetExamResult(int.Parse(Console.ReadLine()));

                while (true)
                {
                    Console.WriteLine("Write Student result for homework {0}:", i);
                    student.AddHomeworkResult(int.Parse(Console.ReadLine()));
                    
                    Console.WriteLine("more grades? y/n \n");
                    char ch1 = Console.ReadKey().KeyChar;
                    if (ch1 == 'n')
                    {
                        break;
                    }
                    else
                    {
                        i++;
                        Console.WriteLine();
                    }
                }

                Console.WriteLine();
                students.Add(student);
                Console.WriteLine("more students? y/n \n");
                char ch2 = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (ch2 == 'n')
                {
                    break;
                }
            }

            Console.WriteLine("choose calculation mode \n 1-avaerage, 2-median");
            int mode = int.Parse(Console.ReadLine());

            
            if (mode == 1) {
                Console.WriteLine("{0,-10} {1,-10} {2,20}", "Surname", "Name", "Final Points (Avg.)");
                Console.WriteLine("-------------------------------------------------------------");
                foreach (Student student in students)
                {
                    Console.WriteLine("{0,-10} {1,-10} {2:0.00}", student.GetSurname(), student.GetName(), student.CalculateFinalPointsAverage());
                }
            }
            if (mode == 2) {
                Console.WriteLine("{0,-10} {1,-10} {2,20}", "Surname", "Name", "Final Points (Med.)");
                Console.WriteLine("-------------------------------------------------------------");
                foreach (Student student in students)
                {
                    Console.WriteLine("{0,-10} {1,-10} {2:0.00}", student.GetSurname(), student.GetName(), student.CalculateFinalPointsMedian());
                }
            }

            Console.ReadKey();
            
            
        }
    }
}
