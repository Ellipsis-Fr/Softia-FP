using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Softia_FP.DAL;
using Softia_FP.Models;
using Softia_FP.ViewModels;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Softia_FP.Controllers
{
    public class CertificatController : Controller
    {
        private DalCertificat _dalCertificat;
        private DalStudent _dalStudent;

        public CertificatController()
        {
            _dalCertificat = new DalCertificat();
            _dalStudent = new DalStudent();
        }

        public IActionResult Index(int id)
        {
            ViewBag.students = SelectListStudentsWithoutCertificat();

            return View();
        }

        [NonAction]
        private SelectList SelectListStudentsWithoutCertificat()
        {
            List<Certificat> certificats = _dalCertificat.GetCertificats();
            List<Student> students = _dalStudent.GetStudents();
            students.Sort();

            if (certificats.Count != 0) StudentsWithoutCertificat(certificats, students);

            return new SelectList((IEnumerable)students.Select(x => new
            {
                Value = x.Id,
                Text = x.ToString()

            }).ToList(), "Value", "Text");
        }

        [NonAction]
        private List<Student> StudentsWithoutCertificat(List<Certificat> certificats, List<Student> students)
        {
            foreach (Certificat certificat in certificats)
            {
                foreach (Student student in new List<Student>(students))
                {
                    if (certificat.Student.Equals(student)) students.Remove(student);
                }
            }

            return students;
        }

        [HttpPost]
        public IActionResult AddAndSendNewCertificat(int id, string message)
        {
            Student student = _dalStudent.GetStudent(id);

            Certificat certificat = new Certificat() { Student = student, Convention = student.Convention, Message = message };

            _dalCertificat.AddCertificat(certificat);

            Mail.SendMail(message, student.Mail);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult ModifyCertificat(int id)
        {
            Certificat certificat = _dalCertificat.GetCertificat(id);
            return View("Index", certificat);
        }

        [HttpPost]
        public IActionResult ModifyCertificat(Certificat certificat)
        {
            _dalCertificat.ModifyCertificat(certificat);
            Mail.SendMail(certificat.Message, certificat.Student.Mail);
            return RedirectToAction("Index", "Home");
        }
    }
}
