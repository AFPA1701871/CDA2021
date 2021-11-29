using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TablesRelations.Data.Models;
using TablesRelations.Data.Services;
;


namespace TablesRelations.Controllers
{
    public class StudentController : ControllerBase
    {

        private readonly StudentService _service;
        private readonly IMapper _mapper;

        public StudentController(StudentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/Student
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAllStudent()
        {
            IEnumerable<Student> listeStudent = _service.GetAllStudent();
        //    return Ok(_mapper.Map<IEnumerable<Student>>(listeStudent));
            return Ok(listeStudent);
        }

        //GET api/Student/{i}
        [HttpGet("{id}", Name = "GetStudentById")]
        public ActionResult<Student> GetStudentById(int id)
        {
            Student commandItem = _service.GetStudentById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<Student>(commandItem));
            }
            return NotFound();
        }

        //POST api/Student
        [HttpPost]
        public ActionResult<Student> CreateStudent(Student obj)
        {
            _service.AddStudent(obj);
            return CreatedAtRoute(nameof(GetStudentById), new { Id = obj.StudentId }, obj);
        }

        //POST api/Student/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, Student obj)
        {
            Student objFromRepo = _service.GetStudentById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateStudent(objFromRepo);
            return NoContent();
        }

        // Exemple d'appel
        // [{
        // "op":"replace",
        // "path":"",
        // "value":""
        // }]
        //PATCH api/Student/{id}
        //[HttpPatch("{id}")]
        //public ActionResult PartialStudentUpdate(int id, JsonPatchDocument<Student> patchDoc)
        //{
        //    Student objFromRepo = _service.GetStudentById(id);
        //    if (objFromRepo == null)
        //    {
        //        return NotFound();
        //    }
        //    Student objToPatch = _mapper.Map<Student>(objFromRepo);
        //    patchDoc.ApplyTo(objToPatch, ModelState);
        //    if (!TryValidateModel(objToPatch))
        //    {
        //        return ValidationProblem(ModelState);
        //    }
        //    _mapper.Map(objToPatch, objFromRepo);
        //    _service.UpdateStudent(objFromRepo);
        //    return NoContent();
        //}

        //DELETE api/Student/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            Student obj = _service.GetStudentById(id);
            if (obj == null)
            {
                return NotFound();
            }
            _service.DeleteStudent(obj);
            return NoContent();
        }


    }
}
