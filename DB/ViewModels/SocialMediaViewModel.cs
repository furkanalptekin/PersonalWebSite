using DB.Models;
using Microsoft.AspNetCore.Http;

namespace DB.ViewModels
{
    public class SocialMediaViewModel : SosyalMedya
    {
        public IFormFile IconFile { get; set; }
    }
}