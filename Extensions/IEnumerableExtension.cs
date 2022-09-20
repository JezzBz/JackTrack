using System.Security.Claims;

namespace JackTrack.Extensions
{
	public static class IEnumerableExtension
	{
		public static string GetEmail(this IEnumerable<Claim> claims) => claims.FirstOrDefault(q => q.Type == ClaimTypes.Email).Value;
		
		public static long GetId(this IEnumerable<Claim> claims) => long.Parse(claims.FirstOrDefault(q => q.Type == ClaimTypes.NameIdentifier).Value);

	}

}
