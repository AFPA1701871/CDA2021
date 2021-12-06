using AutoMapper;
using GestionStocks.Data.Dtos;
using GestionStocks.Data.Models;
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
    class TypesProduitsController:ControllerBase
    {

        private readonly TypesProduitsServices _service;
        private readonly IMapper _mapper;

        public TypesProduitsController(TypesProduitsServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/TypesProduits
        [HttpGet]
        public ActionResult<IEnumerable<TypesProduitsDTO>> GetAllTypesProduits()
        {
            IEnumerable<TypeProduit> listeTypesProduits = _service.GetAllTypesProduits();
            return Ok(_mapper.Map<IEnumerable<TypesProduitsDTO>>(listeTypesProduits));
        }

        //GET api/TypesProduits/{i}
        [HttpGet("{id}", Name = "GetTypesProduitById")]
        public ActionResult<TypesProduitsDTO> GetTypesProduitById(int id)
        {
            TypeProduit commandItem = _service.GetTypesProduitById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<TypesProduitsDTO>(commandItem));
            }
            return NotFound();
        }

        //POST api/TypesProduits
        [HttpPost]
        public ActionResult<TypesProduitsDTO> CreateTypesProduit(TypesProduitsDTOIn objIn)
        {
            TypeProduit obj = _mapper.Map<TypeProduit>(objIn);
            _service.AddTypesProduit(obj);
            return CreatedAtRoute(nameof(GetTypesProduitById), new { Id = obj.IdTypeProduit }, obj);
        }

        //POST api/TypesProduits/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateTypesProduit(int id, TypesProduitsDTOIn obj)
        {
            TypeProduit objFromRepo = _service.GetTypesProduitById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateTypesProduit(objFromRepo);
            return NoContent();
        }

        // Exemple d'appel
        // [{
        // "op":"replace",
        // "path":"",
        // "value":""
        // }]
        //PATCH api/TypesProduits/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialTypesProduitUpdate(int id, JsonPatchDocument<TypeProduit> patchDoc)
        {
            TypeProduit objFromRepo = _service.GetTypesProduitById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            TypeProduit objToPatch = _mapper.Map<TypeProduit>(objFromRepo);
            patchDoc.ApplyTo(objToPatch, ModelState);
            if (!TryValidateModel(objToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(objToPatch, objFromRepo);
            _service.UpdateTypesProduit(objFromRepo);
            return NoContent();
        }

        //DELETE api/TypesProduits/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteTypesProduit(int id)
        {
            TypeProduit obj = _service.GetTypesProduitById(id);
            if (obj == null)
            {
                return NotFound();
            }
            _service.DeleteTypesProduit(obj);
            return NoContent();
        }


    }
}
