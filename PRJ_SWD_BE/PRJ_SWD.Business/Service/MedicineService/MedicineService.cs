﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJ_SWD.Application.DTO;
using PRJ_SWD.Application.ViewModel;
using PRJ_SWD.DAL.Infracstructure;
using PRJ_SWD.DAL.Models;
using PRJ_SWD.DAL.Repository;

namespace PRJ_SWD.Business.Service.MedicineService
{
    public class MedicineService : IMedicineService
    {
        public IMedicineRepository repository;
        public IUnitOfWork unitOfWork;
        public MedicineService(IMedicineRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
        public void AddMedicine(Medicine medicine)
        {
           
            repository.Add(medicine);
            unitOfWork.Commit();
        }

        public void DeleteMedicine(int id)
        {
            repository.Delete(id);
            unitOfWork.Commit();
        }

        public List<Medicine> GetAllMedicine()
        {
            var list = repository.GetAll();
            
            return list;
        }

        public Medicine GetMedicineById(int id)
        {
            return repository.GetById(id);
        }

        public Medicine UpdateMedicine(int id, Medicine medicine)
        {
            var existingMedicine = repository.GetById(id);
            if (existingMedicine == null) return null;

            // Cập nhật từng trường
            existingMedicine.Name = medicine.Name;
            existingMedicine.Quantity = medicine.Quantity;
            existingMedicine.Price = medicine.Price;

            unitOfWork.Commit(); // Lưu thay đổi

            return existingMedicine;
        }
    }
}
