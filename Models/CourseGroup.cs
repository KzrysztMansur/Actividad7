namespace actividad7.Models
{
    public class CourseGroup
    {
        public int? CourseGroupId { get; set; }
        public int? CourseId { get; set; }
        public int? GroupId { get; set; }
        public int? TeacherId { get; set; }

        public Course? Course { get; set; }
        public Group? Group { get; set; }
        public User? Teacher { get; set; }
    }

}
