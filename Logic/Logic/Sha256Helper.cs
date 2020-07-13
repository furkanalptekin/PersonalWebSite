using System.Security.Cryptography;
using System.Text;

namespace Logic
{
    public static class Sha256Helper
    {
        public static string Hash(string Data)
        {
            string hash = null;
            if (Data != null)
            {
                using SHA256 sha = SHA256.Create();
                StringBuilder builder = new StringBuilder();
                var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(Data));
                for (int i = 0; i < bytes.Length; i++)
                    builder.Append(bytes[i].ToString("x2"));

                hash = builder.ToString();
            }
            return hash;
        }
    }
}