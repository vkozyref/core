namespace CoreApp.Entities
{
    public class Enrollment
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string Type { get; set; }

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}
