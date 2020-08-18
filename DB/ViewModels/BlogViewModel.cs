using DB.Models;
using Microsoft.AspNetCore.Http;

namespace DB.ViewModels
{
    public class BlogViewModel : Blog
    {
        public IFormFile FotoFile { get; set; }
    }
}