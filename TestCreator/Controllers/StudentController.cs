using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;
using DataLibrary.Models;
using DataLibrary.DataAccess;
using System.Security.Claims;

namespace TestCreator.Controllers
{
    [Authorize(Roles ="Student")]
    public class StudentController : Controller
    {
        public IActionResult Dashboard()
        {
            SqlDataAccess data = new SqlDataAccess();
            
            ClaimsPrincipal currentUser = this.User;
            string currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            List<ClassModel> myClasses = data.GetStudentClassList(currentUserId);
            List<ClassModel> allClasses = data.GetAllClassesList();

            ViewData["allClasses"] = allClasses;
            ViewData["myClasses"] = myClasses;

            return View();
        }

        [HttpGet]
        public IActionResult ClassView(int classID)
        {
            SqlDataAccess data = new SqlDataAccess();
            List<ExamModel> classExams = data.GetTestByClassId(classID);

            string className = data.GetClassroomById(classID).className;

            ViewData["classExams"] = classExams;
            ViewData["className"] = className;
            ViewData["classID"] = classID;

            return View();
        }

        [HttpGet]
        public IActionResult TakeExam(int examID)
        {
            SqlDataAccess data = new SqlDataAccess();
            ExamModel exam = data.GetExamById(examID);

            ViewData["exam"] = exam;

            return View();
        }
        public IActionResult AddClassAJAX(int classID)
        {
            SqlDataAccess data = new SqlDataAccess();

            ClaimsPrincipal currentUser = this.User;
            string currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            data.AddStudentToClass(currentUserId, classID);

            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        public IActionResult SubmitExam(int nClassID)
        {
            return RedirectToAction("ClassView", new { classID = nClassID } );
        }
    }
}