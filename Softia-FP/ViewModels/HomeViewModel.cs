using Softia_FP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softia_FP.ViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            List = new Dictionary<Student, Certificat>();
        }

        public Dictionary<Student, Certificat> List { get; set; }
    }
}
