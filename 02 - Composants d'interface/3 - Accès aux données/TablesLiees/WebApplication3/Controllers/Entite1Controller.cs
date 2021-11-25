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
    }
}
