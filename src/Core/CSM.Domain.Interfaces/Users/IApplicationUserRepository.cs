using CSM.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSM.Domain.Interfaces.Users
{
    public interface IApplicationUserRepository : IBaseRepository<ApplicationUser, int>
    {
        /// <summary>
        /// Get application user by user name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        ApplicationUser GetApplicationUserByName(string name);
    }
}
