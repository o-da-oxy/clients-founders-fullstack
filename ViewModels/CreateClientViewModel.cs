using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClientsApp.ViewModels
{
    public class CreateClientViewModel
    {
        [RegularExpression (@"[0-9]{12}|[0-9]{10}", ErrorMessage = "Incorrect TIN")]
        [Required(ErrorMessage = "Input TIN")]
        public long TIN { get; set; }
        
        [Required]
        [StringLength(30,ErrorMessage = "Length can't be more than 30.")]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }
    }
}