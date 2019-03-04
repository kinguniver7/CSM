using CSM.Domain.Entities.Clients;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSM.Domain.Interfaces.Clients
{
    public interface IClientRepository : IBaseRepository<Client, int>
    {
    }
}
