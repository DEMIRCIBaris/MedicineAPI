using MedicalInformationService.Business.Abstract;
using MedicalInformationService.DataAccess.Abstract;
using MedicalInformationService.Entities;
using MedicalInformationService.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalInformationService.Business.Concrete
{
    public class StorageService : IStorageService
    {
        private IStorageRepository storageRepository;
        public StorageService(IStorageRepository storageRepository)
        {
            this.storageRepository = storageRepository;
        }
        public async Task<Storage> CreateStoragee(Storage storage)
        {
            return await storageRepository.CreateStoragee(storage);
        }

        public async Task DeleteStorage(int id)
        {
            await storageRepository.DeleteStorage(id);
        }

        public async Task<List<Storage>> GetAllStorage()
        {
            return await storageRepository.GetAllStorage();
        }

        public async Task<List<GetStorageMedicineDto>> GetByStorageCode(string storageCode)
        {
            return await storageRepository.GetByStorageCode(storageCode);
        }

        public async Task<GetStorageMedicineDto> GetByStorageCodeAndMedicineCode(string storageCode, string medicineCode)
        {
            return await storageRepository.GetByStorageCodeAndMedicineCode(storageCode,medicineCode);
        }

        public async Task<Storage> GetStorageById(int id)
        {
            return await storageRepository.GetStorageById(id);
        }

        public async Task<Storage> UpdateStorage(Storage storage)
        {
            return await storageRepository.UpdateStorage(storage);
        }
    }
}
