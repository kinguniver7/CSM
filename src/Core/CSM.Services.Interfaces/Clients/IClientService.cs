using CSM.Domain.Entities.Clients;
using System;
using System.Threading.Tasks;

namespace CSM.Services.Interfaces.Clients
{
    public interface IClientService
    {
        /// <summary>
        /// Create new client
        /// </summary>
        /// <param name="client">Client entity</param>
        /// <returns></returns>
       Task<Client> CreateAsync(Client client);
    }
}
