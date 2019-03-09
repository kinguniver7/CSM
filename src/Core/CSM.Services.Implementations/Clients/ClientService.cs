using CSM.Services.Interfaces.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSM.Domain.Entities.Clients;
using CSM.Domain.Interfaces.Clients;
using Microsoft.EntityFrameworkCore;

namespace CSM.Services.Implementations.Clients
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        }

        /// <summary>
        /// Create new client
        /// </summary>
        /// <param name="client">Client entity</param>
        /// <returns></returns>
        public async Task<Client> CreateAsync(Client client)
        {
            await _clientRepository.AddAsync(client, true);
            return client;
        }

        /// <summary>
        /// Edit the client
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public async Task<Client> EditAsync(Client client)
        {
            var oldClient = await _clientRepository.FindAsync(client.Id);

            oldClient.FirstName = client.FirstName;
            oldClient.LastName = client.LastName;
            oldClient.Company = client.Company;
            //oldClient.ApplicationUserId = client.ApplicationUserId;
            _clientRepository.SaveChanges();

            return oldClient;
        }

        /// <summary>
        /// Delete client by id
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public void DeleteById(int clientId)
        {
            _clientRepository.Delete(clientId,true);
        }

        /// <summary>
        /// Get client by clientId
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public async Task<Client> GetClientByIdAsync(int clientId)
        {
            return await _clientRepository.FindAsync(clientId);
        }

        /// <summary>
        /// Get clients by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<Client>> GetClientsByUserIdAsync(string userId)
        {
            return await _clientRepository.Get().Where(c => c.ApplicationUserId == userId).ToListAsync();
        }
    }
}
