using AutoMapper;
using CSM.Domain.Entities.Clients;
using CSM.WebApp.Models.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.WebApp.AutomapperProfiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<CreateClientModel,Client>(); 
            CreateMap<AddressModel, Address>();
        }
    }
}
