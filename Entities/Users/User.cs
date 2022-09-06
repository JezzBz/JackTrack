using JackTrack.Interfaces;

namespace JackTrack.Entities.Users
{
	public class User : IWithId
	{
		public long Id { get; set; }
		
		public string Name { get; set; }

		public string Email { get; set; } = "None";

		public Role Role { get; set; } = Role.Student;

		[JsonIgnore]
		public IEnumerable<Mission> IssuedMissions { get; set; }

		[JsonIgnore]
		public IEnumerable<Mission> Missions { get; set; }

		
	}
	public enum Role
	{
		Admin = 0,
		Teacher = 1,
		Student = 2

	}
}
