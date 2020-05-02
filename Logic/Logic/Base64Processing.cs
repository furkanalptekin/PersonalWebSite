using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Logic
{
    public static class Base64Processing
    {
        public static string PDFToBase64(IFormFile file)
        {
            string b64 = null;
            using (var memoryStream = new MemoryStream())
            {
                file.OpenReadStream().CopyTo(memoryStream);
                byte[] Value = memoryStream.ToArray();
                b64 = Convert.ToBase64String(Value);
            }
            return b64;
        }
    }
}