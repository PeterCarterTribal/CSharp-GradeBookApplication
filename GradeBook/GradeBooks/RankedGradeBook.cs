using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            int numStudents = Students.Count;

            if (numStudents < 5)
                throw new InvalidOperationException("Ranked grading requires a minimum of 5 students to work");

            int twentyPercentInterval = (int)(numStudents * 0.2);

            int betterStudents = Students.Count(s => s.AverageGrade > averageGrade);

            char[] gradeLetters = new char[] {'A', 'B', 'C', 'D', 'F'};

            int index = betterStudents / twentyPercentInterval;

            return gradeLetters[index];

        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculated a student's overall grade.");
                return;
            }
                base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculated a student's overall grade.");
                return;
            }
                base.CalculateStudentStatistics(name);
        }
    }
}
