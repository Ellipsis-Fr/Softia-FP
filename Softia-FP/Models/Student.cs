using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Softia_FP.Models
{
    public class Student : IComparable<Student>
    {
        public int Id { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Mail { get; set; }

        [Required]
        public virtual Convention Convention { get; set; }

        //public int Compare(Student s1, Student s2)
        //{
        //    int result = s1.LastName.CompareTo(s2.LastName);
        //    if (result != 0) return result;
        //    else return s1.FirstName.CompareTo(s2.FirstName);

        //}

        public int CompareTo(Student other)
        {
            int result = LastName.CompareTo(other.LastName);
            if (result != 0) return result;
            else return FirstName.CompareTo(other.FirstName);
        }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   Mail.Equals(student.Mail, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            return LastName + " " + FirstName + " - " + Mail;
        }
    }
}
