using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicalInformationService.Entities
{
    public class Medicine
    {    
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Code { get; set; }

        [StringLength(50)]
        [Required]
        public string  Name { get; set; }

        [StringLength(50)]
        [Required]
        public string Type { get; set; }

        [Required]
        public DateTime ExpireDate { get; set; }

        public int? StorageId { get; set; }
        public Storage Storage { get; set; }


        public List<MedicineActiveSubstance> MedicineActiveSubstances { get; set; }
    }
}
