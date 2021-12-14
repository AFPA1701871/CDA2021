using AutoMapper;
using GestionCantine.Data;
using GestionCantine.Data.Dtos;
using GestionCantine.Data.Models;
using GestionCantine.Data.Profiles;
using GestionCantine.Data.Services;
using GestionCantine.Help;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCantine.Controllers
{
    class ReservationController : ControllerBase
    {

        private readonly ReservationServices _service;
        private readonly IMapper _mapper;

        public ReservationController(GCantineContext _context)
        {
            _service = new ReservationServices(_context);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ReservationProfile>();
            });
            _mapper = config.CreateMapper();
        }

        //GET api/Reservation
        [HttpGet]
        public IEnumerable<ReservationDTOOut> GetAllReservation()
        {
            IEnumerable<Reservation> listeReservation = _service.GetAllReservation();
            return _mapper.Map<IEnumerable<ReservationDTOOut>>(listeReservation);
        }

        //GET api/Reservation/{i}
        [HttpGet("{id}", Name = "GetReservationById")]
        public ActionResult<ReservationDTOOut> GetReservationById(int id)
        {
            Reservation commandItem = _service.GetReservationById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<ReservationDTOOut>(commandItem));
            }
            return NotFound();
        }

        //POST api/Reservation
        [HttpPost]
        public ActionResult<ReservationDTOOut> CreateReservation(ReservationDTOIn objIn)
        {
            Reservation obj = _mapper.Map<Reservation>(objIn);
            _service.AddReservation(obj);
            return CreatedAtRoute(nameof(GetReservationById), new { Id = obj.IdReservation }, obj);
        }

        //POST api/Reservation/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateReservation(int id, ReservationDTOIn obj)
        {
            Reservation objFromRepo = _service.GetReservationById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateReservation(objFromRepo);
            return NoContent();
        }

        // Exemple d'appel
        // [{
        // "op":"replace",
        // "path":"",
        // "value":""
        // }]
        //PATCH api/Reservation/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialReservationUpdate(int id, JsonPatchDocument<Reservation> patchDoc)
        {
            Reservation objFromRepo = _service.GetReservationById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            Reservation objToPatch = _mapper.Map<Reservation>(objFromRepo);
            patchDoc.ApplyTo(objToPatch, ModelState);
            if (!TryValidateModel(objToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(objToPatch, objFromRepo);
            _service.UpdateReservation(objFromRepo);
            return NoContent();
        }

        //DELETE api/Reservation/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteReservation(int id)
        {
            Reservation obj = _service.GetReservationById(id);
            if (obj == null)
            {
                return NotFound();
            }
            _service.DeleteReservation(obj);
            return NoContent();
        }


    }
}
