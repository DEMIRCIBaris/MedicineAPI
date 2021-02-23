using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInformationService.Entities.DTO
{
    public class GetStorageMedicineDto
    {
        public GetStorageMedicineDto()
        {
            etkenler = new List<GetActiveSubtanceDto>();
        }

        public string kod { get; set; }
        public string adi { get; set; }
        public string turu { get; set; }
        public string skt { get; set; }
        public List<GetActiveSubtanceDto> etkenler { get; set; }

    }
}
