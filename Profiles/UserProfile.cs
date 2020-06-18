using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using UserAPI.Commands;
using UserAPI.Models;

namespace UserAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserModel, CreateUserCommand>()
                .ReverseMap();
        }
    }
}
