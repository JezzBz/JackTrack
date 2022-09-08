using JackTrack.Entities.Projects;
using JackTrack.Entities.Tasks;
using JackTrack.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JackTrack.Entities.Users
{
	public class User : IdentityUser<long>
	{
	

		public string Name { get; set; } = "None";

		[JsonIgnore]
		public IEnumerable<Mission> IssuedMissions { get; set; }

		[JsonIgnore]
		public IEnumerable<Mission> Missions { get; set; }
		
		[JsonIgnore]
		public IEnumerable<Project> Projects { get; set; } 
	}
  

}
