using JackTrack.Entities.Users;
using JackTrack.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace JackTrack.Entities.Tasks
{
	public class Mission :IWithId
	{
		[Key]
		public long Id { get; set; }

		
		public string? Name { get; set; } 

		public string? Description { get; set; }

		public DateTime? StartTime { get; set; }

		public DateTime? EndTime { get; set; }
		
		/// <summary>
		/// Who issued the task
		/// </summary>
		
		public User FromUser { get; set; }

		/// <summary>
		/// To whom the task was issued
		/// </summary>
		
		public IEnumerable<User>? ToUsers { get; set; }
		
	}
}
