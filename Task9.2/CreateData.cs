using UsersDb_Core;
using UsersDb_Core.Entities;

namespace Task9._2
{
    public class CreateData
    {
        public CreateData(UserContext db)
        {
            Role r1 = new Role { Id = 1, Name = "Admin" };
            Role r2 = new Role { Id = 2, Name = "Editor" };
            Role r3 = new Role { Id = 3, Name = "Content Creator" };
            Role r4 = new Role { Id = 4, Name = "Moderator" };
            Role r5 = new Role { Id = 5, Name = "View-only" };

            User u1 = new User { Email = "mbucklee0@lycos.com", PasswordHash = "$2a$04$Jinu4gf/MIp1MCRRxBkD8OQQabxt7E785ZR/NJXWyU8xWY.Sd0MCO", FirstName = "Marla", LastName = "Bucklee", Status = 1 };
            User u2 = new User { Email = "clerven1@taobao.com", PasswordHash = "$2a$04$CYwjF.81.zYKI9NfWrE2VuvyaVdqVexanO0JliuEZOwgqHATwbJ7.", FirstName = "Chrissy", LastName = "Lerven", Status = 0 };
            User u3 = new User { Email = "jcatlette2@ebay.co.uk", PasswordHash = "$2a$04$Mln3ntuoZbUEipvA95g6veIkJdr3ukL7pvkfVYbJJPghI.GHyijzS", FirstName = "Jaquith", LastName = "Catlette", Status = 0 };
            User u4 = new User { Email = "skobierai@wordpress.org", PasswordHash = "$2a$05$XpTaJvzr8RHSQrepPvkPguPZWf7pPVcc024sjgikolQtzeMHj8ox.", FirstName = "Say", LastName = "Kobiera", Status = 1 };

            u1.Roles.Add(r1);
            u1.Roles.Add(r5);

            u2.Roles.Add(r2);

            u3.Roles.Add(r3);
            u3.Roles.Add(r2);

            u4.Roles.Add(r1);
            u4.Roles.Add(r2);
            u4.Roles.Add(r4);

            db.Add(u1);
            db.Add(u2);
            db.Add(u3);
            db.Add(u4);

            db.SaveChanges();
        }
    }
}

