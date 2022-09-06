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


		DbSet<User> Users { get; set; }

		DbSet<Mission> Missions { get; set; }
	}
}
