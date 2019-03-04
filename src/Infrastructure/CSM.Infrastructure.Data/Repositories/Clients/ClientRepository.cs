using System;
using System.Collections.Generic;
using System.Text;
using CSM.Domain.Entities.Clients;
using CSM.Domain.Interfaces.Clients;

namespace CSM.Infrastructure.Data.Repositories.Clients
{
    public class ClientRepository : BaseRepository<Client, int>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext dbContext) : base(dbContext, dbContext.Clients)
        {
        }
    }
}
