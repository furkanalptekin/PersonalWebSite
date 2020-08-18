using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Logic.Extensions
{
    public static class Base64Extension
    {
        public static string PDFToBase64(this IFormFile file)
        {
            string b64 = null;
            if (file != null)
            {
                using var memoryStream = new MemoryStream();
                file.OpenReadStream().CopyTo(memoryStream);
                byte[] Value = memoryStream.ToArray();
                b64 = Convert.ToBase64String(Value);
            }
            return b64;
        }

        public static string ImageToBase64(this IFormFile file)
        {
            string b64 = null;
            if (file != null)
            {
                using var memoryStream = new MemoryStream();
                file.OpenReadStream().CopyTo(memoryStream);
                byte[] Value = memoryStream.ToArray();
                b64 = $"{file.FileName.Split('.')[^1]}|{Convert.ToBase64String(Value)}";
            }
            return b64;
        }
    }
}