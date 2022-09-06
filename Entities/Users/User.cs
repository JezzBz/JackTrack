using JackTrack.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace JackTrack.Entities.Users
{
	public class User : IWithId
	{
		
		public long Id { get; set; }

		public string Name { get; set; } = "None";

		public string Email { get; set; } = "None";

	}
}
