using MedicalInformationService.DataAccess.Abstract;
using MedicalInformationService.DataAccess.Concrete.Context;
using MedicalInformationService.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalInformationService.DataAccess.Concrete
{
    public class MedicineRepository : IMedicineRepository
    {
        public async Task<Medicine> CreateMedicine(Medicine medicine, int[] SubstanceIds)
        {
            using (var medicineDbContext = new MyDataContext())
            {

                medicineDbContext.Medicines.Add(medicine);
                
                foreach (var item in SubstanceIds)
                {
                    var subtance = await medicineDbContext.ActiveSubstances.Include(i => i.MedicineActiveSubstances).FirstOrDefaultAsync(i => i.Id == item);

                    var mac = new MedicineActiveSubstance();
                    mac.Medicine = medicine;
                    mac.ActiveSubstance = subtance;

                    subtance.MedicineActiveSubstances.Add(mac);

                }

                await medicineDbContext.SaveChangesAsync();

                return medicine;
            }
        }

        public async Task DeleteMedicine(int id)
        {
            using (var medicineDbContext = new MyDataContext())
            {
                var deleteMedicine = await GetMedicineById(id);
                medicineDbContext.Medicines.Remove(deleteMedicine);
                await medicineDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Medicine>> GetAllMedicine()
        {
            using (var medicineDbContext = new MyDataContext())
            {
                return await medicineDbContext.Medicines.ToListAsync();
            }
        }

        public async Task<Medicine> GetMedicineById(int id)
        {
            using (var medicineDbContext = new MyDataContext())
            {
                return await medicineDbContext.Medicines.FindAsync(id);
            }
        }

        public async Task<Medicine> GetMedicineByName(string name)
        {
            using (var medicineDbContext = new MyDataContext())
            {
                var medicine = await medicineDbContext.Medicines.FirstOrDefaultAsync(i=>i.Name==name);
                 return medicine;
            }
        }

        public async Task<Medicine> UpdateMedicine(Medicine medicine)
        {
            using (var medicineDbContext = new MyDataContext())
            {
                medicineDbContext.Medicines.Update(medicine);
                await medicineDbContext.SaveChangesAsync();
                return medicine;
            }

        }
    }
}
