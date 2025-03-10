using actividad7.Models;
using Microsoft.EntityFrameworkCore;

public class DbSeeder
{
    public static void Seed(AppDbContext context)
    {
        // Comprobamos si ya existen usuarios
        if (!context.Users.Any())
        {
            var users = new List<User>
            {
                new User
                {
                    Name = "Admon",
                    Email = "admon@robotics.com",
                    Password = "Adm@2022",
                    Role = new Role { RoleName = "Administrativo" }
                },
                new User
                {
                    Name = "Tecmilenio",
                    Email = "tecmilenio@robotics.com",
                    Password = "Adm@2022",
                    Role = new Role { RoleName = "Profesor" }
                },
                new User
                {
                    Name = "Estudiante",
                    Email = "student@robotics.com",
                    Password = "Adm@2022",
                    Role = new Role { RoleName = "Estudiante" }
                }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
