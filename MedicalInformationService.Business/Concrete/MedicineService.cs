using MedicalInformationService.Business.Abstract;
using MedicalInformationService.Business.Helpers;
using MedicalInformationService.Business.Helpers.HelperAbstract;
using MedicalInformationService.DataAccess.Abstract;
using MedicalInformationService.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalInformationService.Business.Concrete
{
    public class MedicineService : IMedicineService
    {
        private IMedicineRepository medicineRepository;
        private IMedicineFunctions medicineFunctions;

        public MedicineService(IMedicineRepository medicineRepository, IMedicineFunctions medicineFunctions)
        {
            this.medicineRepository = medicineRepository;
            this.medicineFunctions = medicineFunctions;
        }
        public async Task<Medicine> CreateMedicine(Medicine medicine, int[] SubstanceIds)
        {
            var test = await medicineFunctions.CodeControl(medicine.Code);
            return test ? throw new Exception("Code Mevcuttur") : await medicineRepository.CreateMedicine(medicine, SubstanceIds);

        }

        public async Task DeleteMedicine(int id)
        {
            await medicineRepository.DeleteMedicine(id);
        }

        public async Task<List<Medicine>> GetAllMedicine()
        {
            return await medicineRepository.GetAllMedicine();
        }

        public async Task<Medicine> GetMedicineById(int id)
        {
            return await medicineRepository.GetMedicineById(id);
        }

        public async Task<Medicine> GetMedicineByName(string name)
        {
            return await medicineRepository.GetMedicineByName(name);
        }

        public async Task<Medicine> UpdateMedicine(Medicine medicine)
        {
            return await medicineRepository.UpdateMedicine(medicine);
        }
    }
}
