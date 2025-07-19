using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJ_SWD.Application.ViewModel;
using PRJ_SWD.DAL.Infracstructure;
using PRJ_SWD.DAL.Models;
using PRJ_SWD.DAL.Repository;

namespace PRJ_SWD.Business.Service.MedicinePrescriptionService
{
    public class MedicinePrescriptionService : IMedicinePrescriptionService
    {
        public IMedicinePrescriptionRepository medicinePrescriptionRepository;
        public IUnitOfWork unitOfWork;
        public MedicinePrescriptionService(IMedicinePrescriptionRepository medicinePrescriptionRepository,IUnitOfWork unitOfWork )
        {
            this.medicinePrescriptionRepository = medicinePrescriptionRepository;
            this.unitOfWork = unitOfWork;
        }

        public void AddPrescription(Prescription prescription)
        {

            medicinePrescriptionRepository.Add(prescription);
            unitOfWork.Commit();
        }

        public void DeletePrescription(int id)
        {
            medicinePrescriptionRepository.Delete(id);
            unitOfWork.Commit();
        }

        public List<PrescriptionViewModel> GetAllPrescription()
        {
            var list = medicinePrescriptionRepository.GetAll();
            var result = new List<PrescriptionViewModel>();

            foreach (var item in list)
            {
                var prescription = medicinePrescriptionRepository.GetById(item.PrescriptionId);
                if (prescription == null)
                    continue;

                var staff = medicinePrescriptionRepository.FindStaff(prescription);
                var customer = medicinePrescriptionRepository.FindCustomer(prescription);

                result.Add(new PrescriptionViewModel
                {
                    PrescriptionId = prescription.PrescriptionId,
                    DoctorName = staff.PersonName,             // hoặc staff.Name tùy property bạn có
                    CustomerName = customer.PersonName,        // hoặc customer.Name
                    MedicineName = prescription.MedicineId,  // hiện tại là int, nếu cần string thì phải lấy tên thuốc
                    Dosage = prescription.Dosage,
                    Note = prescription.Note,
                    TotalCost = prescription.TotalCost
                });
            }

            return result;
        }

        public Prescription? GetPrescriptionById(int id)
        {
           return  medicinePrescriptionRepository.GetById(id);
        }

        public Prescription UpdatePrescription(int id, Prescription prescription)
        {
            var existeingPrescription = medicinePrescriptionRepository.GetById(id);
           
                existeingPrescription.PrescriptionId = id;
                existeingPrescription.ExaminationId = prescription.ExaminationId;
                existeingPrescription.DoctorId = prescription.DoctorId;
                existeingPrescription.CustomerId = prescription.CustomerId;
                existeingPrescription.MedicineId = prescription.MedicineId;
                existeingPrescription.Dosage = prescription.Dosage;
                existeingPrescription.Note = prescription.Note;
                existeingPrescription.TotalCost = prescription.TotalCost;
                var update = medicinePrescriptionRepository.Update(existeingPrescription);
                unitOfWork.Commit();
            return update;
        }
    }
}
