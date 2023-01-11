using AutoMapper;
using InformCPISolution.Data;
using InformCPISolution.Domain.Dto;

namespace InformCPISolution.Mappers
{
    public class ContactsProfile : Profile
    {
        public ContactsProfile()
        {
            CreateMap<ContactModel, ContactDto>()
                .ReverseMap();
        }
    }
}
