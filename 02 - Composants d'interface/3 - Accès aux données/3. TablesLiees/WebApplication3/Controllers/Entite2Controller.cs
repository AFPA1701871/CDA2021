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
    [Route("api/Entite2")]
    [ApiController]
    public class Entite2Controller : ControllerBase
    {


        private readonly Entite2Services _service;
        private readonly IMapper _mapper;

        public Entite2Controller(Entite2Services service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/Entite2
        [HttpGet]
        public ActionResult<IEnumerable<Entite2DTO>> GetAllEntite2()
        {
            IEnumerable<Entite2> listeEntite2 = _service.GetAllEntite2();
            return Ok(_mapper.Map<IEnumerable<Entite2DTO>>(listeEntite2));
        }

    }
}
