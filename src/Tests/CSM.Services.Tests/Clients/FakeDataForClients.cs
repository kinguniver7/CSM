using CSM.Domain.Entities.Clients;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSM.Services.Tests.Clients
{
    public class FakeDataForClients
    {
        private static string userId;

        public static string UserId
        {
            get
            {
                if (string.IsNullOrWhiteSpace(userId))
                {
                    userId = Guid.NewGuid().ToString();
                }
                return userId;
            }
        }

        public static Client GetClientWithOutAddress()
        {
            return new Client
            {
                FirstName = "Fname",
                LastName = "Lname",
                Company = "CompT",
                ApplicationUserId = UserId
            };
        }

        public static Client GetClientWithAddress()
        {
            var client = GetClientWithOutAddress();
            client.Address = new Address
            {
                City = "TestS",
                Country = "TestC",
                Street = "TestSt",
                ZipCode = 11111
            };
            return client;
        }

        public static Contact GetContactEmail()
        {
            return new Contact
            {
                Name = "Email",
                Type = ContactType.Email,
                Value = "test@test.com"
            };
        }
        public static Contact GetContactPhone()
        {
            return new Contact
            {
                Name = "Phone",
                Type = ContactType.Phone,
                Value = "+38098-888-88-88"
            };
        }
    }
}
