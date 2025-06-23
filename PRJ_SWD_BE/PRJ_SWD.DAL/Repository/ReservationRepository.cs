using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJ_SWD.DAL.Infracstructure;
using PRJ_SWD.DAL.Models;

namespace PRJ_SWD.DAL.Repository
{
   public class ReservationRepository : IRepository<Reservation>
    {
        private readonly PrjSwdContext _context;
        public ReservationRepository(PrjSwdContext context)
        {
            _context = context;
        }

        public Reservation Add(Reservation entity)
        {
            _context.Reservations.Add(entity);
            return entity;
        }

        public Reservation Delete(Reservation entity)
        {
            _context.Reservations.Remove(entity);
            return entity;
        }

        public Reservation Delete(int id)
        {
            var entity = _context.Reservations.Find(id);
            if (entity != null)
            {
                _context.Reservations.Remove(entity);
            }
            return entity;
        }

        public List<Reservation> List()
        {
            return _context.Reservations.ToList();
        }

        public void Update(Reservation entity)
        {
            _context.Reservations.Update(entity);
        }
    }
}
