using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softia_FP.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Certificat> Certificats { get; set; }

        public DbSet<Convention> Conventions { get; set; }

        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;password=;database=TP_SOFTIA_FormationPlus");
        }

        public void InitializeDb()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();

            Convention c1 = new Convention() { Name = "Javascript - Base", QtyHour = 35 };
            Convention c2 = new Convention() { Name = "Javascript - Maitrise", QtyHour = 70 };
            Convention c3 = new Convention() { Name = "Jquery", QtyHour = 21 };
            Convention c4 = new Convention() { Name = "AJAX", QtyHour = 70 };
            Convention c5 = new Convention() { Name = "Java - Principe", QtyHour = 21 };
            Convention c6 = new Convention() { Name = "Java - Approfondissement", QtyHour = 100 };
            Convention c7 = new Convention() { Name = "Java - Maitrise", QtyHour = 140 };

            Conventions.AddRange(c1, c2, c3, c4, c5, c6, c7);

            Students.AddRange(
                new Student() { FirstName = "Bastien", LastName = "MARTIN", Mail = "bastien.m@ymail.com", Convention = c1 },
                new Student() { FirstName = "Pinau", LastName = "ACHASS", Mail = "pachass@msn.com", Convention = c1 },
                new Student() { FirstName = "Guy", LastName = "NORMAND", Mail = "normand.guy88@bravemail.com", Convention = c5 },
                new Student() { FirstName = "Mike", LastName = "DELICE", Mail = "mike.delice@gmail.com", Convention = c7 },
                new Student() { FirstName = "Paul", LastName = "ARIDE", Mail = "paul.a@ymail.com", Convention = c3 },
                new Student() { FirstName = "Amina", LastName = "LATTE", Mail = "aminaL@gmail.com", Convention = c2 },
                new Student() { FirstName = "Kiat", LastName = "MAJO", Mail = "kiat.majo@gmail.com", Convention = c4 },
                new Student() { FirstName = "Jean", LastName = "ECOUTE", Mail = "jeanEcoute@hotmail.com", Convention = c6 },
                new Student() { FirstName = "WallE", LastName = "ABOUT", Mail = "wallE@ymail.com", Convention = c3 },
                new Student() { FirstName = "Olive", LastName = "ATTON", Mail = "oliveatton@msn.com", Convention = c3 },
                new Student() { FirstName = "Patrice", LastName = "BIENCARRE", Mail = "patcarre@gmail.com", Convention = c3 },
                new Student() { FirstName = "Honfleur", LastName = "BELLE", Mail = "honfleurbelle@msn.fr", Convention = c6 },
                new Student() { FirstName = "Anais", LastName = "HO", Mail = "anaish@gmail.com", Convention = c2 },
                new Student() { FirstName = "Mino", LastName = "ASSEZ", Mail = "minoassez@ymail.com", Convention = c7 },
                new Student() { FirstName = "Romy", LastName = "BORATO", Mail = "romyborato@gmail.com", Convention = c7 }
            );

            SaveChanges();
        }
    }
}
