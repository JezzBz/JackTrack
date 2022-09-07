using JackTrack.Entities.Users;

namespace JackTrack.Entities.Projects
{
	public class Project
	{
		public long Id { get; set; }

		public string Name { get; set; } = "";

		public string Description { get; set; } = "";

		public DateTime Created { get; set; }

		public IEnumerable<User> Users { get; set; }

	}
}
