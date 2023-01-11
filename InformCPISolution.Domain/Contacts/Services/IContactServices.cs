using InformCPISolution.Domain.Dto;

namespace InformCPISolution.Domain.Contacts.Services
{
    public interface IContactServices
    {
        Task<List<ContactDto>> GetContacts();
        Task<ContactDto> GetContact(int contactID);
        Task AddContact(ContactDto contact);
        Task UpdateContact(ContactDto contact);
        Task DeleteContact(int contactID);
    }
}