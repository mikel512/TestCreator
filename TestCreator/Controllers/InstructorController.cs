using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TestCreator.Models;
using DataLibrary.DataAccess;
using DataLibrary.Models;
using System.Security.Claims;

namespace TestCreator.Controllers
{
    [Authorize(Roles = "Instructor")]
    public class InstructorController : Controller
    {
        public IActionResult Index()
        {
            ClaimsPrincipal currentUser = this.User;
            string currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            var access = new SqlDataAccess();
            var classes = access.GetInstructorClassrooms(currentUserId);

            ViewData["ClassList"] = classes;
            return View();
        }

        public IActionResult user_test_creator()
        {
            return View();
        }

        public IActionResult CreateClass()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ExamCreation()
        {
            var access = new SqlDataAccess();
            //var classroom = access.GetClassroomById(classId);
            //ViewData["ClassData"] = classroom;
            ViewData["TestData"] = new ExamModel();
            return View();
        }
        [HttpGet("{examId:int}")]
        public IActionResult ExamCreation(int examId)
        {
            var access = new SqlDataAccess();
            var exam = access.GetExamById(examId);
            exam.questions = access.GetTestQuestionList(examId);
            // Get answers for questions that have multiple choice
            foreach(var item in exam.questions)
            {
                if(item.isLongAnswer == false)
                {
                    item.multipleAnswers = access.GetQuestionAnswersList(item.questionID);
                }
            }

            ViewData["ExamGetModel"] = exam;
            ViewData["QuestionInputModel"] = new QuestionModel();
            return View();
        }

        public IActionResult ClassTests(int classId, string className)
        {
            var access = new SqlDataAccess();
            var exams = access.GetTestByClassId(classId);

            ViewData["ExamList"] = exams;
            ViewData["Title"] = "Tests for" + className;
            return View();
        }


        #region Post Actions
        [HttpPost]
        public IActionResult CreateClassAJAX(ClassModel classModel)
        {
            ClaimsPrincipal currentUser = this.User;
            string currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var access = new SqlDataAccess();
            if (ModelState.IsValid)
            {
                access.CreateClass(classModel.className, classModel.classSubject, currentUserId);
                return RedirectToAction("Index");
            }
            return View("Index");
        }
        [HttpPost]
        public IActionResult CreateExamAJAX(ExamModel examModel)
        {
            var access = new SqlDataAccess();
            if (ModelState.IsValid)
            {
                access.CreateTest(examModel.testTitle, examModel.classID);
                return RedirectToAction("ExamCreation");
            }
            return View();
        }
        [HttpPost]
        public IActionResult CreateQuestionAnswerAJAX(QuestionModel questionModel)
        {
            var access = new SqlDataAccess();
            if (ModelState.IsValid)
            {
                access.CreateQuestion(
                    questionModel.questionContent, 
                    (questionModel.QuestionType == "Multiple")? false : true,
                    questionModel.testID);
                return RedirectToAction("ExamCreation", new { examId = questionModel.testID });
            }
            return View("Index");

        }
        [HttpPost]
        public IActionResult CreateNewExam(string examName, int classId)
        {
            var access = new SqlDataAccess();
            access.CreateTest(examName, classId);
            var classroom = access.GetClassroomById(classId);
            
            return Json(classroom);
        }

        #endregion
    }
}