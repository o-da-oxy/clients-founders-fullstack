using System;
using System.ComponentModel.DataAnnotations;

namespace ClientsApp.Models
{
    public class Founder
    {
        public int Id { get; set; }
        
        //ИП - 12 цифр
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
        
        public static DateTime AddDate { get; set; }
        
        public DateTime UpdateDate { get; set; }
        
        public Client Client { get; set; }
        
        public int? ClientId { get; set; }
        
        public Founder()
        {
            UpdateDate = DateTime.Now;
        }
    }
}