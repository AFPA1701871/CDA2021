using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TablesLiees.Data.Dtos;
using TablesLiees.Data.Models;
using TablesLiees.Data.Services;

namespace TablesLiees.Controllers
{
    [Route("api/Entite1")]
    [ApiController]
    public class Entite1Controller : ControllerBase
    {


        private readonly Entite1Services _service;
        private readonly IMapper _mapper;

        public Entite1Controller(Entite1Services service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        //Pas d'utilisation de DTO
        // Toutes les informations sont affichées
        //GET api/Entite1
        //[HttpGet]
        //public ActionResult<IEnumerable<Entite1>> GetAllEntite1()
        //{
        //    IEnumerable<Entite1> listeEntite1 = _service.GetAllEntite1();
        //    return Ok(listeEntite1);
        //}


        //Utilisation d'un DTO
        // Les Id sont masqués dans Entite1 et dans Entite2

        //GET api/Entite1
        [HttpGet]
        public ActionResult<IEnumerable<Entite1DTO>> GetAllEntite1()
        {
            IEnumerable<Entite1> listeEntite1 = _service.GetAllEntite1();
            return Ok(_mapper.Map<IEnumerable<Entite1DTO>>(listeEntite1));
        }

        //GET api/Entite1/id
        [HttpGet("{id}", Name = "GetEntite1ById")]
        public ActionResult<Entite1DTO> GetEntite1ById(int id)
        {
            Entite1 ent = _service.GetEntite1ById(id);
            return Ok(_mapper.Map<Entite1DTO>(ent));
        }

        //POST api/Entite1
        [HttpPost]
        public ActionResult CreateEntite1(Entite1DTOIn ent)
        {
            //on ajoute l’objet à la base de données
            _service.AddEntite1(ent);
            //on retourne le chemin de findById avec l'objet créé
            return NoContent();

        }

        //PUT api/entite1/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateEntite1(int id, Entite1DTO entite1)
        {
            var entite1FromRepo = _service.GetEntite1ById(id);
            if (entite1FromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(entite1, entite1FromRepo);
            // inutile puisque la fonction ne fait rien, mais garde la cohérence
            _service.UpdateEntite1(entite1FromRepo);

            return NoContent();
        }
    }
}
