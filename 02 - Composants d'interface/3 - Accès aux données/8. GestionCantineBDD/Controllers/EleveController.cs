using AutoMapper;
using GestionCantine.Data;
using GestionCantine.Data.Dtos;
using GestionCantine.Data.Models;
using GestionCantine.Data.Profiles;
using GestionCantine.Data.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCantine.Controllers
{
    class EleveController : ControllerBase
    {

        private readonly EleveService _service;
        private readonly IMapper _mapper;

        public EleveController(GCantineContext _context)
        {
            _service = new EleveService(_context);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EleveProfile>();
            });
            _mapper = config.CreateMapper();
        }

        //GET api/Eleve
        public IEnumerable<EleveDTOOut> GetAllEleve()
        {
            IEnumerable<Eleve> listeEleve = _service.GetAllEleve();
            return _mapper.Map<IEnumerable<EleveDTOOut>>(listeEleve);
        }

        //GET api/Eleve/{i}
        public ActionResult<EleveDTOOut> GetEleveById(int id)
        {
            Eleve commandItem = _service.GetEleveById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<EleveDTOOut>(commandItem));
            }
            return NotFound();
        }

        //POST api/Eleve
        public void CreateEleve(EleveDTOIn objIn)
        {
            Eleve obj = _mapper.Map<Eleve>(objIn);
            _service.AddEleve(obj);
        }

        //POST api/Eleve/{id}
        public ActionResult UpdateEleve(int id, EleveDTOIn obj)
        {
            Eleve objFromRepo = _service.GetEleveById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateEleve(objFromRepo);
            return NoContent();
        }

        //DELETE api/Eleve/{id}
        public ActionResult DeleteEleve(int id)
        {
            Eleve obj = _service.GetEleveById(id);
            if (obj == null)
            {
                return NotFound();
            }
            _service.DeleteEleve(obj);
            return NoContent();
        }

        public void UpdateSoldeEleve(int id, double montant)
        {
            _service.Operation(id, montant);
        }

    }
}
