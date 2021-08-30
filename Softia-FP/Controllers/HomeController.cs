using Microsoft.AspNetCore.Mvc;
using Softia_FP.DAL;
using Softia_FP.Models;
using Softia_FP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softia_FP.Controllers
{
    public class HomeController : Controller
    {
        private DalCertificat _dalCertificat;
        private DalStudent _dalStudent;

        public HomeController()
        {
            _dalCertificat = new DalCertificat();
            _dalStudent = new DalStudent();
        }

        public IActionResult Index()
        {
            return View(InitHomeViewModel());
        }

        [NonAction]
        private HomeViewModel InitHomeViewModel()
        {
            List<Student> students = _dalStudent.GetStudents();
            students.Sort();
            List<Certificat> certificats = _dalCertificat.GetCertificats();

            HomeViewModel hVM = new HomeViewModel();

            foreach (Student student in students)
            {
                Certificat certificatAssociated = null;

                foreach (Certificat certificat in certificats)
                {
                    if (certificat.Student.Equals(student))
                    {
                        certificatAssociated = certificat;
                        break;
                    }
                }

                hVM.List.Add(student, certificatAssociated);
            }

            return hVM;
        }
    }
}
