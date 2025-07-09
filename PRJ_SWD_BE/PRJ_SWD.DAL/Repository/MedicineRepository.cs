using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJ_SWD.DAL.Models;

namespace PRJ_SWD.DAL.Repository
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly PrjSwdContext _context;
        public MedicineRepository(PrjSwdContext context)
        {
            _context = context;
        }

        public void Add(Medicine medicine)
        {
            _context.Medicines.Add(medicine);
        }

        public void Delete(int id)
        {
           var medicine = _context.Medicines.FirstOrDefault(a => a.MedicineId == id);
            _context.Medicines.Remove(medicine);
        }

        public Medicine? GetById(int id)
        {
            return _context.Medicines.FirstOrDefault(s => s.MedicineId == id);
        }

        public List<Medicine> GetAll()
        {
            return _context.Medicines.ToList();
        }

        public Medicine Update(Medicine medicine)
        {
            _context.Medicines.Update(medicine);
            return medicine;
        }
    }
}
