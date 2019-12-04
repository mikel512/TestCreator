using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;
using DataLibrary.Models;
using DataLibrary.DataAccess;

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
        [AllowAnonymous]
        public IActionResult ClassView()
        {
            SqlDataAccess data = new SqlDataAccess();
            List<ExamModel> allExams = data.GetAllExamsList();

            ViewData["allExams"] = allExams;

            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult AddClassAJAX(int classID)
        {

            Debug.WriteLine("*** Added Class: " + classID.ToString());

            return View("Dashboard");
        }
    }
}