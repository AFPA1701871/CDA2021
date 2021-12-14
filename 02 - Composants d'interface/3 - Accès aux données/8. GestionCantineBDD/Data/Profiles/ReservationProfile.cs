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
    class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<Reservation, ReservationDTOIn>();
            CreateMap<ReservationDTOIn, Reservation>();

            CreateMap<Reservation, ReservationDTOOut>()
            .ForMember(x => x.LibelleMenu, y => y.MapFrom(z => z.Menu.LibelleMenu))
            .ForMember(x => x.PrixMenu, y => y.MapFrom(z => z.Menu.PrixMenu))
            .ForMember(x => x.DateMenu, y => y.MapFrom(z => ((DateTime)z.Menu.DateMenu).ToString("dd-MM-yyyy")))
            .ForMember(x => x.NomEleve, y => y.MapFrom(z => z.Eleve.NomEleve))
            .ForMember(x => x.PrenomEleve, y => y.MapFrom(z => z.Eleve.PrenomEleve))
            .ForMember(x => x.DDNEleve, y => y.MapFrom(z => ((DateTime)z.Eleve.DDNEleve).ToString("dd-MM-yyyy")))
            .ForMember(x => x.DateReservation, y => y.MapFrom(z => ((DateTime)z.DateReservation).ToString("dd-MM-yyyy")));

            CreateMap<ReservationDTOOut, Reservation>();


        }
    }
}
