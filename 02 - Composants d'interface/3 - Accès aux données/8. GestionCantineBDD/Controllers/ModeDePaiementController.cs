using AutoMapper;
using GestionCantine.Data;
using GestionCantine.Data.Dtos;
using GestionCantine.Data.Models;
using GestionCantine.Data.Profiles;
using GestionCantine.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCantine.Controllers
{
    class ModeDePaiementController : ControllerBase
    {
        private readonly ModeDePaiementServices _service;
        private readonly IMapper _mapper;

        public ModeDePaiementController(GCantineContext context)
        {
            _service = new ModeDePaiementServices(context);
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<ModeDePaiementProfile>();
            });
            _mapper = config.CreateMapper();
        }

        public IEnumerable<ModeDePaiementDTOOut> GetAllModeDePaiement()
        {
            IEnumerable<ModeDePaiement> listeModeDePaiement = _service.GetAllModeDePaiements();
            return _mapper.Map<IEnumerable<ModeDePaiementDTOOut>>(listeModeDePaiement);
        }

        public ActionResult<ModeDePaiementDTOOut> GetModeDePaiementById(int id)
        {
            ModeDePaiement commandItem = _service.GetModeDePaiementById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<ModeDePaiementDTOOut>(commandItem));
            }
            return NotFound();
        }

        public void CreateModeDePaiement(ModeDePaiementDTOIn obj)
        {
            ModeDePaiement paiement = _mapper.Map<ModeDePaiement>(obj);
            _service.AddModeDePaiement(paiement);
        }


        public ActionResult UpdateModeDePaiement(int id, ModeDePaiementDTOIn obj)
        {
            ModeDePaiement objFromRepo = _service.GetModeDePaiementById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateModeDePaiement(objFromRepo);
            return NoContent();
        }

        //DELETE api/ModeDePaiement/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteModeDePaiement(int id)
        {
            ModeDePaiement obj = _service.GetModeDePaiementById(id);
            if (obj == null)
            {
                return NotFound();
            }
            _service.DeleteModeDePaiement(obj);
            return NoContent();
        }
    }
}
