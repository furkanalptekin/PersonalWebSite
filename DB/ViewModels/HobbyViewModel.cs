using DB.Models;
using Microsoft.AspNetCore.Http;

namespace DB.ViewModels
{
    public class HobbyViewModel : Hobiler
    {
        public IFormFile IconFile { get; set; }
    }
}