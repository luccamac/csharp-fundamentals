﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        private GradeBook book;
        static void Main(string[] args)
        {
            GradeTracker book = CreateGradeBook();
            CreatingFile(book);
            AddingGrades(book);
            WritingFile(book);
            PrintingResults(book);
        }

        private static GradeTracker CreateGradeBook()
        {
            return new ThrowAwayGradeBook();
        }

        private static void PrintingResults(GradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", (int)stats.HighestGrade);
            WriteResult("Lowest", (int)stats.LowestGrade);
            WriteResult(stats.Description, stats.LetterGrade);
        }

        private static void WritingFile(GradeTracker book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
            }
        }

        private static void AddingGrades(GradeTracker book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        private static void CreatingFile(GradeTracker book)
        {
            try
            {
                Console.WriteLine("Enter a Name:");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Something went wrong!");
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong!");
            }
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{description} : {result}");
        }

		static void WriteResult(string description, string result)
		{
			Console.WriteLine($"{description} : {result}");
		}
	}
}
