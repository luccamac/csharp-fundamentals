using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Test
{
    [TestClass]
    public class TypeTests
    {

        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;
            grades = new float[3];

            AddGrades(grades);
            Assert.AreEqual(89.1f, grades[1]);
        }

        private void AddGrades(float[] grades)
        {
            grades[1] = 89.1f;
        }

        [TestMethod]
        public void valuesTypesPassByValue()
        {
            int x = 46;
            incrementNumber(x);
            Assert.AreEqual(46, x);
        }

        private void incrementNumber(int number)
        {
            number += number;
        }

        [TestMethod]
        public void referencesTypePassByValues()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;
            giveBookAName(book2);
            Assert.AreEqual("A GradeBook", book1.name);
        }

        private void giveBookAName(GradeBook book)
        {
            book.name = "A GradeBook";
        }

        [TestMethod]
        public void stringComparisons()
        {
            string name1 = "Scott";
            string name2 = "scott";
            bool result = String.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ComputesHighestGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(10);
            book.AddGrade(90);
            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(90, result.HighestGrade);
        }

        [TestMethod]
        public void ComputesLowestGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(10);
            book.AddGrade(90);
            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(10, result.LowestGrade);
        }

        [TestMethod]
        public void ComputesAverageGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(85.16, result.AverageGrade, 0.01);
        }

        [TestMethod]
        public void IntVariablesHoldAValue()
        {
            int x1 = 100;
            int x2 = x1;
            x1 = 4;
            Assert.AreNotEqual(x1, x2);
        }

    }
}
