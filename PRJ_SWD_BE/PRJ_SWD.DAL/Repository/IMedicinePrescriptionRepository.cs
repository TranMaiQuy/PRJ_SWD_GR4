using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJ_SWD.DAL.Models;

namespace PRJ_SWD.DAL.Repository
{
    public interface IMedicinePrescriptionRepository
    {
        void Add(Prescription prescription);
        void Delete(int id);
        Prescription? GetById(int id);
        List<Prescription> GetAll();
        Prescription Update(Prescription prescription);

        Account FindStaff(Prescription prescription);
        Account FindCustomer(Prescription prescription);
    }
}
