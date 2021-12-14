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
    class EleveProfile : Profile
    {

        public EleveProfile()
        {
            CreateMap<EleveDTOIn, Eleve>();
            CreateMap<Eleve, EleveDTOIn>();
            CreateMap<EleveDTOOut, Eleve>();
            CreateMap<Eleve, EleveDTOOut>().ForMember(x => x.DDNEleve, y => y.MapFrom(z => ((DateTime)z.DDNEleve).ToString("dd-MM-yyyy")));

            CreateMap<EleveReservationDTOOut, Eleve>();
            CreateMap<Eleve, EleveReservationDTOOut>();
        }
    }
}
