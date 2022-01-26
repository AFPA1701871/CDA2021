using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VillesMultiCouche.Data.Dtos;
using VillesMultiCouche.Data.Models;

namespace VillesMultiCouche.Data.Profiles
{
    public class VillesProfiles : Profile
    {
        public VillesProfiles()
        {
            CreateMap<Ville, VilleDTO>();
            CreateMap<VilleDTO, Ville>();
        }

    }
}
