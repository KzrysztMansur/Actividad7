namespace actividad7.Models
{
    public class Course
    {
        public int? CourseId { get; set; }
        public string? CourseName { get; set; }
        public string? Description { get; set; }
        public int? KitId { get; set; }

        public Kit? Kit { get; set; }
        public ICollection<CourseUser>? CourseUsers { get; set; }
        public ICollection<CourseGroup>? CourseGroups { get; set; }
    }
}
