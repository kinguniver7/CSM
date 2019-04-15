using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.WebApp.Models.Auth
{
    public class SignUpModel
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
