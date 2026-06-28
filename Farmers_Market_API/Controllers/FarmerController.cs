using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Farmers_Market_API.Exceptions;
using Farmers_Market_API.Models;
using Farmers_Market_API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Farmers_Market_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FarmerController(FarmerRepository farmerRepository) : ControllerBase
    {
        private FarmerRepository _repository = farmerRepository;

        [HttpGet]
        public async Task<IActionResult> GetListOfFarmers()
        {
            return Ok(await  _repository.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateFarmer([FromBody] Farmer farmer)
        {

                await _repository.AddAsync(farmer);
                return Created();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int farmerId)
        {
            try 
            {
                await _repository.DeleteAsync(farmerId);
                return NoContent();
            }
            catch(FarmerNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFarmers([FromBody] Farmer updatedFarmer)
        {
            try 
            {
                await _repository.UpdateAsync(updatedFarmer);
                return Ok();
            }
            catch (FarmerNotFoundException ex) 
            { 
                return NotFound(ex.Message);
            }
        }
     }
}