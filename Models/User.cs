namespace actividad7.Models
{
    public class User
    {
        public int? UserId { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? RoleId { get; set; }

        public Role? Role { get; set; }
        public ICollection<CourseUser>? CourseUsers { get; set; }
        public ICollection<CourseGroup>? CourseGroups { get; set; }
    }
}
