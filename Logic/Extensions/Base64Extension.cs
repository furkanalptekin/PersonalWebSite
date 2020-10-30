using DB.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Logic.Extensions
{
    public static class Base64Extension
    {
        /// <summary>
        /// <see cref="IFormFile"/> nesnesini Base64'e çevirir.
        /// </summary>
        /// <param name="file"></param>
        /// <returns>Dosya Uzantısı|Base64 olarak <see cref="string"/> geri döner.</returns>
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

        /// <summary>
        /// Kayıtlı olan dosyayı base64'e çevirir.
        /// </summary>
        /// <param name="cv"></param>
        /// <param name="wwwrootPath"></param>
        /// <returns></returns>
        public static string CvToBase64(this Cv cv, string wwwrootPath)
        {
            string b64 = null;

            if (cv != null)
            {
                using var memoryStream = new MemoryStream();
                var file = new FileStream($"{wwwrootPath}\\{cv.FilePath}", FileMode.Open);
                file.CopyTo(memoryStream);
                byte[] Value = memoryStream.ToArray();
                b64 = Convert.ToBase64String(Value);
                file.Close();
                memoryStream.Dispose();
            }
            return b64;
        }
    }
}