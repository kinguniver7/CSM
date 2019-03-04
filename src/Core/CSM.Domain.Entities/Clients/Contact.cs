using System;
using System.Collections.Generic;
using System.Text;

namespace CSM.Domain.Entities.Clients
{
    /// <summary>
    /// Represents a contact
    /// </summary>
    public class Contact
    {
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the client identifier
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Gets or sets the contact type
        /// </summary>
        public ContactType Type { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the client
        /// </summary>
        public Client Client { get; set; }
    }
}
