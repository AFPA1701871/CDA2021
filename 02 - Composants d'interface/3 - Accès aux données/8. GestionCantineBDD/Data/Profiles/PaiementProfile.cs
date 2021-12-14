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
    class PaiementProfile : Profile
    {
        public PaiementProfile()
        {
            CreateMap<PaiementDTOIn, Paiement>();
            CreateMap<Paiement, PaiementDTOIn>();
            CreateMap<Paiement, PaiementDTOOut>()
                .ForMember(d => d.DatePaiement, o => o.MapFrom(s => ((DateTime)s.DatePaiement).ToString("dd-MM-yyyy")))
                .ForMember(d => d.NomEleve, o => o.MapFrom(s => s.Eleve.NomEleve))
                .ForMember(d => d.PrenomEleve, o => o.MapFrom(s => s.Eleve.PrenomEleve))
                .ForMember(d => d.DDNEleve, o => o.MapFrom(s => ((DateTime)s.Eleve.DDNEleve).ToString("dd-MM-yyyy")))
                .ForMember(d => d.LibelleModeDePaement, o => o.MapFrom(s => s.ModeDePaiement.LibelleModeDePaiement));
        }
    }
}
