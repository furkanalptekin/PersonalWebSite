using DB.Models;
using Microsoft.AspNetCore.Http;

namespace DB.ViewModels
{
    public class CvFileModel
    {
        public Cv Cv { get; set; }
        public IFormFile File { get; set; }
    }
}