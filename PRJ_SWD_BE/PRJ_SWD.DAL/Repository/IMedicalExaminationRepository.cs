using PRJ_SWD.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJ_SWD.DAL.Repository
{
    public interface IMedicalExaminationRepository
    {
        List<MedicalExamination> GetAll();
        MedicalExamination? GetById(int id);
        void Add(MedicalExamination me);
        void Update(MedicalExamination me);
        void Delete(int id);
    }

}
