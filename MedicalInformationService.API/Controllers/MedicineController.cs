using MedicalInformationService.API.Models;
using MedicalInformationService.Business.Abstract;
using MedicalInformationService.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalInformationService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MedicineController : ControllerBase
    {
        private IMedicineService medicineService;
        public MedicineController(IMedicineService medicineService)
        {
            this.medicineService = medicineService;
        }

        [HttpGet("ilac")]
        public async Task<IActionResult> GetAll()
        {
            var med = await medicineService.GetAllMedicine();
            return Ok(med);
        }

        [HttpGet]
        [Route("medicine1/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var med = await medicineService.GetMedicineById(id);
            if (med != null)
            {
                return Ok(med);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("ilac/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var med = await medicineService.GetMedicineByName(name);
            if (med != null)
            {
                return Ok(med);
            }
            return NotFound();
        }

        [HttpPost("ilac")]
        public async Task<IActionResult> AddMedicine([FromBody] AddMedicineModel model)
        {
            var createMedicine = await medicineService.CreateMedicine(model.Medicine,model.Substance);
            return CreatedAtAction("GetAll", new { id = createMedicine.Id }, createMedicine);
        }

        [HttpPut("ilac")]
        public async Task<IActionResult> UpdateMedicine([FromBody] Medicine medicine)
        {
            if (await medicineService.GetMedicineById(medicine.Id) != null)
            {
                return Ok(await medicineService.UpdateMedicine(medicine));
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("ilac/{id}")]
        public async Task<IActionResult> DeleteMedicine(int id)
        {
            if (await medicineService.GetMedicineById(id) != null)
            {
                await medicineService.DeleteMedicine(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
