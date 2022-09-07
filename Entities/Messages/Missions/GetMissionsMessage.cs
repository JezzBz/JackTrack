namespace JackTrack.Entities.Messages.Missions
{
	public class GetMissionsMessage
	{
		public long ProjectId { get; set; }
		
		public Filters? Filters { get; set; }

	}
	public class Filters
	{
		public IEnumerable<long>? UserIds { get; set; }

		
	}


}
