using System;
using System.Collections.Generic;
using System.Text;

namespace CSM.Domain.Entities.Clients
{
    /// <summary>
    /// Represents a client
    /// </summary>
    public class Client
    {
        public int Id { get; set; }

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

        /// <summary>
        /// Gets or sets the address identifier
        /// </summary>
        public int AddressId { get; set; }

        /// <summary>
        /// Gets or sets the address
        /// </summary>
        public virtual Address Address { get; set; }

        /// <summary>
        /// Gets or sets the contacts
        /// </summary>
        public virtual ICollection<Contact> Contacts { get; set; }

    }
}
