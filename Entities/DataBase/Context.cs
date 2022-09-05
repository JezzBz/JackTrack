using Microsoft.EntityFrameworkCore;
using JackTrack.Entities.Users;


namespace JackTrack.Entities.DataBase
{
	public class Context: DbContext
	{
		public Context(DbContextOptions<Context> options)  : base(options)
		{
		}


		DbSet<User> Users { get; set; }
	}
}
