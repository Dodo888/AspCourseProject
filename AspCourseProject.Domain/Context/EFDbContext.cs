using System.Collections.Generic;
using System.Data.Entity;
using AspCourseProject.Domain.Entities;

namespace AspCourseProject.Domain.Context
{
    public class MyContextInitializer : DropCreateDatabaseAlways<EFDbContext>
    {
        protected override void Seed(EFDbContext db)
        {
            var p = new List<Person>()
            {
                new Person
                {
                    PersonId = 1,
                    Name = "Jon Snow",
                    Image =
                        "http://vignette2.wikia.nocookie.net/gameofthrones/images/9/95/Jon_Snow_%28S05E05%29.jpg/revision/latest/scale-to-width-down/270?cb=20150512181258",
                    Rating = 10,
                    Price = 10,
                    Category = "House Stark",
                    Gender = true,
                    IsAlive = false,
                    Description =
                        "Jon Snow is a major character in the first, second, third, fourth, fifth, and sixth seasons. He is played by starring cast member Kit Harington, and debuts in the series premiere. Jon is the bastard son of Lord Eddard Stark of Winterfell. Upon his father leaving for the south, Jon decides to join the Night's Watch, defending the Wall from the threats beyond."
                },
                new Person
                {
                    PersonId = 2,
                    Name = "Sansa Stark",
                    Image =
                        "http://vignette1.wikia.nocookie.net/gameofthrones/images/5/5b/Sansa_Season_Six_Snow.jpg/revision/latest/scale-to-width-down/270?cb=20160213183617",
                    Rating = 10,
                    Price = 10,
                    Category = "House Stark",
                    Gender = false,
                    IsAlive = true,
                    Description =
                        "Sansa Bolton, née Stark, is a major character in the first, second, third, fourth, fifth, and sixth seasons. She is played by starring cast member Sophie Turner, and debuts in the series premiere. Sansa is the daughter of Lord Eddard Stark of Winterfell and his wife Lady Catelyn, sister of Robb, Arya, Bran and Rickon Stark, and half-sister of Jon Snow."
                },
                new Person
                {
                    PersonId = 3,
                    Name = "Davos Seaworth",
                    Image =
                        "http://vignette2.wikia.nocookie.net/gameofthrones/images/4/4b/Davos_Seaworth_%28S05E01%29.jpg/revision/latest/scale-to-width-down/270?cb=20150419151136",
                    Rating = 5,
                    Price = 5,
                    Category = "House Baratheon",
                    Gender = true,
                    IsAlive = true,
                    Description =
                        "Ser Davos Seaworth, also known as the Onion Knight, is a major character in the second, third, fourth, fifth and sixth seasons. He is played by starring cast member Liam Cunningham and debuts in \"The North Remembers\". Davos is a landed knight, and a former smuggler who was in the service of Stannis Baratheon, Lord of Dragonstone and claimant to the Iron Throne, whom he serves as Hand of the King."
                },
                new Person
                {
                    PersonId = 4,
                    Name = "Melisandre",
                    Image =
                        "http://vignette1.wikia.nocookie.net/gameofthrones/images/5/5c/Mlisandre_Season_6.jpg/revision/latest/scale-to-width-down/270?cb=20160211221203",
                    Rating = 5,
                    Price = 5,
                    Category = "House Baratheon",
                    Gender = false,
                    IsAlive = true,
                    Description =
                        "Melisandre, often referred to as The Red Woman, is a major character in the second, third, fourth, fifth, and sixth seasons. She is played by starring cast member Carice van Houten and debuts in \"The North Remembers.\" She is a priestess of the Lord of Light and a close advisor to Stannis Baratheon in his campaign to take the Iron Throne, but ultimately abandons him after her actions inadvertently lead to the destruction of his family and army and flees to Castle Black."
                },
                new Person()
                {
                    PersonId = 5,
                    Name = "Ellaria Sand",
                    Image =
                        "http://vignette2.wikia.nocookie.net/gameofthrones/images/4/42/Ellaria-S5.png/revision/latest/scale-to-width-down/270?cb=20150313155847",
                    Rating = 5,
                    Price = 5,
                    Category = "House Martell",
                    Gender = false,
                    IsAlive = true,
                    Description =
                        "Ellaria Sand is a major character in the fifth and sixth seasons. She initially appeared as a recurring character in the fourth season, debuting in 'Two Swords'. She is portrayed by starring cast member Indira Varma. Ellaria is the paramour of Prince Oberyn Martell of Dorne and a bastard of House Uller, carrying the bastard surname Sand like all bastards in Dorne."

                },
                new Person
                {
                    PersonId = 6,
                    Name = "Cersei Lannister",
                    Image ="http://vignette2.wikia.nocookie.net/gameofthrones/images/b/bd/Game_of_Thrones_Season_6_22.jpg/revision/latest/scale-to-width-down/270?cb=20160211221429",
                    Rating = 10,
                    Price = 10,
                    Category = "House Lannister",
                    Gender = false,
                    IsAlive = true,
                    Description ="Queen Cersei Lannister is a major character in the first, second, third, fourth, fifth, and sixth seasons. She is portrayed by starring cast member Lena Headey and debuts in the series premiere. Cersei is the widow of King Robert Baratheon and Dowager Queen of the Seven Kingdoms. She is the daughter of Lord Tywin Lannister, twin sister of Jaime Lannister and elder sister of Tyrion Lannister. She has an incestuous sexual relationship with Jaime, who is secretly the father of her three children, Joffrey, Myrcella and Tommen."
                },
                new Person
                {
                    PersonId = 7,
                    Name = "Tormund",
                    Image ="http://vignette4.wikia.nocookie.net/gameofthrones/images/4/46/TormundGS5.png/revision/latest?cb=20150415044031",
                    Rating = 5,
                    Price = 5,
                    Category = "The Free Folk",
                    Gender = true,
                    IsAlive = true,
                    Description ="Tormund takes part in the Battle of Castle Black and is captured by the Night's Watch in the aftermath. After Mance's death, the new Lord Commander of the Night's Watch, Jon Snow, releases Tormund and asks him to help win over the remaining wildlings into an alliance against the White Walkers. Tormund is present at the massacre at Hardhome, where he fights against the army of the dead. He ultimately survives the battle, and is allowed through the Wall and into the Seven Kingdoms along with all of the surviving wildlings."
                },
                new Person
                {
                    PersonId = 8,
                    Name = "Tommen I Baratheon",
                    Image ="http://vignette1.wikia.nocookie.net/gameofthrones/images/7/78/Tommen_Season_6.jpg/revision/latest/scale-to-width-down/270?cb=20160211212139",
                    Rating = 5,
                    Price = 5,
                    Category = "House Baratheon ",
                    Gender = true,
                    IsAlive = true,
                    Description ="King Tommen Baratheon is a major character in the fifth and sixth seasons. He initially appeared as a recurring character in the first, second and fourth seasons. He is portrayed by starring cast member Dean-Charles Chapman, taking over the role (starting in Season 4) from Callum Wharry, who played the character briefly in Seasons 1 and 2. Tommen is the younger brother of King Joffrey and Princess Myrcella. Though legally the son of the late King Robert Baratheon and Queen Cersei Lannister, his true father is Ser Jaime Lannister, the Queen's twin brother. His sole biological grandparents, Tywin and Joanna Lannister, were also first cousins."
                }
            };


            db.Table.AddRange(p);
            db.SaveChanges();
        }
    }

    public class EFDbContext: DbContext
    {
        public DbSet<Person> Table { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<VoteItem> VoteItems { get; set; }

        public EFDbContext()
        {
            //Database.SetInitializer<EFDbContext>(new MyContextInitializer());
        }
    }
}