using JackTrack.Entities.Users;

namespace JackTrack.Entities.ViewModels.Missions
{
    public class AddMissionViewModel
    {

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public long FromUserId { get; set; }

        public IEnumerable<long>? ToUsersIds { get; set; }
    }
}
