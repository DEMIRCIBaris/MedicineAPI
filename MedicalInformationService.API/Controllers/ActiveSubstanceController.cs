
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
    public class ActiveSubstanceController : ControllerBase
    {
        private IActiveSubstanceService activeSubstanceService;
        public ActiveSubstanceController(IActiveSubstanceService activeSubstanceService)
        {
            this.activeSubstanceService = activeSubstanceService;
        }

        [HttpGet("substance")]
        public async Task<IActionResult> GetAll()
        {
            var substances = await activeSubstanceService.GetAllActiveSubstance();
            return Ok(substances);
        }

        [HttpGet]
        [Route("substance/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var substance = await activeSubstanceService.GetActiveSubstanceById(id);
            if (substance != null)
            {
                return Ok(substance);
            }
            return NotFound();
        }

        [HttpPost("substance")]
        public async Task<IActionResult> AddActiveSubstance([FromBody] ActiveSubstance activeSubstance)
        {
            var createSubstance = await activeSubstanceService.CreateActiveSubstance(activeSubstance);
            return CreatedAtAction("GetAll", new { id = createSubstance.Id },createSubstance);
        }

        [HttpPut("substance")]
        public async Task<IActionResult> UpdateActiveSubstance([FromBody] ActiveSubstance activeSubstance)
        {
            if (await activeSubstanceService.GetActiveSubstanceById(activeSubstance.Id) != null)
            {
                return Ok(await activeSubstanceService.UpdateActiveSubstance(activeSubstance));
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("substance/{id}")]
        public async Task<IActionResult> DeleteActiveSubstance(int id)
        {
            if (await activeSubstanceService.GetActiveSubstanceById(id) != null)
            {
                await activeSubstanceService.DeleteActiveSubstance(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
