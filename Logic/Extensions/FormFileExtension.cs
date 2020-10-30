using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Logic.Extensions
{
    public static class FormFileExtension
    {
        /// <summary>
        /// <see cref="IFormFile"/> nesnesini rasgele bir isim ile kayıt eder. 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="wwwrootPath"></param>
        /// <param name="FolderName"></param>
        /// <param name="AllowedFileExtensions"></param>
        /// <returns>Dosya yolunu <see cref="string"/> olarak geri döner.</returns>
        public static string CopyFile(this IFormFile file, string wwwrootPath, string FolderName, string[] AllowedFileExtensions)
        {
            if (file.Length <= 0)
                return null;
            
            var fileExtension = file.FileName.Split('.')[^1].ToLower(new CultureInfo("en"));
            if (!AllowedFileExtensions.Contains(fileExtension))
                return null;

            var randomFileName = Path.GetRandomFileName();
            var filePath = $"Files\\{FolderName}\\{randomFileName}.{fileExtension}";
            var fullPath = $"{wwwrootPath}\\{filePath}";
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return filePath;
        }
    }
}