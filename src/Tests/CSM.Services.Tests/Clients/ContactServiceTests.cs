using CSM.Domain.Entities.Clients;
using CSM.Infrastructure.Data;
using CSM.Infrastructure.Data.Repositories.Clients;
using CSM.Services.Implementations.Clients;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CSM.Services.Tests.Clients
{
    public class ContactServiceTests
    {
        private string userId = Guid.NewGuid().ToString();

        #region Create

        [Fact]
        public async Task CreateContact()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "ContactServiceTests_CreateContact")
                .Options;

            using (var context = new ApplicationDbContext(dbContextOptions))
            {
                var contactRepository = new ContactRepository(context);
                var service = new ContactService(contactRepository);
                var result = await service.CreateAsync(FakeDataForClients.GetContactEmail());

                Assert.NotNull(result);
                Assert.Equal(1, await context.Contacts.CountAsync());
                Assert.True(result.Id > 0);
            }
        }
        #endregion

        #region Read

        [Fact]
        public async Task GetContactsByClientId()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "ContactServiceTests_GetContactsByClientId")
                .Options;
            var client = FakeDataForClients.GetClientWithOutAddress();
            var contact1 = FakeDataForClients.GetContactEmail();
            contact1.ClientId = client.Id;
            var contact2 = FakeDataForClients.GetContactEmail();
            contact2.ClientId = client.Id;

            using (var context = new ApplicationDbContext(dbContextOptions))
            {
                var contactRepository = new ContactRepository(context);
                var service = new ContactService(contactRepository);
                await service.CreateAsync(contact1);
                await service.CreateAsync(contact2);
            }

            using (var context = new ApplicationDbContext(dbContextOptions))
            {
                var contactRepository = new ContactRepository(context);
                var service = new ContactService(contactRepository);
                var result = await service.GetContactsByClientIdAsync(client.Id);
                Assert.NotNull(result);
                Assert.Equal(2, result.Count);
                Assert.True(result.All(c => c.ClientId == client.Id));
            }
        }
        #endregion

        #region Update
        [Fact]
        public async Task EditContact()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "ContactServiceTests_EditContact")
                .Options;
            //Client client = FakeDataForClients.GetClientWithAddress();
            Contact contact = FakeDataForClients.GetContactEmail();

            Contact modContact;
            Contact foundContact;

            string oldName = contact.Name;
            ContactType oldType = contact.Type;
            string oldValue = contact.Value;

            string newName = "Phone";
            ContactType newType = ContactType.Phone;
            string newValue = "+38099-999-99-99";

            //Create
            using (var context = new ApplicationDbContext(dbContextOptions))
            {
                //var clientRepository = new ClientRepository(context);
                //var service = new ClientService(clientRepository);

                var contactRepository = new ContactRepository(context);
                var service = new ContactService(contactRepository);
                await service.CreateAsync(contact);
            }

            using (var context = new ApplicationDbContext(dbContextOptions))
            {
                var contactRepository = new ContactRepository(context);
                var service = new ContactService(contactRepository);

                contact.Name = newName;
                contact.Type = newType;
                contact.Value = newValue;

                modContact = await service.EditAsync(contact);
                foundContact = await service.GetContactByIdAsync(contact.Id);
            }

            //For mod client
            Assert.NotNull(modContact);

            Assert.Equal(modContact.Name, newName);
            Assert.Equal(modContact.Type, newType);
            Assert.Equal(modContact.Value, newValue);

            Assert.NotEqual(modContact.Name, oldName);
            Assert.NotEqual(modContact.Type, oldType);
            Assert.NotEqual(modContact.Value, oldValue);

            //For found client after edit
            Assert.NotNull(foundContact);

            Assert.Equal(foundContact.Name, newName);
            Assert.Equal(foundContact.Type, newType);
            Assert.Equal(foundContact.Value, newValue);

            Assert.NotEqual(foundContact.Name, oldName);
            Assert.NotEqual(foundContact.Type, oldType);
            Assert.NotEqual(foundContact.Value, oldValue);
        }
        #endregion

        #region Delete
        [Fact]
        public async Task DeleteContactById()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "ContactServiceTests_DeleteContactById")
                .Options;
            Contact contact = FakeDataForClients.GetContactEmail();
            Contact foundContact;
            int count = 0;

            //Create
            using (var context = new ApplicationDbContext(dbContextOptions))
            {
                var contactRepository = new ContactRepository(context);
                var service = new ContactService(contactRepository);
                await service.CreateAsync(contact);
            }
            //Delete
            using (var context = new ApplicationDbContext(dbContextOptions))
            {
                var contactRepository = new ContactRepository(context);
                var service = new ContactService(contactRepository);
                service.DeleteById(contact.Id);
            }

            using (var context = new ApplicationDbContext(dbContextOptions))
            {
                var contactRepository = new ContactRepository(context);
                var service = new ContactService(contactRepository);
                count = await context.Contacts.CountAsync();
                foundContact = await service.GetContactByIdAsync(contact.Id);
            }

            Assert.Null(foundContact);
            Assert.Equal(0, count);
        }
        #endregion

    }
}
