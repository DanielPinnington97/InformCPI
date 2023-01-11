using InformCPISolution.Data;
using InformCPISolution.Domain.Dto;

namespace InformCPISolution.Domain.Contacts.Repository
{
    public interface IContactRepository
    {
        Task<List<ContactModel>> GetContacts();
        Task<ContactModel> GetContact(int contactID);
        Task AddContact(ContactModel contact);
        Task UpdateContact(ContactModel contact);
        Task DeleteContact(int contactID);
    }
}