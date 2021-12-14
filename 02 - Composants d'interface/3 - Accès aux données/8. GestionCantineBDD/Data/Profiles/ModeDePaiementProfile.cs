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
    class ModeDePaiementProfile : Profile
    {
        public ModeDePaiementProfile()
        {
            CreateMap<ModeDePaiement,ModeDePaiementDTOIn>();
            CreateMap<ModeDePaiementDTOIn, ModeDePaiement>();
            CreateMap<ModeDePaiement,ModeDePaiementDTOOut>();
            CreateMap<ModeDePaiementDTOOut, ModeDePaiement>();
        }
    }
}
