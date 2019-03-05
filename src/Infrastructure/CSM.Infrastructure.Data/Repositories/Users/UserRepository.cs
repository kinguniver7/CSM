using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSM.Domain.Entities.Users;
using CSM.Domain.Interfaces.Users;

namespace CSM.Infrastructure.Data.Repositories.Users
{
    public class ApplicationUserRepository : BaseRepository<ApplicationUser, int>, IApplicationUserRepository
    {
        public ApplicationUserRepository(ApplicationDbContext dbContext) : base(dbContext, dbContext.Users)
        {
        }

        /// <summary>
        /// Get application user by user name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ApplicationUser GetApplicationUserByName(string name)
        {
            return Entities.FirstOrDefault(c => c.UserName.ToLower() == name.ToLower());
        }
    }
}
