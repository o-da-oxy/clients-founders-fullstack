using AutoMapper;
using ClientsApp.Models;

namespace ClientsApp.ViewModels.AutoMapperProfiles
{
    public class FounderProfile : Profile
    {
        public FounderProfile()
        {
            CreateMap<Founder, FounderViewModel>().ReverseMap();
            CreateMap<Client, ClientViewModel>().ReverseMap();
        }
    }
}