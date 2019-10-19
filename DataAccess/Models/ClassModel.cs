using System;
using System.Collections.Generic;
using System.Text;


namespace DataLibrary.Models
{
    class Class
    {
        public int classID { get; set; }
        public string className { get; set; }
        public string classSubject { get; set; }
        public List<Test> tests { get; set; }
    }
    class Student
    {
        public string fName { get; set; }
        public string lName { get; set; }
        public List<Class> classes { get; set; }
        public List<TestScore> scores { get; set; }
    }
    class TestScore
    {
        public int scoreID { get; set; }
        public double scorePercentage { get; set; }
        public int numberCorrect { get; set; }
        public Test test { get; set; }
    }
}
