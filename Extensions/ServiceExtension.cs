using JackTrack.Entities.DataBase;
using JackTrack.Entities.Users;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace JackTrack.Extensions
{
	public static class ServiceExtension
	{
		
		public static void ConfigureIdentity(this IServiceCollection services)
		{
			var builder = services.AddIdentity<User, Role>(opt =>
			{
				opt.Password.RequiredLength = 6;
				opt.Password.RequireDigit = true;
				opt.Password.RequireUppercase = true;
				opt.Lockout.MaxFailedAccessAttempts = 5;
				opt.User.RequireUniqueEmail = true;
				opt.SignIn.RequireConfirmedEmail = true;	
			});
			
			builder.AddRoles<Role>()
				.AddSignInManager()
				.AddEntityFrameworkStores<Context>()
				.AddDefaultTokenProviders()
				;
		}

		public async static Task AnsureUserSeedConfigured(this IServiceProvider serviceProvider)
		{
			var userManager = serviceProvider.CreateAsyncScope().ServiceProvider.GetRequiredService<UserManager<User>>();

			foreach (var user in SeedConfig.RequireUsers)
			{
				if (await userManager.FindByEmailAsync(user.Email) == null)
				{
					
					await userManager.CreateAsync(user);
				
					
					

					if (user.Email.Contains("@admin.com")) await userManager.AddToRoleAsync(user,"Admin");
				}

			}

		}
		public async static Task AnsureRoleSeedConfigured(this IServiceProvider serviceProvider)
		{
			var roleManager =  serviceProvider.CreateAsyncScope().ServiceProvider.GetRequiredService<RoleManager<Role>>();

			foreach (var role in SeedConfig.RequireRoles)
			{
				if (await roleManager.FindByNameAsync(role) == null) await roleManager.CreateAsync(new Role(role));
			}

		}
	}

	internal static class SeedConfig
	{
		internal static List<string> RequireRoles = new List<string>()
		{
			"Admin",
			"Employee"
		};

		//Only in development env
		internal static List<User> RequireUsers = new List<User>()
		{
			//Admin User
			new User()
			{
				Name  = "TrackMaster",
				Email = "admin@admin.com",
				EmailConfirmed = true,
				PasswordHash = "1".Hash(),
				UserName = "TrackMaster"
				
			}
		};
	}
}
