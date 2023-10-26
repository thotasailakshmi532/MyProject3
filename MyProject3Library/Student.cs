using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace MyProject3Library
{
    public class Student : IComparer<Student>
    {
        public string Sname { get; set; }
        public string ClassName { get; set; }

        public int Compare(Student x, Student y)
        {
            Student s1 = x as Student;
            Student s2 = y as Student;
            return s1.Sname.CompareTo(s2.Sname);
        }
    }



}
