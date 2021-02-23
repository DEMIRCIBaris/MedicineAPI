using MedicalInformationService.Business.Abstract;
using MedicalInformationService.DataAccess.Abstract;
using MedicalInformationService.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalInformationService.Business.Concrete
{
    public class ActiveSubstanceService : IActiveSubstanceService
    {
        private IActiveSubstanceRepository activeSubstanceRepository;
        public ActiveSubstanceService(IActiveSubstanceRepository activeSubstanceRepository)
        {
            this.activeSubstanceRepository = activeSubstanceRepository;
        }
        public async Task<ActiveSubstance> CreateActiveSubstance(ActiveSubstance activeSubstance)
        {
            return await activeSubstanceRepository.CreateActiveSubstance(activeSubstance);
        }

        public async Task DeleteActiveSubstance(int id)
        {
            await activeSubstanceRepository.DeleteActiveSubstance(id);
        }

        public async Task<ActiveSubstance> GetActiveSubstanceById(int id)
        {
            return await activeSubstanceRepository.GetActiveSubstanceById(id);
        }

        public async Task<List<ActiveSubstance>> GetAllActiveSubstance()
        {
            return await activeSubstanceRepository.GetAllActiveSubstance();
        }

        public async Task<ActiveSubstance> UpdateActiveSubstance(ActiveSubstance activeSubstance)
        {
            return await activeSubstanceRepository.UpdateActiveSubstance(activeSubstance);
        }
    }
}
