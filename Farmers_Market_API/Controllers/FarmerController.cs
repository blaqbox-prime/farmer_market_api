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
    public class FarmerController : ControllerBase
    {
        private FarmerRepository _repository = new FarmerRepository();

        [HttpGet]
        public IActionResult GetListOfFarmers()
        {
            return Ok(_repository.GetAll());
        }

        [HttpPost]
        public IActionResult CreateFarmer([FromBody] Farmer farmer)
        {

                var createdFarmer = _repository.Create(farmer);
                return Created($"api/farmer/{createdFarmer.FarmerId}", createdFarmer);
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] int farmerId)
        {
            try 
            {
                var deletedFarmer = _repository.Delete(farmerId);
                return NoContent();
            }
            catch(FarmerNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateFarmers([FromBody] Farmer updatedFarmer)
        {
            try 
            {
                var updatedFarmerResult = _repository.UpdateFarmer(updatedFarmer);
                return Ok(updatedFarmerResult);
            }
            catch (FarmerNotFoundException ex) 
            { 
                return NotFound(ex.Message);
            }
        }
     }
}