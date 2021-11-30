using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TablesLiees.Data.Dtos;
using TablesLiees.Data.Models;

namespace TablesLiees.Profiles
{
    public class Entite2Profile :Profile
    {
        public Entite2Profile()
        {
            CreateMap<Entite2DTO, Entite2>();
            CreateMap<Entite2, Entite2DTO>();
        }
    }
}
