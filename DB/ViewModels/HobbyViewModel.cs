using DB.Models;
using Microsoft.AspNetCore.Http;

namespace DB.ViewModels
{
    public class HobbyViewModel
    {
        public Hobiler Hobiler { get; set; }
        public IFormFile Icon { get; set; }
    }
}
