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
        [AllowAnonymous]
        public IActionResult Dashboard()
        {
            SqlDataAccess data = new SqlDataAccess();
            List<ClassModel> allClasses = data.GetAllClassesList();

            ViewData["allClasses"] = allClasses;

            return View();
        }

        // Shows the class tests for the student
        [AllowAnonymous]
        [HttpGet("{classId:int}")]
        public IActionResult ClassView(int classId)
        {
            ClaimsPrincipal currentUser = this.User;
            string currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var access = new SqlDataAccess();
            SqlDataAccess data = new SqlDataAccess();
            List<ExamModel> allExams = data.GetTestByClassId(classId);

            ViewData["allExams"] = allExams;

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult AddClassAJAX(int classID)
        {

            Debug.WriteLine("*** Added Class: " + classID.ToString());

            return View("Dashboard");
        }
    }
}