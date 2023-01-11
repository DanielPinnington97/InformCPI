using InformCPISolution.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace InformCPISolution.Domain.Contacts.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly InformCPIDBContext Context;
        private readonly ILogger Logger;

        public ContactRepository(InformCPIDBContext dbContext, ILogger logger)
        {
            Context = dbContext;
            Logger = logger;
        }

        public ContactRepository()
        {
        }

        public async Task AddContact(ContactModel contact)
        {
            if(contact != null)
            {
                try
                {
                    Context.Add(contact);

                    await Context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Logger.Error($"Error adding contact: {e}");
                }
            }
        }

        public async Task DeleteContact(int contactID)
        {
            if(contactID > 0)
            {
                try
                {
                    ContactModel contact = await GetContact(contactID);

                    Context.Remove(contact);

                    await Context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Logger.Error($"Error deleting contact: {e}");
                }
            }
        }

        public async Task<ContactModel> GetContact(int contactID)
        {
            if (contactID > 0)
            {
                try
                {
                    var model = await Context.FindAsync<ContactModel>(contactID);

                    return model;
                }
                catch (Exception e)
                {
                    Logger.Error($"Error deleting contact: {e}");
                }
            }

            return null;
        }

        public async Task<List<ContactModel>> GetContacts()
        {
            try
            {
                var model = await Context.Contacts.ToListAsync();

                return model;
            }
            catch (Exception e)
            {
                Logger.Error($"Error deleting contact: {e}");
            }

            return null;
        }

        public async Task UpdateContact(ContactModel contact)
        {
            if(contact != null)
            {
                try
                {
                    Context.Update(contact);

                    await Context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Logger.Error($"Error updating contact: {e}");

                }
            }
        }
    }
}
