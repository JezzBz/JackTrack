using Microsoft.EntityFrameworkCore;
using JackTrack.Entities.Users;
using JackTrack.Entities.Tasks;
using Task = JackTrack.Entities.Tasks.Task;

namespace JackTrack.Entities.DataBase
{
	public class Context: DbContext
	{
		public Context(DbContextOptions<Context> options)  : base(options)
		{
		}


		DbSet<User> Users { get; set; }

		DbSet<Task> Tasks { get; set; }
	}
}
