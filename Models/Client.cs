using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace ClientsApp.Models
{
    public class Client
    {
        public int Id { get; set; }
        
        //ИНН физлиц (ИП) состоит из 12 цифр, юрлиц (ЮЛ) — из 10
        [RegularExpression (@"[0-9]{12}|[0-9]{10}", ErrorMessage = "Incorrect TIN")]
        [Required(ErrorMessage = "Input TIN")]
        public long TIN { get; set; }
        
        [Required]
        [StringLength(30,ErrorMessage = "Length can't be more than 30.")]
        public string Name { get; set; }
        
        //<select name="type"> выпадающий список
        [Required]
        public string Type { get; set; }
        
        public static DateTime AddDate { get; set; }  = DateTime.Now;
        
        public DateTime UpdateDate { get; set; }
        
        public List<Founder> Founders { get; set; }
        
        public Client()
        {
            UpdateDate = DateTime.Now;
        }
    }
}