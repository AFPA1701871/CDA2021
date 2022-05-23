using AutoMapper;
using DemoEF.Data.Dtos;
using DemoEF.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoEF.Data.Profiles
{
    public class PersonnesProfile : Profile
    {
        public PersonnesProfile()
        {
            CreateMap<Personne, PersonnesDTO>();
            CreateMap<PersonnesDTO, Personne>();

        }
    }
}
