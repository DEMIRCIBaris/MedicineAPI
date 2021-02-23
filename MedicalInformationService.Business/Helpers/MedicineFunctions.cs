using MedicalInformationService.Business.Abstract;
using MedicalInformationService.Business.Helpers.HelperAbstract;
using MedicalInformationService.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalInformationService.Business.Helpers
{
    public  class MedicineFunctions : IMedicineFunctions
    {
        private readonly IMedicineRepository medicineRepository;

        public MedicineFunctions(IMedicineRepository medicineRepository)
        {
            this.medicineRepository = medicineRepository;
        }
        public async Task<bool> CodeControl(string code)
        {
            var medicines = await medicineRepository.GetAllMedicine();
            var codes = medicines.Select(i => i.Code);
            return codes.Any(i => i == code);
        }
    }
}
