using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Data_Processing
{
    class Program
    {

        static List<Student> GetStudentsFromInput() {
            List<Student> students = new List<Student>();

            while (true)
            {
                int i = 1;
                Student student = new Student();

                try {
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
                } catch(Exception ex){
                    Console.WriteLine(ex.Message);
                }
                }
       
            return students;
        }
        static List<Student> GetStudentsFromFile() {
            List<Student> students = new List<Student>();
            string path = @"C:\Users\mark\Documents\VGTU files\IDE\Student Data Processing\students.txt";
            

            try
            {
                string[] lines = File.ReadAllLines(path);
                for (int i = 0; i < lines.Length; i++)
                {
                    Student student = new Student();
                    string[] parameters = lines[i].Split(' ');
                    student.SetSurname(parameters[0]);
                    student.SetName(parameters[1]);
                    int lastIndex = parameters.Length - 1;
                    student.SetExamResult(int.Parse(parameters[lastIndex]));
                    for (int j = 2; j < parameters.Length - 1; j++)
                    {
                        student.AddHomeworkResult(int.Parse(parameters[j]));
                    }

                    students.Add(student);
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

                students.OrderBy(stud => stud.GetName());
                return students;
        }
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();


            while (true) {
                Console.WriteLine("1. read from input");
                Console.WriteLine("2. read from file");
                Console.WriteLine("3. display data (average)");
                Console.WriteLine("4. display data (median)");
                Console.WriteLine("5. close");
                int menuItem = int.Parse(Console.ReadLine());
                if (menuItem == 1)
                {
                    List<Student> newStudents = GetStudentsFromInput();
                    students.AddRange(newStudents);
                }
                else if (menuItem == 2)
                {
                    List<Student> newStudents = GetStudentsFromFile();
                    students.AddRange(newStudents);
                    Console.WriteLine("data loaded!");
                }
                else if (menuItem == 3)
                {
                    Console.WriteLine("{0,-10} {1,-10} {2,20}", "Surname", "Name", "Final Points (Avg.)");
                    Console.WriteLine("-------------------------------------------------------------");
                    foreach (Student student in students)
                    {
                        Console.WriteLine("{0,-10} {1,-10} {2:0.00}", student.GetSurname(), student.GetName(), student.CalculateFinalPointsAverage());
                    }
                }
                else if (menuItem == 4)
                {
                    Console.WriteLine("{0,-10} {1,-10} {2,20}", "Surname", "Name", "Final Points (Med.)");
                    Console.WriteLine("-------------------------------------------------------------");
                    foreach (Student student in students)
                    {
                        Console.WriteLine("{0,-10} {1,-10} {2:0.00}", student.GetSurname(), student.GetName(), student.CalculateFinalPointsMedian());
                    }
                }
                else if (menuItem == 5) {
                    Console.WriteLine("program terminated!");
                    Console.ReadKey();
                    break;
                }
            } 
        }
    }
}
