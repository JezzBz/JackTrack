using JackTrack.Interfaces;

namespace JackTrack.Entities.Users
{
	public class User : IWithId
	{
		public long Id { get; set; }
		
		public string Name { get; set; }

		public string Email { get; set; }

	}
}
