using CSM.Domain.Entities.Clients;
using CSM.Infrastructure.Data;
using CSM.Infrastructure.Data.Repositories.Clients;
using CSM.Services.Implementations.Clients;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CSM.Services.Tests.Clients
{
    public class ClientCRUDServiceTests
    {
        private string userId = Guid.NewGuid().ToString();
        
        #region Create

        [Fact]
        public async Task CreateWithoutAddress()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "CreateWithoutAddress")
                .Options;
            using (var context = new ApplicationDbContext(dbContextOptions))
            {
                var clientRepository = new ClientRepository(context);
                var service = new ClientService(clientRepository);
                var result = await service.CreateAsync(GetClientWithOutAddress());

                Assert.NotNull(result);
                Assert.Equal(1, await context.Clients.CountAsync());
                Assert.True(result.Id > 0);
            }
        }

        [Fact]
        public async Task CreateWithAddress()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "CreateWithAddress")
                .Options;

            using (var context = new ApplicationDbContext(dbContextOptions))
            {
                var clientRepository = new ClientRepository(context);
                var service = new ClientService(clientRepository);
                var result = await service.CreateAsync(GetClientWithAddress());

                Assert.NotNull(result);
                Assert.Equal(1, await context.Clients.CountAsync());
                Assert.True(result.Id > 0);

                Assert.NotNull(result.Address);
                Assert.Equal(1, await context.Addresses.CountAsync());
                Assert.True(result.AddressId > 0);
            }
        }

        #endregion

        #region Read
        [Fact]
        public async Task GetClientsByUserId()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "GetClientsByUserId")
                .Options;
            
            using (var context = new ApplicationDbContext(dbContextOptions))
            {
                var clientRepository = new ClientRepository(context);
                var service = new ClientService(clientRepository);
                await service.CreateAsync(GetClientWithAddress());
                await service.CreateAsync(GetClientWithAddress());
            }

            using (var context = new ApplicationDbContext(dbContextOptions))
            {
                var clientRepository = new ClientRepository(context);
                var service = new ClientService(clientRepository);
                var result = await service.GetClientsByUserIdAsync(userId);
                Assert.NotNull(result);
                Assert.Equal(2, result.Count);
                Assert.True(result.TrueForAll(c=>c.ApplicationUserId==userId));
            }
        }

        [Fact]
        public async Task GetClientById()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "GetClientById")
                .Options;
            Client client;
            using (var context = new ApplicationDbContext(dbContextOptions))
            {
                var clientRepository = new ClientRepository(context);
                var service = new ClientService(clientRepository);
                client = await service.CreateAsync(GetClientWithAddress());
                await service.CreateAsync(GetClientWithAddress());
                await service.CreateAsync(GetClientWithAddress());
            }

            using (var context = new ApplicationDbContext(dbContextOptions))
            {
                var clientRepository = new ClientRepository(context);
                var service = new ClientService(clientRepository);
                var findClient = await service.GetClientByIdAsync(client.Id);

                Assert.NotNull(findClient);
                Assert.Equal(findClient.Id, client.Id);
            }
        }
        #endregion

        #region Update
        [Fact]
        public async Task EditClient()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "EditClient")
                .Options;
            Client client = GetClientWithAddress();
            Client modClient;
            Client foundClient;

            string oldFirstName = client.FirstName;
            string oldLastName = client.LastName;
            string oldCompany = client.Company;
            string oldApplicationUserId = client.ApplicationUserId;

            string newFirstName = "newFirstName";
            string newLastName = "newLastName";
            string newCompany = "newCompany";
            string newApplicationUserId = Guid.NewGuid().ToString();

            using (var context = new ApplicationDbContext(dbContextOptions))
            {
                var clientRepository = new ClientRepository(context);
                var service = new ClientService(clientRepository);
                await service.CreateAsync(client);
            }

            using (var context = new ApplicationDbContext(dbContextOptions))
            {
                var clientRepository = new ClientRepository(context);
                var service = new ClientService(clientRepository);
                

                client.FirstName = newFirstName;
                client.LastName = newLastName;
                client.Company = newCompany;
                client.ApplicationUserId = newApplicationUserId;

                modClient = await service.EditAsync(client);
                foundClient = await service.GetClientByIdAsync(client.Id);
            }

            //For mod client
            Assert.NotNull(modClient);

            Assert.Equal(modClient.FirstName, newFirstName);
            Assert.Equal(modClient.LastName, newLastName);
            Assert.Equal(modClient.Company, newCompany);

            Assert.NotEqual(modClient.FirstName, oldFirstName);
            Assert.NotEqual(modClient.LastName, oldLastName);
            Assert.NotEqual(modClient.Company, oldCompany);

            //For found client after edit
            Assert.NotNull(foundClient);

            Assert.Equal(foundClient.FirstName, newFirstName);
            Assert.Equal(foundClient.LastName, newLastName);
            Assert.Equal(foundClient.Company, newCompany);

            Assert.NotEqual(foundClient.FirstName, oldFirstName);
            Assert.NotEqual(foundClient.LastName, oldLastName);
            Assert.NotEqual(foundClient.Company, oldCompany);
        }
        #endregion

        #region Delete
        [Fact]
        public async Task DeleteClientById()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "DeleteClientById")
                .Options;
            Client client = GetClientWithAddress();
            Client foundClient;
            int count = 0;
            
            using (var context = new ApplicationDbContext(dbContextOptions))
            {
                var clientRepository = new ClientRepository(context);
                var service = new ClientService(clientRepository);
                await service.CreateAsync(client);                
            }
            //Delete
            using (var context = new ApplicationDbContext(dbContextOptions))
            {
                var clientRepository = new ClientRepository(context);
                var service = new ClientService(clientRepository);
                service.DeleteById(client.Id);
            }

            using (var context = new ApplicationDbContext(dbContextOptions))
            {
                var clientRepository = new ClientRepository(context);
                var service = new ClientService(clientRepository);
                count = await context.Clients.CountAsync();
                foundClient = await service.GetClientByIdAsync(client.Id);                
            }

            Assert.Null(foundClient);
            Assert.Equal(0, count);
        }
        #endregion

        private Client GetClientWithOutAddress()
        {
            return new Client {
                FirstName = "Fname",
                LastName = "Lname",
                Company = "CompT",
                ApplicationUserId = userId
            };
        }

        private Client GetClientWithAddress()
        {
            var client = GetClientWithOutAddress();
            client.Address = new Address
            {
                City = "TestS",
                Country = "TestC",
                Street = "TestSt",
                ZipCode = 11111
            };
            return client;
        }
    }
}
