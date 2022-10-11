using UsersDb_Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Task9._2
{
	public static class CreateContext
	{
		public static UserContext Create()
		{
			var builder = new ConfigurationBuilder();
			builder.SetBasePath(Directory.GetCurrentDirectory());
			builder.AddJsonFile("appsettings.json");
			var config = builder.Build();

			var options = new DbContextOptionsBuilder<UserContext>().UseSqlServer(config.GetConnectionString("UserDb_Core")).Options;

			var context = new UserContext(options);

			return context;
		}
	}
}

