using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSM.Domain.Entities.Clients;
using CSM.Services.Interfaces.Clients;
using Microsoft.AspNetCore.Mvc;

namespace CSM.WebApp.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = _clientService ?? throw new ArgumentNullException(nameof(clientService));
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create(Client client)
        {
            
            return null;
        }
    }
}