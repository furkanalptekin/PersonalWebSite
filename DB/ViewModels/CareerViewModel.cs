using DB.Models;
using Microsoft.AspNetCore.Http;

namespace DB.ViewModels
{
    public class CareerViewModel : MeslekiDeneyim
    {
        public IFormFile IconFile { get; set; }
    }
}