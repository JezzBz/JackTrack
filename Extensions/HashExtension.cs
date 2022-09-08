using static System.Net.Mime.MediaTypeNames;
using System.Text;
using System.Security.Cryptography;

namespace JackTrack.Extensions
{
	public static class HashExtension
	{
		public static string Hash(this string row)
		{
			using (SHA256 sha256Hash = SHA256.Create())
			{
				byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(row));
 
				StringBuilder builder = new StringBuilder();
				for (int i = 0; i < bytes.Length; i++)
				{
					builder.Append(bytes[i].ToString("x2"));
				}
				return builder.ToString();
			}
		}
	}
}
