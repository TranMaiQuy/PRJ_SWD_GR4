using Microsoft.EntityFrameworkCore;
using PRJ_SWD.DAL.Repository;
using PRJ_SWD.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJ_SWD.DAL.Repository
{
    public class MedicalExaminationRepository : IMedicalExaminationRepository
    {
        private readonly PrjSwdContext _context;

        public MedicalExaminationRepository(PrjSwdContext context)
        {
            _context = context;
        }

        public List<MedicalExamination> GetAll()
        {
            return _context.MedicalExaminations
                .Include(me => me.Customer)
                .Include(me => me.Staff)
                .ToList();
        }

        public MedicalExamination? GetById(int id)
        {
            return _context.MedicalExaminations
                .Include(me => me.Customer)
                .Include(me => me.Staff)
                .FirstOrDefault(me => me.Meid == id);
        }

        public void Add(MedicalExamination me)
        {
            _context.MedicalExaminations.Add(me);
            _context.SaveChanges();
        }

        public void Update(MedicalExamination me)
        {
            _context.MedicalExaminations.Update(me);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var me = _context.MedicalExaminations.Find(id);
            if (me != null)
            {
                _context.MedicalExaminations.Remove(me);
                _context.SaveChanges();
            }
        }
    }

}
