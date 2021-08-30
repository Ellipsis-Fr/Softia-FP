using Microsoft.AspNetCore.Mvc;
using Softia_FP.DAL;
using Softia_FP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softia_FP.Controllers
{
    public class ConventionController : Controller
    {
        private DalCertificat _dalCertificat;
        private DalStudent _dalStudent;

        public ConventionController()
        {
            _dalCertificat = new DalCertificat();
            _dalStudent = new DalStudent();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string GetConventionName(int id)
        {
            Convention convention = _dalStudent.GetStudent(id).Convention;
            if (convention != null) return convention.Name;
            return "";
        }
    }
}
