using Microsoft.EntityFrameworkCore;
using Softia_FP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softia_FP.DAL
{
    public class DalConvention
    {
        BddContext _ctx;

        public DalConvention()
        {
            _ctx = new BddContext();
        }

        public Convention GetConvention(int idConvention)
        {
            return _ctx.Conventions.Include(x => x.Students).FirstOrDefault(x => x.Id == idConvention);
        }

        public List<Convention> GetConventions()
        {
            return _ctx.Conventions.Include(x => x.Students).ToList();
        }
    }
}
