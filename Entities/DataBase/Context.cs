using Microsoft.EntityFrameworkCore;
using JackTrack.Entities.Users;
using JackTrack.Entities.Tasks;



namespace JackTrack.Entities.DataBase
{
	public class Context: DbContext
	{
		public Context(DbContextOptions<Context> options)  : base(options)
		{
		
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			

			modelBuilder.Entity<Mission>()
			.HasOne(q => q.FromUser)
			.WithMany(q => q.IssuedMissions)
			.HasForeignKey(q => q.FromUserId);

		}

			DbSet<User> Users { get; set; }

		DbSet<Mission> Missions { get; set; }

	}
}
