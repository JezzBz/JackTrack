namespace JackTrack.Entities.Http
{
	public class ServerResponse
	{
		 public ServerResponse(object data = null, string error = null )
		{
			Data = data;
			Error = error;
		}
		public object Data { get; set; }

		public string? Error { get; set; }

	}
}
