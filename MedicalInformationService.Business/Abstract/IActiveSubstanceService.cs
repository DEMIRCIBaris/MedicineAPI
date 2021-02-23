using MedicalInformationService.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalInformationService.Business.Abstract
{
    public interface IActiveSubstanceService
    {
        Task<List<ActiveSubstance>> GetAllActiveSubstance();
        Task<ActiveSubstance> GetActiveSubstanceById(int id);
        Task<ActiveSubstance> CreateActiveSubstance(ActiveSubstance activeSubstance);
        Task<ActiveSubstance> UpdateActiveSubstance(ActiveSubstance activeSubstance);
        Task DeleteActiveSubstance(int id);
    }
}
