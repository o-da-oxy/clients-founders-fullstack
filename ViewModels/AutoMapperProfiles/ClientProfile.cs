using AutoMapper;
using ClientsApp.Models;

namespace ClientsApp.ViewModels.AutoMapperProfiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientViewModel>().ReverseMap();
            CreateMap<Client, CreateClientViewModel>().ReverseMap();
            CreateMap<Client, EditClientViewModel>().ReverseMap();
            CreateMap<ClientViewModel, EditClientViewModel>().ReverseMap();
            CreateMap<CreateClientViewModel, EditClientViewModel>().ReverseMap();
        }
    }
}