using Softia_FP.DAL;
using Softia_FP.Models;
using System;
using Xunit;

namespace TestProject1
{
    public class CertificatTest
    {
        private DalCertificat _dalCertificat;

        public CertificatTest()
        {
            _dalCertificat = new DalCertificat();
        }

        [Fact]
        public void CheckInstanciationCertificat()
        {
            //GIVEN
            Certificat certificat = new Certificat();

            //WHEN

            //THEN
            Assert.NotNull(certificat);
        }

        [Fact]
        public void AddCertificat()
        {
            //GIVEN
            Convention convention = new Convention() { Name = "Java", QtyHour = 200 };
            Student student = new Student() { LastName = "CRESPEL", FirstName = "Romain", Mail = "crespel.romain@gmail.com", Convention = convention };
            Certificat certificat = new Certificat() { Student = student, Convention = convention, Message = "Test" };

            //WHEN
            bool success = _dalCertificat.AddCertificat(certificat);

            //THEN
            Assert.True(success);
        }

        [Fact]
        public void CheckIsDouble()
        {
            //GIVEN
            Convention convention = new Convention() { Name = "Java", QtyHour = 200 };
            Student student = new Student() { LastName = "CRESPEL", FirstName = "Romain", Mail = "crespel.romain@gmail.com", Convention = convention };
            Certificat certificat = new Certificat() { Student = student, Convention = convention, Message = "Test" };

            //WHEN
            bool isDouble = _dalCertificat.CheckDouble(certificat);

            //THEN
            Assert.True(isDouble);
        }

        [Fact]
        public void CheckIsNotDouble()
        {
            //GIVEN
            Convention convention = new Convention() { Name = "Java", QtyHour = 200 };
            Student student = new Student() { LastName = "Lupin", FirstName = "Arsène", Mail = "arsene@gmail.com", Convention = convention };
            Certificat certificat = new Certificat() { Student = student, Convention = convention, Message = "Test" };

            //WHEN
            bool isNotDouble = _dalCertificat.CheckDouble(certificat);

            //THEN
            Assert.False(isNotDouble);
        }
    }
}
