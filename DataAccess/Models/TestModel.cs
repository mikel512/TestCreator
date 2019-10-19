using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    class Answer
    {
        
        public int answerID { get; set; }
        public bool isLongAnswer { get; set; }
        public string answerContent { get; set; }
    }
    class Question
    {
        public int questionID { get; set; }
        public string questionContent { get; set; }
        public bool isLongAnswer { get; set; }
        public List<Answer> answers { get; set; }
    }
    class Test
    {
        public int testID { get; set; }
        public string testTitle { get; set; }
        public List<Question> questions { get; set; }
    }
}
