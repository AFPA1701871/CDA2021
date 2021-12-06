using AutoMapper;
using GestionStocks.Data;
using GestionStocks.Data.Dtos;
using GestionStocks.Data.Models;
using GestionStocks.Data.Profiles;
using GestionStocks.Data.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStocks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    class ArticlesController:ControllerBase
    {

        private readonly ArticlesServices _service;
        private readonly IMapper _mapper;

        public ArticlesController(MyDbContext _context)
        {
            /******** Différence avec une API  ********/
            // on doit créer le service à partir du context parce qu'il n'y a plus de startup qui le fait directement
            _service = new ArticlesServices(_context);

            // on doit créer le mapper parce qu'il n'y a plus de startup qui le fait directement
            var config = new MapperConfiguration(cfg =>
            {
                // comme l'article contient des catégorie, on déclare 2 mappers article et catégorie
                cfg.AddProfile<ArticlesProfiles>();
                cfg.AddProfile<CategoriesProfiles>();
            });
            _mapper = config.CreateMapper();
        }


        //GET api/Articles
        [HttpGet]
        public IEnumerable<ArticlesDTO> GetAllArticles()
        {
            IEnumerable<Article> listeArticles = _service.GetAllArticles();
            return _mapper.Map<IEnumerable<ArticlesDTO>>(listeArticles);
        }

        [HttpGet]
        public IEnumerable<ArticlesDTOAvecLibelleCategorie> GetAllArticlesAvecLibelleCateg()
        {
            IEnumerable<Article> listeArticles = _service.GetAllArticles();
            return _mapper.Map<IEnumerable<ArticlesDTOAvecLibelleCategorie>>(listeArticles);
        }

        //GET api/Articles/{i}
        [HttpGet("{id}", Name = "GetArticleById")]
        public ActionResult<ArticlesDTO> GetArticleById(int id)
        {
            Article commandItem = _service.GetArticleById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<ArticlesDTO>(commandItem));
            }
            return NotFound();
        }

        public Article GetArticleByLibelle(string libelle)
        {
            Article article = _service.GetArticleByLibelle(libelle);
            return article;
        }

        //POST api/Articles
        [HttpPost]
        public ActionResult<ArticlesDTO> CreateArticle(ArticlesDTOIn objIn)
        {
            Article obj = _mapper.Map<Article>(objIn);
            _service.AddArticle(obj);
            return CreatedAtRoute(nameof(GetArticleById), new { Id = obj.IdArticle }, obj);
        }

        //POST api/Articles/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateArticle(int id, ArticlesDTOIn obj)
        {
            Article objFromRepo = _service.GetArticleById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateArticle(objFromRepo);
            return NoContent();
        }

        // Exemple d'appel
        // [{
        // "op":"replace",
        // "path":"",
        // "value":""
        // }]
        //PATCH api/Articles/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialArticleUpdate(int id, JsonPatchDocument<Article> patchDoc)
        {
            Article objFromRepo = _service.GetArticleById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            Article objToPatch = _mapper.Map<Article>(objFromRepo);
            patchDoc.ApplyTo(objToPatch, ModelState);
            if (!TryValidateModel(objToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(objToPatch, objFromRepo);
            _service.UpdateArticle(objFromRepo);
            return NoContent();
        }

        //DELETE api/Articles/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteArticle(int id)
        {
            Article obj = _service.GetArticleById(id);
            if (obj == null)
            {
                return NotFound();
            }
            _service.DeleteArticle(obj);
            return NoContent();
        }


    }
}
