using Newtonsoft.Json;

namespace JackTrack.Extensions
{
	public static class SessionExtension
	{
		public static void SetObjectInSession<T>(this ISession session, string key, T value)
		{
			session.SetString(key, JsonConvert.SerializeObject(value));
		}

		public static T GetSessionObject<T>(this ISession session, string key)
		{
			var value = session.GetString(key);
			return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
		}
	}
}
