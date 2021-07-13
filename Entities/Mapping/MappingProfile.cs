using AutoMapper;
using Entities.DTO;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Mapping
{
    public class MappingProfile : Profile
    {
       
        public MappingProfile()
        {
            CreateMap<AccountDTO, Account>();
            CreateMap<Account, AccountDTO>();
            CreateMap<AccountDataDTO, Account>();
            CreateMap<Account, AccountDataDTO>();
        }
    }
}
