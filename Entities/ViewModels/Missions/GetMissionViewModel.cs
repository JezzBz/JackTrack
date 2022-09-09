using JackTrack.Entities.Users;
using Newtonsoft.Json;

namespace JackTrack.Entities.ViewModels.Missions
{
	public class GetMissionViewModel
	{
		public long Id { get; set; }


		public string? Name { get; set; }

		public string? Description { get; set; }

		public DateTime? StartTime { get; set; }

		public DateTime? EndTime { get; set; }

		public DateTime CreateTime { get; set; }

		public long ProjectId { get; set; }
		public long FromUserId { get; set; }

		public IEnumerable<long> ToUsersIds { get; set; }

	}
}
