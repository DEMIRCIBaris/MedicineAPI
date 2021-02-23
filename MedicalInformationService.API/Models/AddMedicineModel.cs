using MedicalInformationService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalInformationService.API.Models
{
    public class AddMedicineModel
    {
        public Medicine Medicine { get; set; }
        public int[] Substance { get; set; }
        public int? StorageId { get; set; }
    }
}
