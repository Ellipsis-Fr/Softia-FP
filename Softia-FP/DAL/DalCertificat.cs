using Microsoft.EntityFrameworkCore;
using Softia_FP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softia_FP.DAL
{
    public class DalCertificat
    {
        BddContext _ctx;

        public DalCertificat()
        {
            _ctx = new BddContext();
        }

        public bool AddCertificat(Certificat certificatToAdd)
        {
            Certificat certificat = new Certificat() { Message = certificatToAdd.Message };

            _ctx.Certificats.Add(certificat);

            certificat.Student = certificatToAdd.Student;
            certificat.Convention = certificatToAdd.Convention;

            _ctx.SaveChanges();
            return true;
        }

        public void ModifyCertificat(Certificat certificatToModify)
        {
            Certificat certificat = GetCertificat(certificatToModify.Id);
            certificat.Message = certificatToModify.Message;
            _ctx.SaveChanges();
        }

        public bool CheckDouble(Certificat certificatToAdd)
        {
            List<Certificat> certificats = _ctx.Certificats
                .Include(x => x.Student)
                .Include(x => x.Convention)
                .ToList();

            foreach (Certificat certificat in certificats)
            {
                if (certificat.Student.Equals(certificatToAdd.Student) && certificat.Convention.Equals(certificatToAdd.Convention)) return true;
            }

            return false;
            ;
        }

        public Certificat GetCertificat(int idCertificat)
        {
            return _ctx.Certificats.Where(x => x.Id == idCertificat).Include(x => x.Student).Include(x => x.Convention).First();
        }

        public List<Certificat> GetCertificats()
        {
            return _ctx.Certificats.Include(x => x.Student).Include(x => x.Convention).ToList();
        }
    }
}
