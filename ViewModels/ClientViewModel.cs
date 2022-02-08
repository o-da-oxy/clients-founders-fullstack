using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ClientsApp.Models;

namespace ClientsApp.ViewModels
{
    public class ClientViewModel : CreateClientViewModel
    {
        public int Id { get; set; }
        
        public List<Founder> Founders { get; set; }
        
    }
}