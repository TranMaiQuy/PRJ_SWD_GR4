using PRJ_SWD.Application.DTO;
using PRJ_SWD.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJ_SWD.Business.Service.MedicalExam
{
    public interface IMedicalExaminationService
    {
        List<MedicalExaminationViewModel> GetAll();
        MedicalExaminationDTO? GetById(int id);
        void Create(MedicalExaminationDTO dto);
        void Update(MedicalExaminationDTO dto);
        void Delete(int id);
    }

}
