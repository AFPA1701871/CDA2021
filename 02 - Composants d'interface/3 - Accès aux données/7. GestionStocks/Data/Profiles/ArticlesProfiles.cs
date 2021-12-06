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
    class ArticlesProfiles:Profile
    {
        public ArticlesProfiles()
        {
            // on réalise le mapping entre les objets et les DTOs
            CreateMap<Article, ArticlesDTO>();
            CreateMap<ArticlesDTO, Article>();
            CreateMap<Article, ArticlesDTOIn>();
            CreateMap<ArticlesDTOIn, Article>();
            CreateMap<Article, ArticlesDTOAvecLibelleCategorie>();
            CreateMap<ArticlesDTOAvecLibelleCategorie, Article>();

            /******** Différence avec une API  ********/
            // pour le DTO ArticlesDTOAvecLibelleCategorie, on a mis l'objet à plat 
            // C'est à dire que le libellé catégorie n'est pas un attribut de l'objet categorie à l'inyterieur de l'objet Article
            // on a crée un attribut LibelleCategorie à l'intérieur de Article (directement)
            CreateMap<Article, ArticlesDTOAvecLibelleCategorie>().ForMember(d => d.LibelleCategorie, o => o.MapFrom(s => s.Categorie.LibelleCategorie));
        }
        
    }
}
