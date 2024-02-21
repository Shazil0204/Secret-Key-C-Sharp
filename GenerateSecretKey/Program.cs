using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
	static void Main()
	{
		// Generate a random secret key
		string secretKey = GenerateSecretKey();

		Console.WriteLine("Generated Secret Key: " + secretKey);

		// Hash the secret key
		string hashedKey = HashSecretKey(secretKey);

		Console.WriteLine("Hashed Secret Key: " + hashedKey);

		Console.ReadKey();
	}

	static string GenerateSecretKey()
	{
		// Generate a random byte array
		byte[] randomBytes = new byte[32];
		using (var rng = new RNGCryptoServiceProvider())
		{
			rng.GetBytes(randomBytes);
		}

		// Convert the byte array to a string
		string secretKey = BitConverter.ToString(randomBytes).Replace("-", "").ToLower();

		return secretKey;
	}

	static string HashSecretKey(string secretKey)
	{
		// Create a SHA256 hash object
		using (SHA256 sha256 = SHA256.Create())
		{
			// Compute the hash of the secret key
			byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(secretKey));

			// Convert the byte array to a hexadecimal string
			StringBuilder builder = new StringBuilder();
			for (int i = 0; i < hashedBytes.Length; i++)
			{
				builder.Append(hashedBytes[i].ToString("x2"));
			}
			return builder.ToString();
		}
	}
}
