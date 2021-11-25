using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TablesLiees.Data.Dtos;
using TablesLiees.Data.Models;

namespace TablesLiees.Profiles
{
    public class Entite1Profile :Profile
    {
        public Entite1Profile()
        {
            CreateMap<Entite1DTO, Entite1>();
            CreateMap<Entite1, Entite1DTO>();

            // Pour les données Entité2 contenu dans Entite1 => il y aura un appel à Entite2Profile
        }
    }
}
