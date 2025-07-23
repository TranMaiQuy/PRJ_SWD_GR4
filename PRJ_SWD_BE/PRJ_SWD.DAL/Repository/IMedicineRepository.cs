using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJ_SWD.DAL.Models;

namespace PRJ_SWD.DAL.Repository
{
    public interface IMedicineRepository
    {
        void Add(Medicine medicine);
        void Delete(int id);
        Medicine? GetById(int id);
        List<Medicine> GetAll();
        void Update(Medicine medicine);
    }
}
