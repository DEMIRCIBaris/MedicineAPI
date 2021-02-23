using MedicalInformationService.DataAccess.Abstract;
using MedicalInformationService.DataAccess.Concrete.Context;
using MedicalInformationService.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalInformationService.DataAccess.Concrete
{
    public class ActiveSubstanceRepository : IActiveSubstanceRepository
    {
        public async Task<ActiveSubstance> CreateActiveSubstance(ActiveSubstance activeSubstance)
        {
            using (var activeSubstanceDbContext = new MyDataContext())
            {
                activeSubstanceDbContext.ActiveSubstances.Add(activeSubstance);
                await activeSubstanceDbContext.SaveChangesAsync();
                return activeSubstance;
            }
        }

        public async Task DeleteActiveSubstance(int id)
        {
            using (var activeSubstanceDbContext = new MyDataContext())
            {
                var deleteActiveSubstance = await GetActiveSubstanceById(id);
                activeSubstanceDbContext.ActiveSubstances.Remove(deleteActiveSubstance);
                await activeSubstanceDbContext.SaveChangesAsync();
            }
        }

        public async Task<ActiveSubstance> GetActiveSubstanceById(int id)
        {
            using (var activeSubstanceDbContext = new MyDataContext())
            {
                return await activeSubstanceDbContext.ActiveSubstances.FindAsync(id);
            }
        }

        public async Task<List<ActiveSubstance>> GetAllActiveSubstance()
        {
            using (var activeSubstanceDbContext = new MyDataContext())
            {
                return await activeSubstanceDbContext.ActiveSubstances.ToListAsync();
            }
        }

        public async Task<ActiveSubstance> UpdateActiveSubstance(ActiveSubstance activeSubstance)
        {
            using (var activeSubstanceDbContext = new MyDataContext())
            {
                activeSubstanceDbContext.ActiveSubstances.Update(activeSubstance);
                await activeSubstanceDbContext.SaveChangesAsync();
                return activeSubstance;
            }
        }
    }
}

