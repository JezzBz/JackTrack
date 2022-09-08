using JackTrack.Entities.Users;
using Newtonsoft.Json;

namespace JackTrack.Extensions
{
	public static class SessionExtension
	{
		public static void SetObject<T>(this ISession session, string key, T value)
		{
			session.SetString(key, JsonConvert.SerializeObject(value));
		}

		public static T GetObject<T>(this ISession session, string key)
		{
			var value = session.GetString(key);
			return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
		}

		public static User? GetUser(this ISession session)
		{
			return GetObject<User>(session,"User");
		}
	}
}
