using System;
using UsersDb_Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Task9._2
{
    public static class UsersDataService
    {
        public static List<(User, Role[])> GetUsersRoles(bool isActive)
        {
            List<(User, Role[])> result = new();
            using var context = CreateContext.Create();
            dynamic users = isActive ? context.Users.Include(x => x.Roles).Where(u => u.Status == 1) : context.Users.Include(x => x.Roles);

            foreach (var user in users)
            {
                List<Role> roles = new();
                foreach (var role in user.Roles)
                {
                    roles.Add(role);
                }
                result.Add((user, roles.ToArray()));
            }

            return result;
        }

        public static void AddNewRole(int id, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException();
            }

            using var context = CreateContext.Create();

            var role = context.Roles.Select(x => x).Where(r => r.Id == id).FirstOrDefault();

            if (role is null)
            {
                context.Roles.Add(new Role { Id = id, Name = name });
            }
            else
            {
                role.Name = name;
            }

            context.SaveChanges();
        }

        public static void AddRoleToAllUsers(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                throw new ArgumentException();
            }

            using var context = CreateContext.Create();

            var users = context.Users.Include(r => r.Roles).Select(x => x);

            var role = context.Roles.Select(r => r).Where(r => r.Name == roleName).FirstOrDefault();

            if (role is null)
            {
                throw new Exception("Role does not exist in database");
            }
            else
            {
                foreach (var user in users)
                {
                    if (user.Roles.Contains(role) == false)
                    {
                        user.Roles.Add(role);
                    }
                }
            }

            context.SaveChanges();
        }
    }
}

