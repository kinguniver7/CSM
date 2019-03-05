using CSM.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSM.Services.Interfaces.Users
{
    public interface IApplicationUserService 
    {
        /// <summary>
        /// Get application user by name
        /// </summary>
        /// <param name="name">User name</param>
        /// <returns></returns>
        ApplicationUser GetApplicationUserByName(string name);
    }
}
