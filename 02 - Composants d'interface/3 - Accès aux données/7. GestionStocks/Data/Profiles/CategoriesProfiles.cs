using AutoMapper;
using GestionStocks.Data.Dtos;
using GestionStocks.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStocks.Data.Profiles
{
    class CategoriesProfiles:Profile
    {
        public CategoriesProfiles()
        {
            CreateMap<Categorie, CategoriesDTO>();
            CreateMap<CategoriesDTO, Categorie>();
            CreateMap<Categorie, CategoriesDTOIn>();
            CreateMap<CategoriesDTOIn, Categorie>();
        }
    }
}
