using PRJ_SWD.Application.DTO;
using PRJ_SWD.Application.ViewModel;
using PRJ_SWD.DAL.Models;
using PRJ_SWD.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJ_SWD.Business.Service.MedicalExam
{
    public class MedicalExaminationService : IMedicalExaminationService
    {
        private readonly IMedicalExaminationRepository _repo;

        public MedicalExaminationService(IMedicalExaminationRepository repo)
        {
            _repo = repo;
        }

        public List<MedicalExaminationViewModel> GetAll()
        {
            return _repo.GetAll().Select(me => new MedicalExaminationViewModel
            {
                Meid = me.Meid,
                CustomerName = me.Customer.PersonName,
                StaffName = me.Staff.PersonName,
                ExaminationDate = me.ExaminationDate,
                Symptoms = me.Symptoms,
                Diagnosis = me.Diagnosis,
                ExaminationFee = me.ExaminationFee
            }).ToList();
        }

        public MedicalExaminationDTO? GetById(int id)
        {
            var me = _repo.GetById(id);
            if (me == null) return null;

            return new MedicalExaminationDTO
            {
                Meid = me.Meid,
                ReservationId = me.ReservationId,
                ExaminationDate = me.ExaminationDate,
                Symptoms = me.Symptoms,
                Diagnosis = me.Diagnosis,
                Notes = me.Notes,
                ExaminationFee = me.ExaminationFee,
                StaffId = me.StaffId,
                CustomerId = me.CustomerId
            };
        }

        public void Create(MedicalExaminationDTO dto)
        {
            var me = new MedicalExamination
            {
                ReservationId = dto.ReservationId,
                ExaminationDate = dto.ExaminationDate,
                Symptoms = dto.Symptoms,
                Diagnosis = dto.Diagnosis,
                Notes = dto.Notes,
                ExaminationFee = dto.ExaminationFee,
                StaffId = dto.StaffId,
                CustomerId = dto.CustomerId
            };

            _repo.Add(me);
        }

        public void Update(MedicalExaminationDTO dto)
        {
            var me = _repo.GetById(dto.Meid);
            if (me != null)
            {
                me.ReservationId = dto.ReservationId;
                me.ExaminationDate = dto.ExaminationDate;
                me.Symptoms = dto.Symptoms;
                me.Diagnosis = dto.Diagnosis;
                me.Notes = dto.Notes;
                me.ExaminationFee = dto.ExaminationFee;
                me.StaffId = dto.StaffId;
                me.CustomerId = dto.CustomerId;

                _repo.Update(me);
            }
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }

}
