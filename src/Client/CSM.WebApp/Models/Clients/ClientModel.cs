using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.WebApp.Models.Clients
{
    public class CreateClientModel
    {
        /// <summary>
        /// Gets or sets the application user identifier
        /// </summary>
        public string ApplicationUserId { get; set; }

        /// <summary>
        /// Gets or sets the first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the company name
        /// </summary>
        public string Company { get; set; }
    }
}
