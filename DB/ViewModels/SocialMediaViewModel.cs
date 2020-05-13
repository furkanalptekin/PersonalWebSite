using DB.Models;
using Microsoft.AspNetCore.Http;

namespace DB.ViewModels
{
    public class SocialMediaViewModel
    {
        public SosyalMedya SosyalMedya { get; set; }
        public IFormFile Icon { get; set; }
    }
}
