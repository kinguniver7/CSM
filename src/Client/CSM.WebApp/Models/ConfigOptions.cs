using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.WebApp.Models
{
    public class ConfigOptions
    {
        public CometChatOptions CometChatOptions { get; set; }
    }

    public class CometChatOptions
    {
        public string AppId { get; set; }

        public string AuthOnlyApiKey { get; set; }

        public string FullAccessApiKey { get; set; }
    }
}
