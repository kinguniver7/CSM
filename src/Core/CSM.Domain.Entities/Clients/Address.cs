using System;
using System.Collections.Generic;
using System.Text;

namespace CSM.Domain.Entities.Clients
{
    /// <summary>
    /// Represents a address
    /// </summary>
    public class Address
    {
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the street
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the zip code
        /// </summary>
        public int ZipCode { get; set; }
    }
}
