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
    [Route("api/Menu")]
    [ApiController]

    public class MenuController : ControllerBase
    {

        private readonly MenuServices _service;
        private readonly IMapper _mapper;

        public MenuController(GCantineContext _context)
        {
            _service = new MenuServices(_context);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MenuProfile>();
            });
            _mapper = config.CreateMapper();
        }

        //GET api/Menu
        public IEnumerable<MenuDTOOut> GetAllMenu()
        {
            IEnumerable<Menu> listeMenu = _service.GetAllMenu();
            return _mapper.Map<IEnumerable<MenuDTOOut>>(listeMenu);
        }

        public IEnumerable<MenuDTOOut> GetAllReservationMenu()
        {
            IEnumerable<Menu> listeMenu = _service.GetAllReservationMenu();
            return _mapper.Map<IEnumerable<MenuDTOOut>>(listeMenu);
        }

        //GET api/Menu/{i}
        public ActionResult<MenuDTOOut> GetMenuById(int id)
        {
            Menu commandItem = _service.GetMenuById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<MenuDTOOut>(commandItem));
            }
            return NotFound();
        }

        //POST api/Menu

        public ActionResult<MenuDTOOut> CreateMenu(MenuDTOIn objIn)
        {
            Menu obj = _mapper.Map<Menu>(objIn);
            _service.AddMenu(obj);
            return CreatedAtRoute(nameof(GetMenuById), new { Id = obj.IdMenu }, obj);
        }

        //POST api/Menu/{id}
        public ActionResult UpdateMenu(int id, MenuDTOIn obj)
        {
            Menu objFromRepo = _service.GetMenuById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateMenu(objFromRepo);
            return NoContent();
        }


        //DELETE api/Menu/{id}
        public ActionResult DeleteMenu(int id)
        {
            Menu obj = _service.GetMenuById(id);
            if (obj == null)
            {
                return NotFound();
            }
            _service.DeleteMenu(obj);
            return NoContent();
        }
    }
}

