using Microsoft.EntityFrameworkCore;
using Softia_FP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softia_FP.DAL
{
    public class DalStudent
    {
        BddContext _ctx;

        public DalStudent()
        {
            _ctx = new BddContext();
        }

        public bool AddStudent(Student studentToAdd)
        {
            if (studentToAdd.Convention == null) return false;

            Student student = new Student() { LastName = studentToAdd.LastName, FirstName = studentToAdd.FirstName, Mail = studentToAdd.Mail };
            _ctx.Students.Add(student);

            student.Convention = studentToAdd.Convention;

            _ctx.SaveChanges();
            return true;
        }

        public bool CheckDouble(string mail)
        {
            return _ctx.Students.Where(x => x.Mail.Equals(mail, StringComparison.OrdinalIgnoreCase)).FirstOrDefault() != null ? true : false;
        }

        public List<Student> GetStudents()
        {
            return _ctx.Students.Include(x => x.Convention).ToList();
        }

        public Student GetStudent(int idStudent)
        {
            return _ctx.Students.Where(x => x.Id == idStudent).Include(x => x.Convention).FirstOrDefault();
        }
    }
}
