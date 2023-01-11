using AutoMapper;
using InformCPISolution.Data;
using InformCPISolution.Domain.Contacts.Repository;
using InformCPISolution.Domain.Dto;
using Serilog;
using System.Diagnostics;

namespace InformCPISolution.Domain.Contacts.Services
{
    public class ContactServices : IContactServices
    {
        private readonly IContactRepository Repository;
        private readonly ILogger Logger;
        private readonly IMapper Mapper;

        public ContactServices(IContactRepository repository, ILogger logger, IMapper mapper)
        {
            Repository = repository;
            Logger = logger;
            Mapper = mapper;
        }

        public async Task AddContact(ContactDto contact)
        {
            if(contact != null)
            {
                try
                {
                    Logger.Information($"Adding contact: {contact.Name} into phonebook");

                    var model = Mapper.Map<ContactModel>(contact);

                    await Repository.AddContact(model);

                    Logger.Information($"Contact inserted into phonebook {contact.Name}");
                }
                catch (Exception e)
                {
                    Logger.Error($"Error inserting contact: {e}" + StackTrace.METHODS_TO_SKIP);
                }
            }
        }

        public async Task DeleteContact(int contactID)
        {
            if(contactID > 0)
            {
                try
                {
                    await Repository.DeleteContact(contactID);
                }
                catch (Exception e)
                {
                    Logger.Error($"Error deleting contact: {e}");
                }
            }
        }

        public async Task<ContactDto> GetContact(int contactID)
        {
            if(contactID > 0)
            {
                try
                {
                    var model = await Repository.GetContact(contactID);

                    var dto = Mapper.Map<ContactDto>(model);

                    return dto;
                }
                catch (Exception e)
                {
                    Logger.Error($"Error retrieving contact: {contactID} {e}" + StackTrace.METHODS_TO_SKIP);
                }
            }
            return null;
        }

        public async Task<List<ContactDto>> GetContacts()
        {
            try
            {
                Logger.Information($"Getting all contacts from phonebook");

                var model = await Repository.GetContacts();

                var dto = Mapper.Map<List<ContactDto>>(model);

                return dto;
            }
            catch (Exception e)
            {
                Logger.Error($"Error inserting contact: {e}" + StackTrace.METHODS_TO_SKIP);
            }

            return null;
        }

        public async Task UpdateContact(ContactDto contact)
        {
            if(contact != null)
            {
                try
                {
                    var model = Mapper.Map<ContactModel>(contact);

                    await Repository.UpdateContact(model);
                }
                catch (Exception e)
                {
                    Logger.Error($"Error updating contact: {e}");
                }
            }
        }
    }
}
