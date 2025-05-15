using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace GestionaleFatturaPA.Service.Security
{
	public class AESService
	{
		private static readonly byte[] key = Encoding.UTF8.GetBytes("0001028304051996");
		private static readonly byte[] iv = Encoding.UTF8.GetBytes("1011121394152507");

		public static string Encrypt(string plainText)
		{
			return Convert.ToBase64String(EncryptStringToBytes(plainText));
		}

		public static string Decrypt(string cipherText)
		{
			var encrypted = Convert.FromBase64String(cipherText);
			return DecryptStringFromBytes(encrypted);
		}

		private static string DecryptStringFromBytes(byte[] cipherText)
		{
			// Check arguments.
			if (cipherText == null || cipherText.Length <= 0)
			{
				throw new ArgumentNullException("cipherText");
			}
			if (key == null || key.Length <= 0)
			{
				throw new ArgumentNullException("key");
			}
			if (iv == null || iv.Length <= 0)
			{
				throw new ArgumentNullException("key");
			}

			string plaintext = null;

			using (var rijAlg = new RijndaelManaged())
			{

				rijAlg.Mode = CipherMode.CBC;
				rijAlg.Padding = PaddingMode.PKCS7;
				rijAlg.FeedbackSize = 128;

				rijAlg.Key = key;
				rijAlg.IV = iv;


				var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
				try
				{
					using (var msDecrypt = new MemoryStream(cipherText))
					{
						using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
						{

							using (var srDecrypt = new StreamReader(csDecrypt))
							{
								plaintext = srDecrypt.ReadToEnd();

							}

						}
					}
				}
				catch
				{
					plaintext = "keyError";
				}
			}

			return plaintext;
		}

		private static byte[] EncryptStringToBytes(string plainText)
		{
			// Check arguments.
			if (plainText == null || plainText.Length <= 0)
			{
				throw new ArgumentNullException("plainText");
			}
			if (key == null || key.Length <= 0)
			{
				throw new ArgumentNullException("key");
			}
			if (iv == null || iv.Length <= 0)
			{
				throw new ArgumentNullException("key");
			}
			byte[] encrypted;
			// Create a RijndaelManaged object
			// with the specified key and IV.
			using (var rijAlg = new RijndaelManaged())
			{
				rijAlg.Mode = CipherMode.CBC;
				rijAlg.Padding = PaddingMode.PKCS7;
				rijAlg.FeedbackSize = 128;

				rijAlg.Key = key;
				rijAlg.IV = iv;

				// Create a decrytor to perform the stream transform.
				var encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

				// Create the streams used for encryption.
				using (var msEncrypt = new MemoryStream())
				{
					using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
					{
						using (var swEncrypt = new StreamWriter(csEncrypt))
						{
							//Write all data to the stream.
							swEncrypt.Write(plainText);
						}
						encrypted = msEncrypt.ToArray();
					}
				}
			}

			// Return the encrypted bytes from the memory stream.
			return encrypted;
		}

		private static string Setting(IConfiguration config, string Key)
		{
			return AESService.Decrypt(config.GetConnectionString(Key));
		}

		static Type GetSettingAsType<Type>(object obj, Func<object, Type> callerConverter)
		{

			if (obj != null)
			{
				Type value = default(Type);
				try
				{
					value = callerConverter(obj);
				}
				catch
				{
					value = default(Type);
				}
				return value;
			}
			else
				return default(Type);
		}

		public static int GetSettingAsInteger(IConfiguration config, string key)
		{
			return GetSettingAsType<int>(Setting(config,key), obj => Convert.ToInt32(obj));
		}
		public static string GetSettingAsString(IConfiguration config, string key)
		{
			return GetSettingAsType<string>(Setting(config, key), obj => Convert.ToString(obj));
		}
		public static bool? GetSettingAsBool(IConfiguration config,string key)
		{
			return GetSettingAsType<bool?>(Setting(config, key), obj => Convert.ToBoolean(obj));
		}

	}
}
