using UsersDb_Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Task9._2;

public class Program
{
    public static void Main()
    {
        using (var context = CreateContext.Create())
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            new CreateData(context);
        }

        //true - only active users, false - all users

        foreach(var data in UsersDataService.GetUsersRoles(false))
        {
            Console.WriteLine(data.Item1);
            foreach(var role in data.Item2)
            {
                Console.WriteLine(role);
            }
        }

        UsersDataService.AddNewRole(7, "NewRole");
        UsersDataService.AddRoleToAllUsers("Moderator");
    }
}