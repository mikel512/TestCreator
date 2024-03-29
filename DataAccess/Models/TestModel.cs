﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataLibrary.Models
{
    public class AnswerModel
    {
        public int answerID { get; set; }
        public bool isLongAnswer { get; set; }

        [Required]
        [Display(Name ="Answer")]
        public string answerContent { get; set; }
    }
    public class QuestionModel
    {
        public int questionID { get; set; }
        public int testID { get; set; }

        [Required]
        [Display(Name ="Question content")]
        [DataType(DataType.Text)]
        public string questionContent { get; set; }

        [Display(Name ="Is long answer?")]
        public bool isLongAnswer { get; set; }

        [Display(Name = "Question type")]
        public string QuestionType { get; set; }

        public string answers { get; set; }

        public List<AnswerModel> multipleAnswers { get; set; }
    }
    public class ExamModel
    {
        public int testID { get; set; }
        public int classID { get; set; }

        [Required]
        [Display(Name ="Exam Title")]
        public string testTitle { get; set; }

        public List<QuestionModel> questions { get; set; }
    }
}
