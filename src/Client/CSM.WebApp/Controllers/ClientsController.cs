using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CSM.Domain.Entities.Clients;
using CSM.Services.Interfaces.Clients;
using CSM.Services.Interfaces.Users;
using CSM.WebApp.Extensions;
using CSM.WebApp.Models.Clients;
using Microsoft.AspNetCore.Mvc;

namespace CSM.WebApp.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientService _clientService;

        private readonly IApplicationUserService _applicationUserService;

        private readonly IMapper _mapper;

        public ClientsController(IClientService clientService, IApplicationUserService applicationUserService, IMapper mapper)
        {
            _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
            _applicationUserService = applicationUserService ?? throw new ArgumentNullException(nameof(applicationUserService));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Create(CreateClientModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.ApplicationUserId = User.GetUserId();
                    var client = _mapper.Map<Client>(model);
                    client = await _clientService.CreateAsync(client);
                }
                catch(Exception er)
                {
                    //TODO: Need to add redirect to error page
                }             


            }
            

            return Json(model);
        }
    }
}