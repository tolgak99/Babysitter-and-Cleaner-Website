using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace ceng382_project3.Models
{
    public class FileUpload
    {
        [Required]
        [Display(Name = "Profile Picture")]
        public IFormFile FormFile { get; set; }
    }
}
