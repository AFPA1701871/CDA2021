using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Schools.Data.Models;
using Schools.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schools.Controllers
{
    public class GradesController : ControllerBase
    {
        private readonly GradesServices _service;
        private readonly IMapper _mapper;

        public GradesController(GradesServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/Grades
        [HttpGet]
        public ActionResult<IEnumerable<Grade>> GetAllGrades()
        {
            IEnumerable<Grade> listeGrades = _service.GetAllGrade();
            return Ok(listeGrades);
        }

        //GET api/Grades/{i}
        [HttpGet("{id}", Name = "GetGradeById")]
        public ActionResult<Grade> GetGradeById(int id)
        {
            Grade commandItem = _service.GetGradeById(id);
            if (commandItem != null)
            {
                return Ok(commandItem);
            }
            return NotFound();
        }

        //POST api/Grades
        [HttpPost]
        public ActionResult<Grade> CreateGrade(Grade obj)
        {
            _service.AddGrade(obj);
            return CreatedAtRoute(nameof(GetGradeById), new { Id = obj.GradeId }, obj);
        }

        //POST api/Grades/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateGrade(int id, Grade obj)
        {
            Grade objFromRepo = _service.GetGradeById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateGrade(objFromRepo);
            return NoContent();
        }

        // Exemple d'appel
        // [{
        // "op":"replace",
        // "path":"",
        // "value":""
        // }]
        //PATCH api/Grades/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialGradeUpdate(int id, JsonPatchDocument<Grade> patchDoc)
        {
            Grade objFromRepo = _service.GetGradeById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            Grade objToPatch = _mapper.Map<Grade>(objFromRepo);
            patchDoc.ApplyTo(objToPatch, ModelState);
            if (!TryValidateModel(objToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(objToPatch, objFromRepo);
            _service.UpdateGrade(objFromRepo);
            return NoContent();
        }

        //DELETE api/Grades/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteGrade(int id)
        {
            Grade obj = _service.GetGradeById(id);
            if (obj == null)
            {
                return NotFound();
            }
            _service.DeleteGrade(obj);
            return NoContent();
        }


    }
}
