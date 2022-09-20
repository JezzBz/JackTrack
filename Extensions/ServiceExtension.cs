using JackTrack.Entities.DataBase;
using JackTrack.Entities.Projects;
using JackTrack.Entities.Users;
using Microsoft.AspNetCore.Identity;
using NuGet.Protocol;
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
				.AddDefaultTokenProviders();
		}

		public async static Task AnsureUserSeedConfigured(this IServiceProvider serviceProvider)
		{
			var userManager = serviceProvider.CreateAsyncScope().ServiceProvider.GetRequiredService<UserManager<User>>();
			
			var repository = new Repository(serviceProvider.CreateAsyncScope().ServiceProvider.GetRequiredService<Context>());
			var project = repository.GetAll<Project>().FirstOrDefault();
			var usersProject = new List<User>();
			foreach (var user in SeedConfig.RequireUsers)
			{

				

				if (await userManager.FindByEmailAsync(user.Email) == null)
				{


					await userManager.CreateAsync(user);
					var currentUser = await userManager.FindByEmailAsync(user.Email);
					
					
					


					if (user.Email.Contains("@admin.com")) await userManager.AddToRoleAsync(user,"Admin");
					if (user.Email.Contains("@user.com")) await userManager.AddToRoleAsync(user, "Employee");

					usersProject.Add(currentUser);							
					repository.Attach(currentUser);


				}

			}
			project.Users = usersProject;
			repository.Attach(project);
			await repository.Update(project);
			
			repository.Entry(project);
			await repository.SaveAsync();

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
				
			},
			new User()
			{
				Name  = "TrackMaster",
				Email = "user@user.com",
				EmailConfirmed = true,
				PasswordHash = "1".Hash(),
				UserName = "TrackSlave"
			}
		};
	}
}
