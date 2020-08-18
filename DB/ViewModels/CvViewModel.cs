using DB.Models;
using Microsoft.AspNetCore.Http;

namespace DB.ViewModels
{
    public class CvViewModel : Cv
    {
        public IFormFile File { get; set; }
    }
}