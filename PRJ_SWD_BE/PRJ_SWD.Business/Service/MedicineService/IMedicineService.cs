using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJ_SWD.DAL.Models;


namespace PRJ_SWD.Business.Service.MedicineService
{
    public interface IMedicineService
    {
        void AddMedicine(Medicine medicine);
        void DeleteMedicine(int id);
        Medicine? GetMedicineById(int id);
        List<Medicine> GetAllMedicine();
        void UpdateMedicine(Medicine medicine);
    }
}
