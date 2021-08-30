using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Softia_FP.DAL;
using Softia_FP.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softia_FP.Controllers
{
    public class StudentController : Controller
    {
        private DalConvention _dalConvention;
        private DalStudent _dalStudent;

        public StudentController()
        {
            _dalConvention = new DalConvention();
            _dalStudent = new DalStudent();
        }

        public IActionResult Index()
        {
            ViewBag.conventions = SelectListConventions();

            return View(new Student());
        }

        [NonAction]
        private SelectList SelectListConventions()
        {
            List<Convention> conventions = _dalConvention.GetConventions();

            return new SelectList((IEnumerable)conventions.Select(x => new
            {
                Value = x.Id,
                Text = x.ToString()

            }).ToList(), "Value", "Text");
        }

        [HttpPost]
        public IActionResult AddNewStudent(int id, Student student)
        {
            Convention convention = _dalConvention.GetConvention(id);
            student.Convention = convention;


            _dalStudent.AddStudent(student);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public JsonResult GetStudent(int id)
        {
            Student student = _dalStudent.GetStudent(id);

            return Json(
                new {
                success = true,
                studentLastName = student.LastName,
                studentFirstName = student.FirstName,
                studentConventionName = student.Convention.Name,
                studentConventionQtyHour = student.Convention.QtyHour
                });
        }

        [HttpPost]
        public JsonResult CheckMailNotExists(string mail)
        {
            bool mailExists = _dalStudent.CheckDouble(mail);

            return Json(
                new
                {
                    success = true,
                    isDouble = mailExists,
                });
        }
    }
}
