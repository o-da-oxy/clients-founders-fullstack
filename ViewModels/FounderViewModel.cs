using System;
using System.ComponentModel.DataAnnotations;
using ClientsApp.Models;

namespace ClientsApp.ViewModels
{
    public class FounderViewModel
    {
        public int Id { get; set; }
        
        [RegularExpression (@"[0-9]{12}", ErrorMessage = "Incorrect TIN")]
        [Required(ErrorMessage = "Input TIN")]
        public long TIN { get; set; }
        
        [Required]
        [StringLength(30,ErrorMessage = "Length can't be more than 30.")]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(30,ErrorMessage = "Length can't be more than 30.")]
        public string LastName { get; set; }
        
        [Required]
        [StringLength(30,ErrorMessage = "Length can't be more than 30.")]
        public string Patronymic { get; set; }
        
        public Client Client { get; set; }
        
        public int ClientId { get; set; }
    }
}