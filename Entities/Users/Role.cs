using Microsoft.AspNetCore.Identity;

namespace JackTrack.Entities.Users
{
	public class Role:IdentityRole<long>
	{
		public Role(string name):base(name)
		{

		}
	}
}
