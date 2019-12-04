using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace DataLibrary.Models
{
    public class ClassModel
    {
        public int classID { get; set; }

        [Display(Name ="Class Name")]
        [DataType(DataType.Text)]
        public string className { get; set; }
        [Display(Name ="Class Subject")]
        [DataType(DataType.Text)]
        public string classSubject { get; set; }

        public string instructorId { get; set; }
        public List<ExamModel> tests { get; set; }
    }
    public class StudentModel
    {
        public int studentID { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public List<ClassModel> classes { get; set; }
        public List<TestScoreModel> scores { get; set; }
    }
    public class TestScoreModel
    {
        public int scoreID { get; set; }
        public double scorePercentage { get; set; }
        public int numberCorrect { get; set; }
        public ExamModel test { get; set; }
    }
}
