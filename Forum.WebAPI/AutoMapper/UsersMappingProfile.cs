using AutoMapper;
using Forum.WebAPI.Database;
using Forum.WebAPI.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.WebAPI.AutoMapper
{
    public class UsersMappingProfile:Profile
    {
        public UsersMappingProfile()
        {
            CreateMap<Users, UsersDto>().ReverseMap();
            CreateMap<Users, UsersToAuthenticateDto>().ReverseMap();

        }
    }
}
