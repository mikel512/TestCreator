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
            
            ClaimsPrincipal currentUser = this.User;
            string currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            List<ClassModel> myClasses = data.GetStudentClassList(currentUserId);
            List<ClassModel> allClasses = data.GetAllClassesList();

            ViewData["allClasses"] = allClasses;
            ViewData["myClasses"] = myClasses;

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
        public IActionResult AddClassAJAX(int classID)
        {
            SqlDataAccess data = new SqlDataAccess();

            ClaimsPrincipal currentUser = this.User;
            string currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            data.AddStudentToClass(currentUserId, classID);

            return RedirectToAction("Dashboard");
        }
    }
}