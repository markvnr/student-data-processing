using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;


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
        static List<Student> GetStudentsFromFile(string fileName){
            List<Student> students = new List<Student>();
            string path = @"C:\Users\mark\Documents\VGTU files\IDE\Student Data Processing\" + fileName;
            

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
        static List<Student> GenerateListStudents(int size)
        {
            List<Student> students = new List<Student>();
            Random rand = new Random();
            for (int i = 1; i <= size; i++) {
                Student stud = new Student();
                stud.SetName("name" + i);
                stud.SetSurname("surname" + i);
                stud.SetExamResult(rand.Next(1, 10));
                for (int j = 0; j < 5; j++) {
                    stud.AddHomeworkResult(rand.Next(1,10));
                }
                students.Add(stud);
            }

            return students;
        }
        static LinkedList<Student> GenerateLinkedListStudents(int size) {
            LinkedList<Student> students = new LinkedList<Student>();
            Random rand = new Random();
            for (int i = 1; i <= size; i++)
            {
                Student stud = new Student();
                stud.SetName("name" + i);
                stud.SetSurname("surname" + i);
                stud.SetExamResult(rand.Next(1, 10));
                for (int j = 0; j < 5; j++)
                {
                    stud.AddHomeworkResult(rand.Next(1, 10));
                }
                students.AddLast(stud);
            }

            return students;
        }
        static Queue<Student> GenerateQueueStudents(int size) {
            Queue<Student> students = new Queue<Student>();
            Random rand = new Random();
            for (int i = 1; i <= size; i++)
            {
                Student stud = new Student();
                stud.SetName("name" + i);
                stud.SetSurname("surname" + i);
                stud.SetExamResult(rand.Next(1, 10));
                for (int j = 0; j < 5; j++)
                {
                    stud.AddHomeworkResult(rand.Next(1, 10));
                }
                students.Enqueue(stud);
            }

            return students;
        }
        static List<long> GenerateFilesWithList() {
            Stopwatch stopwatch = new Stopwatch();
            List<long> elapsedTime = new List<long>();

            for (int size = 10000; size <= 10000000; size *= 10) {
                stopwatch.Start();
                List<Student> studentz = GenerateListStudents(size);
                string path1 = @"C:\Users\mark\Documents\VGTU files\IDE\Student Data Processing\" + "students" + size + ".txt";
                studentz.ForEach(stud => Console.WriteLine("{0,-10} {1,-10} {2:0.00}", stud.GetSurname(), stud.GetName(), stud.CalculateFinalPointsAverage()));
                List<Student> failed = studentz.Where(stud => stud.CalculateFinalPointsAverage() < 5.0).ToList();
                List<Student> passed = studentz.Where(stud => stud.CalculateFinalPointsAverage() >= 5.0).ToList();
                using (StreamWriter sw = new StreamWriter(path1, false))
                {
                    studentz.ForEach(stud => sw.WriteLine(String.Format("{0,-10} {1,-10} {2:0.00}", stud.GetSurname(), stud.GetName(), stud.CalculateFinalPointsAverage())));
                    sw.Flush();
                }

                string path2 = @"C:\Users\mark\Documents\VGTU files\IDE\Student Data Processing\" + "students" + size + "passed.txt";
                using (StreamWriter sw = new StreamWriter(path2, false))
                {
                    passed.ForEach(stud => sw.WriteLine(String.Format("{0,-10} {1,-10} {2:0.00}", stud.GetSurname(), stud.GetName(), stud.CalculateFinalPointsAverage())));
                    sw.Flush();
                }

                string path3 = @"C:\Users\mark\Documents\VGTU files\IDE\Student Data Processing\" + "students" + size + "failed.txt";
                using (StreamWriter sw = new StreamWriter(path3, false))
                {
                    failed.ForEach(stud => sw.WriteLine(String.Format("{0,-10} {1,-10} {2:0.00}", stud.GetSurname(), stud.GetName(), stud.CalculateFinalPointsAverage())));
                    sw.Flush();
                }
                stopwatch.Stop();
                elapsedTime.Add(stopwatch.ElapsedMilliseconds);
            }

            return elapsedTime;
            
        }
        static List<long> GenerateFilesWithLinkedList() {
            Stopwatch stopwatch = new Stopwatch();
            List<long> elapsedTime = new List<long>();
            for (int size = 10000; size <= 10000000; size *= 10)
            {
                stopwatch.Start();
                LinkedList<Student> studentz = GenerateLinkedListStudents(size);
                string path1 = @"C:\Users\mark\Documents\VGTU files\IDE\Student Data Processing\" + "students" + size + ".txt";
                string path2 = @"C:\Users\mark\Documents\VGTU files\IDE\Student Data Processing\" + "students" + size + "passed.txt";
                string path3 = @"C:\Users\mark\Documents\VGTU files\IDE\Student Data Processing\" + "students" + size + "failed.txt";

                foreach (Student stud in studentz) {
                    Console.WriteLine("{0,-10} {1,-10} {2:0.00}", stud.GetSurname(), stud.GetName(), stud.CalculateFinalPointsAverage());
                }


                LinkedList<Student> failed = new LinkedList<Student>();
                LinkedList<Student> passed = new LinkedList<Student>();

                foreach (Student stud in studentz) {
                    if (stud.CalculateFinalPointsAverage() < 5.0)
                    {
                        failed.AddLast(stud);
                    }
                    else {
                        passed.AddLast(stud);
                    }
                }

                
                using (StreamWriter sw = new StreamWriter(path1, false))
                {
                    foreach (Student stud in studentz)
                    {
                        sw.WriteLine(String.Format("{0,-10} {1,-10} {2:0.00}", stud.GetSurname(), stud.GetName(), stud.CalculateFinalPointsAverage()));
                        sw.Flush();
                    }
                    
                }

                using (StreamWriter sw = new StreamWriter(path2, false))
                {
                    foreach (Student stud in passed)
                    {
                        sw.WriteLine(String.Format("{0,-10} {1,-10} {2:0.00}", stud.GetSurname(), stud.GetName(), stud.CalculateFinalPointsAverage()));
                        sw.Flush();
                    }

                }

                using (StreamWriter sw = new StreamWriter(path3, false))
                {
                    foreach (Student stud in failed)
                    {
                        sw.WriteLine(String.Format("{0,-10} {1,-10} {2:0.00}", stud.GetSurname(), stud.GetName(), stud.CalculateFinalPointsAverage()));
                        sw.Flush();
                    }

                }

                stopwatch.Stop();
                elapsedTime.Add(stopwatch.ElapsedMilliseconds);
            }
            return elapsedTime; 
        }
        static List<long> GenerateFilesWithQueue() {
            Stopwatch stopwatch = new Stopwatch();
            List<long> elapsedTime = new List<long>();
            for (int size = 10000; size <= 10000000; size *= 10)
            {
                stopwatch.Start();
                Queue<Student> studentz = GenerateQueueStudents(size);
                string path1 = @"C:\Users\mark\Documents\VGTU files\IDE\Student Data Processing\" + "students" + size + ".txt";
                string path2 = @"C:\Users\mark\Documents\VGTU files\IDE\Student Data Processing\" + "students" + size + "passed.txt";
                string path3 = @"C:\Users\mark\Documents\VGTU files\IDE\Student Data Processing\" + "students" + size + "failed.txt";

                foreach (Student stud in studentz)
                {
                    Console.WriteLine("{0,-10} {1,-10} {2:0.00}", stud.GetSurname(), stud.GetName(), stud.CalculateFinalPointsAverage());
                }


                Queue<Student> failed = new Queue<Student>();
                Queue<Student> passed = new Queue<Student>();

                foreach (Student stud in studentz)
                {
                    if (stud.CalculateFinalPointsAverage() < 5.0)
                    {
                        failed.Enqueue(stud);
                    }
                    else
                    {
                        passed.Enqueue(stud);
                    }
                }


                using (StreamWriter sw = new StreamWriter(path1, false))
                {
                    foreach (Student stud in studentz)
                    {
                        sw.WriteLine(String.Format("{0,-10} {1,-10} {2:0.00}", stud.GetSurname(), stud.GetName(), stud.CalculateFinalPointsAverage()));
                        sw.Flush();
                    }

                }

                using (StreamWriter sw = new StreamWriter(path2, false))
                {
                    foreach (Student stud in passed)
                    {
                        sw.WriteLine(String.Format("{0,-10} {1,-10} {2:0.00}", stud.GetSurname(), stud.GetName(), stud.CalculateFinalPointsAverage()));
                        sw.Flush();
                    }

                }

                using (StreamWriter sw = new StreamWriter(path3, false))
                {
                    foreach (Student stud in failed)
                    {
                        sw.WriteLine(String.Format("{0,-10} {1,-10} {2:0.00}", stud.GetSurname(), stud.GetName(), stud.CalculateFinalPointsAverage()));
                        sw.Flush();
                    }

                }

                stopwatch.Stop();
                elapsedTime.Add(stopwatch.ElapsedMilliseconds);
            }
            return elapsedTime;
        }
        static void SplitStudentsList1(List<Student> students, List<Student> passed, List<Student> failed) {
            for (int i = 0; i < students.Count; i++) {
                if (students[i].CalculateFinalPointsAverage() < 5.0)
                {
                    failed.Add(students[i]);
                }
                else {
                    passed.Add(students[i]);
                }
            }
        }
        static void SplitStudentsList2(List<Student> students, List<Student> failed)
        {
            students.Sort((stud1,stud2) => (stud1.CalculateFinalPointsAverage()
                                                 .CompareTo(stud2.CalculateFinalPointsAverage())));
            int middle = students.FindIndex((Student stud) => stud.CalculateFinalPointsAverage() >= 5.0);
            for (int i=0;i<students.Count;i++)
            {
                if (students[i].CalculateFinalPointsAverage() < 5.0){ 
                    failed.Add(students[i]);
                    students.RemoveAt(i);
               }  
            }
            //students.RemoveRange(0,middle);
        }
        static void SplitStudentsLinkedList1(LinkedList<Student> students,LinkedList<Student> passed,LinkedList<Student> failed) {
            LinkedListNode<Student> current = students.First;
            while (current != null) {
                if (current.Value.CalculateFinalPointsAverage() < 5.0)
                {
                    failed.AddLast(current.Value);
                }
                else {
                    passed.AddLast(current.Value);
                }

                current = current.Next;
            }
        }
        static void SplitStudentsLinkedList2(LinkedList<Student> students, LinkedList<Student> failed) {
            LinkedListNode<Student> current = students.First;
            while (current != null) {
                LinkedListNode<Student> nextNode = current.Next;
                if (current.Value.CalculateFinalPointsAverage() < 5.0) {
                    failed.AddLast(current.Value);
                    students.Remove(current.Value);
                }
                current = nextNode;
            }
        }
        static void SplitStudentsQueue1(Queue<Student> students,Queue<Student> passed,Queue<Student> failed) {
            while (students.Count != 0) {
                Student stud = students.Dequeue();
                if (stud.CalculateFinalPointsAverage() < 5.0)
                {
                    failed.Enqueue(stud);
                }
                else {
                    passed.Enqueue(stud);
                }
            }
        }
        static void SplitStudentsQueue2(Queue<Student> students, Queue<Student> failed)
        {
            int count = students.Count;
            while (count>0)
            {
                Student stud = students.Dequeue();
                if (stud.CalculateFinalPointsAverage() < 5.0)
                {
                    failed.Enqueue(stud);
                }
                else {
                    students.Enqueue(stud);
                }

                count--;
            }
        }
        static void GenerateFile() {
            List<Student> students = GenerateListStudents(10000);
            string path = @"C:\Users\mark\Documents\VGTU files\IDE\Student Data Processing\file.txt";
            using (StreamWriter sw = new StreamWriter(path, false)) {
                students.ForEach((Student stud) => sw.WriteLine(stud.GetSurname() + " " + stud.GetName() + " " + string.Join(" ",stud.GetHomeworkResults()) + " " + stud.GetExamResult()));
                sw.Flush();
            }
        }

        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            while (true) {
                Console.WriteLine("1. read from input");
                Console.WriteLine("2. read from file");
                Console.WriteLine("3. display data (average)");
                Console.WriteLine("4. display data (median)");
                Console.WriteLine("5. generate student list");
                Console.WriteLine("6. split students");
                Console.WriteLine("7. close");
                int menuItem = int.Parse(Console.ReadLine());
                if (menuItem == 1)
                {
                    List<Student> newStudents = GetStudentsFromInput();
                    students.AddRange(newStudents);

                }
                else if (menuItem == 2)
                {
                    List<Student> newStudents = GetStudentsFromFile("students.txt");
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
                else if (menuItem == 5)
                {
                    List<long> elapsed = GenerateFilesWithList();
                   
                    for (int i = 0; i < elapsed.Count; i++)
                    {
                        Console.WriteLine("file {0} executed {1}", i + 1, elapsed[i]);

                    }
                }
                else if (menuItem == 6) {
                    List<Student> studentz = GetStudentsFromFile("file.txt");
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    List<Student> failed = new List<Student>();
                    List<Student> passed = new List<Student>();
                    SplitStudentsList1(studentz,passed,failed);
                    stopwatch.Stop();
                    Console.WriteLine("passed students: ");
                    foreach (Student stud in studentz)
                    {
                        Console.WriteLine(stud);
                    }
                    Console.WriteLine();
                    Console.WriteLine("failed students: ");
                    foreach (Student stud in failed)
                    {
                        Console.WriteLine(stud);
                    }
                    Console.WriteLine("Time Elapsed {0} ms", stopwatch.ElapsedMilliseconds);
                }
                else if (menuItem == 7)
                {
                    Console.WriteLine("program terminated!");
                    Console.ReadKey();
                    break;
                }
            } 
        }
    }
}
