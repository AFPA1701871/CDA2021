using GestionCantine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCantine.Data.Services
{
    class MenuServices
    {

        private readonly GCantineContext _context;

        public MenuServices(GCantineContext context)
        {
            _context = context;
        }

        public void AddMenu(Menu obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Menus.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteMenu(Menu obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Menus.Remove(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Menu> GetAllMenu()
        {
            return _context.Menus.ToList();
        }

        public IEnumerable<Menu> GetAllReservationMenu()
        {
            return _context.Menus.Where(x => x.DateMenu > DateTime.Now).ToList();
        }

        public Menu GetMenuById(int id)
        {
            return _context.Menus.FirstOrDefault(obj => obj.IdMenu == id);
        }

        public void UpdateMenu(Menu obj)
        {
            _context.SaveChanges();
        }
    }
}
