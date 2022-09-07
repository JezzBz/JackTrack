using JackTrack.Entities.Users;
using JackTrack.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

		public DateTime CreateTime { get; set; }

		public long ProjectId { get; set; }

		/// <summary>
		/// Who issued the task
		/// </summary>
		public User FromUser { get; set; }
		public long FromUserId { get; set; }

		/// <summary>
		/// To whom the task was issued
		/// </summary>
		[JsonIgnore]
		public IEnumerable<User>? ToUsers { get; set; }
		
	}
}
