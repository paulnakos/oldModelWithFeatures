using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BeerV1.Dtos;
using BeerV1.Models;

namespace BeerV1.App_Start
{
    public class BeerTapProfile : Profile
    {
        public BeerTapProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}