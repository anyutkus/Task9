using System;
using System.ComponentModel.DataAnnotations;

namespace UsersDb_Core.Entities
{
    public sealed class Role : Entity<int>
    {
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }

        public Role() => Users = new HashSet<User>();

        public override string ToString()
        {
            return Name;
        }
    }
}

