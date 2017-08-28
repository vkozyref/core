using System.Collections.Generic;

namespace CoreApp.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Discipline { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
