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
        public IActionResult ExamCreation(int classId)
        {
            var access = new SqlDataAccess();
            var classroom = access.GetClassroomById(classId);
            ViewData["ClassData"] = classroom;
            ViewData["TestData"] = new ExamModel();
            return View(classroom);
        }

        #region Post Actions
        [HttpPost]
        public IActionResult CreateClass(ClassModel classModel)
        {
            var access = new SqlDataAccess();
            ClaimsPrincipal currentUser = this.User;
            string currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (ModelState.IsValid)
            {
                access.CreateClass(classModel.className, classModel.classSubject, currentUserId);
                return RedirectToAction("Index");
            }
            return View();
        }

        #endregion
    }
}