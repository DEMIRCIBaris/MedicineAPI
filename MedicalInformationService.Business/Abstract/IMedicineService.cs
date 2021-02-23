using MedicalInformationService.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalInformationService.Business.Abstract
{
    public interface IMedicineService
    {
        Task<List<Medicine>> GetAllMedicine();
        Task<Medicine> GetMedicineById(int id);
        Task<Medicine> GetMedicineByName(string name);
        Task<Medicine> CreateMedicine(Medicine medicine, int[] SubstanceIds);
        Task<Medicine> UpdateMedicine(Medicine medicine);
        Task DeleteMedicine(int id);
    }
}
