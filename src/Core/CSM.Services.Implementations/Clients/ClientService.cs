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

        public async Task<List<Client>> GetClientsByUserId(string userId)
        {
            return await _clientRepository.Get().Where(c => true).ToListAsync();
        }
    }
}
