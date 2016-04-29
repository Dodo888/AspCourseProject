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
                IsAlive = false,
                Description = "Jon Snow is a major character in the first, second, third, fourth, fifth, and sixth seasons. He is played by starring cast member Kit Harington, and debuts in the series premiere. Jon is the bastard son of Lord Eddard Stark of Winterfell. Upon his father leaving for the south, Jon decides to join the Night's Watch, defending the Wall from the threats beyond."
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
                IsAlive = true,
                Description = "Sansa Bolton, née Stark, is a major character in the first, second, third, fourth, fifth, and sixth seasons. She is played by starring cast member Sophie Turner, and debuts in the series premiere. Sansa is the daughter of Lord Eddard Stark of Winterfell and his wife Lady Catelyn, sister of Robb, Arya, Bran and Rickon Stark, and half-sister of Jon Snow."
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
                IsAlive = true,
                Description = "Ser Davos Seaworth, also known as the Onion Knight, is a major character in the second, third, fourth, fifth and sixth seasons. He is played by starring cast member Liam Cunningham and debuts in \"The North Remembers\". Davos is a landed knight, and a former smuggler who was in the service of Stannis Baratheon, Lord of Dragonstone and claimant to the Iron Throne, whom he serves as Hand of the King."
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
                IsAlive = true,
                Description = "Melisandre, often referred to as The Red Woman, is a major character in the second, third, fourth, fifth, and sixth seasons. She is played by starring cast member Carice van Houten and debuts in \"The North Remembers.\" She is a priestess of the Lord of Light and a close advisor to Stannis Baratheon in his campaign to take the Iron Throne, but ultimately abandons him after her actions inadvertently lead to the destruction of his family and army and flees to Castle Black."
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