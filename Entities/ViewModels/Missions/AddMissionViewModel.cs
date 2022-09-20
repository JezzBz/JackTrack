using JackTrack.Entities.Users;
using MessagePack;
using Newtonsoft.Json;

namespace JackTrack.Entities.ViewModels.Missions
{
    public class AddMissionViewModel
    {

        public string? Name { get; set; }

        public string? Description { get; set; }

        public long ProjectId { get; set; }
        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }
        public DateTime? CreateTime { get; set; }


        public IEnumerable<long>? ToUsersIds { get; set; }

        [NonSerialized]
        public List<User>? ToUsers;
    }
}
