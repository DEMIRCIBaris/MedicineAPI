﻿using MedicalInformationService.Entities;
using MedicalInformationService.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalInformationService.DataAccess.Abstract
{
    public interface IStorageRepository
    {
        Task<List<Storage>> GetAllStorage();
        Task<Storage> GetStorageById(int id);
        Task<Storage> CreateStoragee(Storage storage);
        Task<Storage> UpdateStorage(Storage storage);
        Task DeleteStorage(int id);

        Task<List<GetStorageMedicineDto>> GetByStorageCode(string storageCode);
        Task<GetStorageMedicineDto> GetByStorageCodeAndMedicineCode(string storageCode,string medicineCode);
    }
}
