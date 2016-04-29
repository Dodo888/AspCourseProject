using System.Data.Entity;
using System.Security.Policy;
using AspCourseProject.Domain.Entities;
using Microsoft.SqlServer.Server;

namespace AspCourseProject.Domain
{
    public class MyContextInitializer : DropCreateDatabaseAlways<EFDbContext>
    {
        protected override void Seed(EFDbContext db)
        {
            var p1 = new Person
            {
                PersonId = 1,
                Name = "Jon Snow",
                Image =
                    "http://vignette2.wikia.nocookie.net/gameofthrones/images/9/95/Jon_Snow_%28S05E05%29.jpg/revision/latest/scale-to-width-down/270?cb=20150512181258",
                Rating = 10,
                Price = 10,
                Category = "House of Stark",
                Gender = true,
                IsAlive = false
            };
            var p2 = new Person
            {
                PersonId = 2,
                Name = "Sansa Stark",
                Image =
                    "http://vignette1.wikia.nocookie.net/gameofthrones/images/5/5b/Sansa_Season_Six_Snow.jpg/revision/latest/scale-to-width-down/270?cb=20160213183617",
                Rating = 10,
                Price = 10,
                Category = "House of Stark",
                Gender = false,
                IsAlive = true
            };
            var p3 = new Person
            {
                PersonId = 3,
                Name = "Davos Seaworth",
                Image =
                    "http://vignette2.wikia.nocookie.net/gameofthrones/images/4/4b/Davos_Seaworth_%28S05E01%29.jpg/revision/latest/scale-to-width-down/270?cb=20150419151136",
                Rating = 5,
                Price = 5,
                Category = "House of Baratheon",
                Gender = true,
                IsAlive = true
            };
            var p4 = new Person
            {
                PersonId = 4,
                Name = "Melisandre",
                Image =
                    "http://vignette1.wikia.nocookie.net/gameofthrones/images/5/5c/Mlisandre_Season_6.jpg/revision/latest/scale-to-width-down/270?cb=20160211221203",
                Rating = 5,
                Price = 5,
                Category = "House of Baratheon",
                Gender = false,
                IsAlive = true
            };

            db.Table.Add(p1);
            db.Table.Add(p2);
            db.Table.Add(p3);
            db.Table.Add(p4);
            db.SaveChanges();
        }
    }

    public class EFDbContext: DbContext
    {
        public DbSet<Person> Table { get; set; }

        public EFDbContext()
        {
            Database.SetInitializer<EFDbContext>(new MyContextInitializer());
        }
    }
}