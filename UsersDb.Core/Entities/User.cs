using System;
namespace UsersDb_Core.Entities
{
    public sealed class User : Entity<Guid>
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Status { get; set; }

        public ICollection<Role> Roles { get; set; }

        public User() => Roles = new HashSet<Role>();

        public override string ToString()
        {
            return FirstName + ", " + LastName + ", " + Email + ", " + PasswordHash + ", " + Status.ToString();
        }
    }
}

