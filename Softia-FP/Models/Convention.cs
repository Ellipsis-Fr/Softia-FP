using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softia_FP.Models
{
    public class Convention
    {
        public Convention()
        {
            Students = new HashSet<Student>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public int QtyHour { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Convention convention &&
                   Name.Equals(convention.Name, StringComparison.OrdinalIgnoreCase) &&
                   QtyHour == convention.QtyHour;
        }

        public override string ToString()
        {
            return Name + " : " + QtyHour + "h";
        }
    }
}
