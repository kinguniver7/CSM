using CSM.Domain.Entities.Clients;
using CSM.Domain.Interfaces.Clients;
using CSM.Services.Interfaces.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.Services.Implementations.Clients
{
    /// <summary>
    /// Contact service
    /// </summary>
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
        }

        /// <summary>
        /// Create new contact
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public async Task<Contact> CreateAsync(Contact contact)
        {
            _contactRepository.Add(contact, true);
            return contact;
        }

        /// <summary>
        /// Edit contact
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public async Task<Contact> EditAsync(Contact contact)
        {
            var oldContact = await _contactRepository.FindAsync(contact.Id);

            oldContact.Name = contact.Name;
            oldContact.Type = contact.Type;
            oldContact.Value = contact.Value;

            _contactRepository.SaveChanges();

            return oldContact;
        }

        /// <summary>
        /// Delete contact by contact id
        /// </summary>
        /// <param name="contactId"></param>
        public void DeleteById(int contactId)
        {
            _contactRepository.Delete(contactId, true);
        }

        /// <summary>
        /// Get contact by id
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public async Task<Contact> GetContactByIdAsync(int contactId)
        {
            return await _contactRepository.FindAsync(contactId);
        }

        /// <summary>
        /// Get contacts by client id
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public async Task<IList<Contact>> GetContactsByClientIdAsync(int clientId)
        {
            return _contactRepository.Get().Where(c => c.ClientId == clientId).ToList();            
        }
    }
}
