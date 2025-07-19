using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PRJ_SWD.DAL.Models;

namespace PRJ_SWD.DAL.Repository
{
    public class MedicinePrescriptionRepository : IMedicinePrescriptionRepository
    {
        private PrjSwdContext _context;
        public MedicinePrescriptionRepository(PrjSwdContext context)
        {
            _context = context;
        }
        public void Add(Prescription prescription)
        {
           _context.Prescriptions.Add(prescription);
        }

        public void Delete(int id)
        {
            var prescription = _context.Prescriptions.Include(a => a.Services).Include(a => a.Orders).FirstOrDefault(a => a.PrescriptionId == id);
            if (prescription != null)
                return;
            prescription.Services.Clear();
            prescription.Orders.Clear();
            _context.Prescriptions.Remove(prescription);
      
        }

        public List<Prescription> GetAll()
        {
            return _context.Prescriptions.ToList();
        }

        public Prescription? GetById(int id)
        {
            return _context.Prescriptions.Include(a => a.Services).FirstOrDefault(a => a.PrescriptionId == id);
        }

        public Prescription Update(Prescription prescription)
        {
            _context.Update(prescription);
            return prescription;
        }
      

       
        public Account FindStaff(Prescription prescription)
        {
            return _context.Accounts
                .FirstOrDefault(a => a.PersonId == prescription.DoctorId);
        }

        public Account FindCustomer(Prescription prescription)
        {
            return _context.Accounts.FirstOrDefault(a => a.PersonId == prescription.CustomerId);
        }
    }
}
