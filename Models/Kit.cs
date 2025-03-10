namespace actividad7.Models
{
    public class Kit
    {
        public int? KitId { get; set; }
        public string? KitName { get; set; }

        public ICollection<Course>? Courses { get; set; }
    }
}
