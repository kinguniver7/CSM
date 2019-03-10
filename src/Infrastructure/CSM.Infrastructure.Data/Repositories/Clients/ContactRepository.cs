using CSM.Domain.Entities.Clients;
using CSM.Domain.Interfaces.Clients;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSM.Infrastructure.Data.Repositories.Clients
{
    public class ContactRepository : BaseRepository<Contact, int>, IContactRepository
    {
        public ContactRepository(ApplicationDbContext dbContext) : base(dbContext, dbContext.Contacts)
        {
        }
    }
}
