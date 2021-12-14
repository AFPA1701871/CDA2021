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
    class PaiementController:ControllerBase
    {
        private readonly PaiementServices _service;
        private readonly IMapper _mapper;

        public PaiementController(GCantineContext context)
        {
            _service = new PaiementServices(context);
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<PaiementProfile>();
            });
            _mapper = config.CreateMapper();
        }

        public IEnumerable<PaiementDTOOut> GetAllPaiement()
        {
            IEnumerable<Paiement> listePaiement = _service.GetAllPaiements();
            return _mapper.Map<IEnumerable<PaiementDTOOut>>(listePaiement);
        }

        public PaiementDTOOut GetPaiementById(int id)
        {
            Paiement commandItem = _service.GetPaiementById(id);
            return _mapper.Map<PaiementDTOOut>(commandItem);
        }

        public void CreatePaiement(PaiementDTOIn obj)
        {
            Paiement paiement = _mapper.Map<Paiement>(obj);
            _service.AddPaiement(paiement);
        }


        public ActionResult UpdatePaiement(int id, PaiementDTOIn obj)
        {
            Paiement objFromRepo = _service.GetPaiementById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdatePaiement(objFromRepo);
            return NoContent();
        }

        //DELETE api/Paiement/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePaiement(int id)
        {
            Paiement obj = _service.GetPaiementById(id);
            if (obj == null)
            {
                return NotFound();
            }
            _service.DeletePaiement(obj);
            return NoContent();
        }


    }
}
