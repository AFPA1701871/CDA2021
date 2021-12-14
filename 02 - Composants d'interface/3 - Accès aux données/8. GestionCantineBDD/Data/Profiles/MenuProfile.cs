using AutoMapper;
using GestionCantine.Data.Dtos;
using GestionCantine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCantine.Data.Profiles
{
    class MenuProfile : Profile
    {
        public MenuProfile()
        {
            CreateMap<MenuDTOIn, Menu>();
            CreateMap<Menu, MenuDTOIn>();

            CreateMap<Menu, MenuDTOOut>()
            .ForMember(d => d.DateMenu, o => o.MapFrom(s => ((DateTime)s.DateMenu).ToString("dd-MM-yyyy")));

            CreateMap<MenuDTOOut,Menu>();
        }
    }
}
