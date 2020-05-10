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
            if (file != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    file.OpenReadStream().CopyTo(memoryStream);
                    byte[] Value = memoryStream.ToArray();
                    b64 = Convert.ToBase64String(Value);
                }
            }
            return b64;
        }

        public static string[] ImageToBase64(IFormFile file)
        {
            string[] array = null;
            if (file != null)
            {
                array = new string[2];
                array[0] = file.FileName.Split('.')[^1];
                using (var memoryStream = new MemoryStream())
                {
                    file.OpenReadStream().CopyTo(memoryStream);
                    byte[] Value = memoryStream.ToArray();
                    array[1] = Convert.ToBase64String(Value);
                }
            }
            return array;
        }
    }
}