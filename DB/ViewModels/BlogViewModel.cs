using DB.Models;
using Microsoft.AspNetCore.Http;

namespace DB.ViewModels
{
    public class BlogViewModel
    {
        public Blog Blog { get; set; }
        public IFormFile File { get; set; }
    }
}