using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Data_Processing
{
    class Student
    {
        private string name;
        private string surname;
        private int examResult;
        private readonly List<int> homeworkResults;

        public Student(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
            this.examResult = -1;
            this.homeworkResults = new List<int>();
        }

        public Student()
        {
            this.examResult = -1;
            this.homeworkResults = new List<int>();
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetSurname(string surname)
        {
            this.surname = surname;
        }

        public void SetExamResult(int examResult)
        {
            this.examResult = examResult;
        }

        public string GetName()
        {
            return this.name;
        }

        public string GetSurname()
        {
            return this.surname;
        }

        public int GetExamResult()
        {
            return this.examResult;
        }

        public void AddHomeworkResult(int result)
        {
            this.homeworkResults.Add(result);
        }

        public double CalculateFinalPointsAverage()
        {
            int sum = 0;
            foreach (int value in this.homeworkResults)
            {
                sum += value;
            }

            double avg = (double)sum / this.homeworkResults.Count;
            return 0.7 * this.examResult + 0.3 * avg;
        }

        public double CalculateFinalPointsMedian() {
            List<int> copyHomeworkResults = new List<int>(this.homeworkResults);
            copyHomeworkResults.Sort();

            double median;
            if (copyHomeworkResults.Count % 2 == 1)
            {
                median = copyHomeworkResults[copyHomeworkResults.Count / 2];
            }
            else { 
                median = (copyHomeworkResults[copyHomeworkResults.Count / 2] + copyHomeworkResults[copyHomeworkResults.Count / 2 - 1]) / 2;
            }

            return 0.7 * this.examResult + 0.3 * median;
        }
    }
}
