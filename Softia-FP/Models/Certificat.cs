using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softia_FP.Models
{
    public class Certificat
    {
        public int Id { get; set; }

        public virtual Student Student { get; set; }

        public virtual Convention Convention { get; set; }

        public string Message { get; set; }
    }
}
