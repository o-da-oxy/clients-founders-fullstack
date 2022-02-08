using System;
using System.ComponentModel.DataAnnotations;
using ClientsApp.Models;

namespace ClientsApp.ViewModels
{
    public class GetClientViewModel : CreateClientViewModel
    {
        public Client Client { get; set; }
    }
}
    