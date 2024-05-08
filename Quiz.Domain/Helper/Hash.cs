using System.Security.Cryptography;
using System.Text;

namespace Quiz.WebUI.Helper
{
	public static class Hash
	{
		public static string GenerateHash(this string value)
		{
			var crypt = SHA1.Create();
			var encode = new ASCIIEncoding();
			var array = encode.GetBytes(value);

			array = crypt.ComputeHash(array);

			var strHexa = new StringBuilder();

			foreach (var item in array)
			{
				strHexa.Append(item.ToString("x2"));
			}

			return strHexa.ToString();
		}
	}
}
