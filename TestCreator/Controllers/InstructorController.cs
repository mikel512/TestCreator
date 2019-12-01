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
            var access = new SqlDataAccess();
            ClaimsPrincipal currentUser = this.User;
            string currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
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
            ClaimsPrincipal currentUser = this.User;
            string currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (ModelState.IsValid)
            {
                access.CreateTest(examModel.testTitle, examModel.classID);
                return RedirectToAction("ExamCreation");
            }
            return View();
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