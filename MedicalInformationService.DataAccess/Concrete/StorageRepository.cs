using MedicalInformationService.DataAccess.Abstract;
using MedicalInformationService.DataAccess.Concrete.Context;
using MedicalInformationService.Entities;
using MedicalInformationService.Entities.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalInformationService.DataAccess.Concrete
{
    public class StorageRepository : IStorageRepository
    {
        public async Task<Storage> CreateStoragee(Storage storage)
        {
            using (var storageDbContext = new MyDataContext())
            {
                storageDbContext.Storages.Add(storage);
                await storageDbContext.SaveChangesAsync();
                return storage;
            }
        }

        public async Task DeleteStorage(int id)
        {
            using (var storageDbContext = new MyDataContext())
            {
                var deleteStorage = await GetStorageById(id);
                storageDbContext.Storages.Remove(deleteStorage);
                await storageDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Storage>> GetAllStorage()
        {
            using (var storageDbContext = new MyDataContext())
            {
                return await storageDbContext.Storages.ToListAsync();
            }
        }

        public async Task<List<GetStorageMedicineDto>> GetByStorageCode(string storageCode)
        {
            using (var storageDbContext = new MyDataContext())
            {
                var queryableStroges = storageDbContext.Storages.Include(i => i.Medicines).ThenInclude(i => i.MedicineActiveSubstances).ThenInclude(i => i.ActiveSubstance);
                var storage = await queryableStroges.FirstOrDefaultAsync(i => i.Code == storageCode);
                var temp = new List<GetStorageMedicineDto>();

                foreach (var medicine in storage.Medicines)
                {
                    var model = new GetStorageMedicineDto();

                    model.adi = medicine.Name;
                    model.kod = medicine.Code;
                    model.skt = medicine.ExpireDate.ToString("dd/MMMM/yyyy");
                    model.turu = medicine.Type;

                    foreach (var item in medicine.MedicineActiveSubstances)
                    {
                        model.etkenler.Add(new GetActiveSubtanceDto { etkenadi = item.ActiveSubstance.SubstanceName });
                    }

                    temp.Add(model);

                }

                return temp;

            }
        }

        public async Task<GetStorageMedicineDto> GetByStorageCodeAndMedicineCode(string storageCode, string medicineCode)
        {
            using (var storageDbContext = new MyDataContext())
            {
                var queryableStroges = storageDbContext.Storages.Include(i => i.Medicines).ThenInclude(i=>i.MedicineActiveSubstances).ThenInclude(i=>i.ActiveSubstance);
                var storage = await  queryableStroges.FirstOrDefaultAsync(i => i.Code == storageCode);
                var medicine = storage.Medicines.FirstOrDefault(i => i.Code == medicineCode);

                var model = new GetStorageMedicineDto();
                model.adi = medicine.Name;
                model.kod = medicine.Code;
                model.skt = medicine.ExpireDate.ToString("dd/MMMM/yyyy");
                model.turu = medicine.Type;
                foreach (var item in medicine.MedicineActiveSubstances)
                {
                    model.etkenler.Add(new GetActiveSubtanceDto { etkenadi = item.ActiveSubstance.SubstanceName });
                }

                return model;

            }
        }

        public async Task<Storage> GetStorageById(int id)
        {
            using (var storageDbContext = new MyDataContext())
            {
                return await storageDbContext.Storages.FindAsync(id);

            }
        }
        public async Task<Storage> UpdateStorage(Storage storage)
        {
            using (var storageDbContext = new MyDataContext())
            {
                storageDbContext.Storages.Update(storage);
                await storageDbContext.SaveChangesAsync();
                return storage;
            }
        }
    }
}
