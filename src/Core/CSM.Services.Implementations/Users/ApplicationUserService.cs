using CSM.Domain.Entities.Users;
using CSM.Domain.Interfaces.Users;
using CSM.Services.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSM.Services.Implementations.Users
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IApplicationUserRepository _applicationUserRepository;

        public ApplicationUserService(IApplicationUserRepository applicationUserRepository)
        {
            _applicationUserRepository = applicationUserRepository ?? throw new ArgumentNullException(nameof(applicationUserRepository));
        }

        /// <summary>
        /// Get application user by name
        /// </summary>
        /// <param name="name">User name</param>
        /// <returns></returns>
        public ApplicationUser GetApplicationUserByName(string name)
        {
            return _applicationUserRepository.GetApplicationUserByName(name);            
        }
    }
}
