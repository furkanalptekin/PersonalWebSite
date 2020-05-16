using DB.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace DB.ViewModels
{
    public class PersonViewModel
    {
        public Kisi Kisi { get; set; }
        public IFormFile File { get; set; }
        public List<string> Ehliyetler { get; set; }
    }
}