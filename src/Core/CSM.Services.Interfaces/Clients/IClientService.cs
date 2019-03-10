using CSM.Domain.Entities.Clients;
using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Edit the client
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        Task<Client> EditAsync(Client client);

        /// <summary>
        /// Delete client by id
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        void DeleteById(int clientId);

        /// <summary>
        /// Get client by clientId
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        Task<Client> GetClientByIdAsync(int clientId);

        /// <summary>
        /// Get clients by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IList<Client>> GetClientsByUserIdAsync(string userId);
    }
}
