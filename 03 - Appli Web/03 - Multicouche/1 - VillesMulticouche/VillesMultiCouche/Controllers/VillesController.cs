using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VillesMultiCouche.Data.Dtos;
using VillesMultiCouche.Data.Models;
using VillesMultiCouche.Data.Services;

namespace VillesMultiCouche.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class VillesController:ControllerBase
    {
        private readonly VillesServices _service;
        private readonly IMapper _mapper;

        public VillesController(VillesServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/Villes
        [EnableCors("toto")]
        [HttpGet]
        public ActionResult<IEnumerable<VilleDTO>> GetAllVilles()
        {
            IEnumerable<Ville> listeVilles = _service.GetAllVilles();
            return Ok(_mapper.Map<IEnumerable<VilleDTO>>(listeVilles));
        }

        //GET api/Villes/{i}
        [EnableCors("toto")]
        [HttpGet("{id}", Name = "GetVillesById")]
        public ActionResult<VilleDTO> GetVillesById(int id)
        {
            Ville commandItem = _service.GetVilleById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<VilleDTO>(commandItem));
            }
            return NotFound();
        }

        //POST api/Villes
        [EnableCors("toto")]
        [HttpPost]
        public ActionResult<VilleDTO> CreateVilles(Ville obj)
        {
            _service.AddVille(obj);
            return CreatedAtRoute(nameof(GetVillesById), new { Id = obj.IdVille }, obj);
        }

        //POST api/Villes/{id}
        [EnableCors("toto")]
        [HttpPut("{id}")]
        public ActionResult UpdateVilles(int id, VilleDTO obj)
        {
            Ville objFromRepo = _service.GetVilleById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateVille(objFromRepo);
            return NoContent();
        }


        //DELETE api/Villes/{id}
        [EnableCors("toto")]
        [HttpDelete("{id}")]
        public ActionResult DeleteVilles(int id)
        {
            Ville obj = _service.GetVilleById(id);
            if (obj == null)
            {
                return NotFound();
            }
            _service.DeleteVille(obj);
            return NoContent();
        }


    }
}
