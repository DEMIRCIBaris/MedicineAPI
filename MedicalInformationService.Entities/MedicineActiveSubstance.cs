using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInformationService.Entities
{
    public class MedicineActiveSubstance
    {
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }

        public int ActiveSubstanceId { get; set; }
        public ActiveSubstance ActiveSubstance { get; set; }
    }
}
