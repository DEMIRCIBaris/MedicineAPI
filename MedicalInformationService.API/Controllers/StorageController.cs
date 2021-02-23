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
    [Route("rest/v1")]
    [ApiController]
    [Authorize]
    public class StorageController : ControllerBase
    {
        private IStorageService storageService;
        public StorageController(IStorageService storageService)
        {
            this.storageService = storageService;
        }

        [HttpGet("depo")]
        public async Task<IActionResult> GetAll()
        {
            var stor = await storageService.GetAllStorage();
            //stor.Where(i=>i.Code=="" && i.Medicines.FirstOrDefault(i=>i.Code==""))
            return Ok(stor);
        }

        [HttpGet]
        [Route("depo/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var stor = await storageService.GetStorageById(id);
            if (stor != null)
            {
                return Ok(stor);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("depo/{code}")]
        public async Task<IActionResult> GetById(string code)
        {
            var stor = await storageService.GetByStorageCode(code);
            if (stor != null)
            {
                return Ok(stor);
            }
            return NotFound();
        }

        [HttpGet("depo/{storageCode}/ilac/{medicineCode}")]
        //[Route("storage/{id}")]
        public async Task<IActionResult> GetByStorageCodeAndMedicineCode(string storageCode, string medicineCode)
        {
            var stor = await storageService.GetByStorageCodeAndMedicineCode(storageCode,medicineCode);
            if (stor != null)
            {
                return Ok(stor);
            }
            return NotFound();
        }

        [HttpPost("depo")]
        public async Task<IActionResult> AddStorage([FromBody] Storage storage)
        {
            var createStorage = await storageService.CreateStoragee(storage);
            return CreatedAtAction("GetAll", new { id = createStorage.Id }, createStorage);
        }

        [HttpPut("depo")]
        public async Task<IActionResult> UpdateStorage([FromBody] Storage storage)
        {
            if (await storageService.GetStorageById(storage.Id) != null)
            {
                return Ok(await storageService.UpdateStorage(storage));
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("depo/{id}")]
        public async Task<IActionResult> DeleteStorage(int id)
        {
            if (await storageService.GetStorageById(id) != null)
            {
                await storageService.DeleteStorage(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
