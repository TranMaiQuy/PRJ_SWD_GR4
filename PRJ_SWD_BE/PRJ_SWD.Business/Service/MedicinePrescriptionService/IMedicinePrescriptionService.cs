using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJ_SWD.Application.DTO;
using PRJ_SWD.Application.ViewModel;
using PRJ_SWD.DAL.Models;

namespace PRJ_SWD.Business.Service.MedicinePrescriptionService
{
    public interface IMedicinePrescriptionService
    {
        void AddPrescription(MedicinePrescriptionDto prescription);
        void DeletePrescription(int id);
        Prescription? GetPrescriptionById(int id);
        List<PrescriptionViewModel> GetAllPrescription();
        Prescription UpdatePrescription(int id, MedicinePrescriptionUpdateDto prescription);
    }
}
