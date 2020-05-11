using DB.Models;
using Microsoft.AspNetCore.Http;

namespace DB.ViewModels
{
    public class CareerViewModel
    {
        public MeslekiDeneyim MeslekiDeneyim { get; set; }
        public IFormFile Icon { get; set; }
    }
}