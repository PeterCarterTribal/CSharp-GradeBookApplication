using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            int numStudents = Students.Count;

            if (numStudents < 5)
                throw new InvalidOperationException("Ranked grading requires a minimum of 5 students to work");

            int twentyPercentInterval = (int)(numStudents * 0.2);

            var betterStudents = Students.Count(s => s.AverageGrade > averageGrade);

            int i = 1;
            char[] passLetters = new char[] {'A', 'B', 'C', 'D', 'F'};

            var index = betterStudents / twentyPercentInterval;

            return passLetters[index];

        }
    }
}
