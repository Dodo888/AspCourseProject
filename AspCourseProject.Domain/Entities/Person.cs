namespace AspCourseProject.Domain.Entities
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public bool Gender { get; set; }
        public bool IsAlive { get; set; }

        public string Status() => IsAlive ? "alive" : "dead";
        public string Sex() => Gender ? "М" : "Ж";
    }
}
