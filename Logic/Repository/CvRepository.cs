using DB.Models;
using Logic.Extensions;
using Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Logic.Repository
{
    public class CvRepository : Repository<Cv>, ICvRepository
    {
        public override bool Add(Cv model, params object[] parameters)
        {
            if (parameters.Length == 0)
                return false;

            var anonymousType = parameters[0];
            var File = anonymousType.GetType().GetProperty("File").GetValue(anonymousType);
            var FolderName = anonymousType.GetType().GetProperty("FolderName").GetValue(anonymousType).ToString();
            var wwwrootPath = anonymousType.GetType().GetProperty("wwwrootPath").GetValue(anonymousType).ToString();
            string[] AllowedFileExtensions = { "pdf" };
            var filePath = ((IFormFile)File).CopyFile(wwwrootPath, FolderName, AllowedFileExtensions);

            if (filePath != null)
            {
                model.FilePath = filePath;
                return _context.AddEntity(model) > 0;
            }
            return false;
        }
    }
}