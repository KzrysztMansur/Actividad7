namespace actividad7.Models
{
    public class Group
    {
        public int? GroupId { get; set; }
        public string? GroupLabel { get; set; }

        public ICollection<CourseGroup>? CourseGroups { get; set; }
    }
}
