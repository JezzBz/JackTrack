using Microsoft.EntityFrameworkCore;
using JackTrack.Entities.Users;
using JackTrack.Entities.Tasks;
using JackTrack.Entities.Projects;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace JackTrack.Entities.DataBase
{
	public class Context: IdentityDbContext<User, Role, long>
	{
		public Context(DbContextOptions<Context> options)  : base(options)
		{
		
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Mission>()
				.HasOne(q => q.FromUser)
				.WithMany(q => q.IssuedMissions)
				.HasForeignKey(q => q.FromUserId)
				.HasPrincipalKey(q => q.Id);

			modelBuilder.Entity<Project>()
				.HasMany(q => q.Users)
				.WithMany(q => q.Projects);

		}

		DbSet<User> Users { get; set; }

		DbSet<Mission> Missions { get; set; }

		DbSet<Project> Projects { get; set; }

	}
}
