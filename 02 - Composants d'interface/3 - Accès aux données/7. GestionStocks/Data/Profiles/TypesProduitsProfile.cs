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
    class TypesProduitsProfile:Profile
    {
        public TypesProduitsProfile()
        {
            CreateMap<TypeProduit, TypesProduitsDTO>();
            CreateMap<TypesProduitsDTO, TypeProduit>();
            CreateMap<TypeProduit, TypesProduitsDTOIn>();
            CreateMap<TypesProduitsDTOIn, TypeProduit>();
        }
    }
}
