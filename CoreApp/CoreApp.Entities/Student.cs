using System.Collections.Generic;

namespace CoreApp.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string UserEmail { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
