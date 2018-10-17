using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
   public class GradeBook
    {
        List<float> grades;

		private string _name;
        public String Name
		{
			get
			{
				return _name;
			}
			set
			{
				if (!String.IsNullOrEmpty(value))
				{
					if (_name != value)
					{
						NameChangedEventArgs args = new NameChangedEventArgs();
						args.ExistingName = Name;
						args.NewName = value;
						NameChanged(this, args);
					}
					_name = value;
				}
			}
		}

		public event NameChangedDelegate NameChanged;
        public GradeBook()
        {
            grades = new List<float>();
			_name = "Empty";
        }
        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new Grades.GradeStatistics();
            stats.HighestGrade = 0;
            float sum = 0;
            foreach(float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / grades.Count;
            return stats;
        }
        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }
    }
}
