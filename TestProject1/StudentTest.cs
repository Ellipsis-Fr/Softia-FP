using Softia_FP.DAL;
using Softia_FP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestProject1
{
    public class StudentTest
    {
        private DalStudent _dalStudent;

        public StudentTest()
        {
            _dalStudent = new DalStudent();
        }

        [Fact]
        public void CheckInstanciationStudent()
        {
            //GIVEN
            Student student = new Student() { LastName = "CRESPEL", FirstName = "Romain", Mail = "crespel.romain@gmail.com", Convention = new Convention() { Name = "Java", QtyHour = 200 } };

            //WHEN

            //THEN
            Assert.NotNull(student);
        }

        [Fact]
        public void AddStudentWithConvention()
        {
            //GIVEN
            Student student = new Student() { LastName = "CRESPEL", FirstName = "Romain", Mail = "crespel.romain@gmail.com", Convention = new Convention() { Name = "Java", QtyHour = 200 } };

            //WHEN
            bool success = _dalStudent.AddStudent(student);

            //THEN
            Assert.True(success);

        }

        [Fact]
        public void AddStudentWithoutConvention()
        {
            //GIVEN
            Student student = new Student() { LastName = "CRESPEL", FirstName = "Romain", Mail = "crespel.romain@gmail.com" };

            //WHEN
            bool success = _dalStudent.AddStudent(student);

            //THEN
            Assert.False(success);

        }

        [Fact]
        public void CheckIsDouble()
        {
            //GIVEN
            string mail = "bastien.m@ymail.com";

            //WHEN
            bool isDouble = _dalStudent.CheckDouble(mail);

            //THEN
            Assert.True(isDouble);

        }

        [Fact]
        public void CheckIsNotDouble()
        {
            //GIVEN
            string mail = "crespel.romain@gmail.com";

            //WHEN
            bool isNotDouble = _dalStudent.CheckDouble(mail);

            //THEN
            Assert.False(isNotDouble);

        }
    }
}
