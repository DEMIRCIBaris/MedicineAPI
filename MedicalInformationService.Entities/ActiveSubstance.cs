using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace MedicalInformationService.Entities
{
    
    public class ActiveSubstance
    {
       
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string SubstanceName { get; set; }

        public List<MedicineActiveSubstance> MedicineActiveSubstances { get; set; }

    }
}
