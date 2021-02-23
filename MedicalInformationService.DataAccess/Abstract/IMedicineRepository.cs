using MedicalInformationService.Entities;
using MedicalInformationService.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalInformationService.DataAccess.Abstract
{
    public interface IMedicineRepository
    {
        Task<List<Medicine>> GetAllMedicine();
        Task<Medicine> GetMedicineById(int id);
        Task<Medicine> GetMedicineByName(string name);
        Task<Medicine> CreateMedicine(Medicine medicine, int[] SubstanceIds);
        Task<Medicine> UpdateMedicine(Medicine medicine);
        Task DeleteMedicine(int id);
       
    }
}
