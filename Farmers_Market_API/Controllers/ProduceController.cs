using Farmers_Market_API.Models;
using Microsoft.AspNetCore.Mvc;
using Farmers_Market_API.Enums;
using Farmers_Market_API.Repositories;
using Farmers_Market_API.DTOs;
using Farmers_Market_API.Exceptions;

namespace Farmers_Market_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProduceController(ProduceRepository produceRepository) : ControllerBase
    {
        private readonly ProduceRepository _produceRepository = produceRepository;
        

        [HttpGet]
        public async Task<IActionResult> GetProduceListings()
        {
            return Ok(await _produceRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduceListingById(int id)
        { 
            try 
            { 
                var produce = await _produceRepository.GetByIdAsync(id);
                return Ok(produce);
            } 
            
            catch (ListingNotFoundException ex)
            {
                return NotFound(ex.Message);
            } 
            
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/summary")]
        public async Task<IActionResult> GetProduceListingSummary(int id)
        {
            var produce = await _produceRepository.GetByIdAsync(id);
            if(produce == null)
            {
                return NotFound();
            } else
            {
                return Ok(produce.GetFormattedSummary());
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduceListing([FromBody] CreateProduceDTO newListing)
        {
            try
            {
                await _produceRepository.AddAsync(new ProduceListing(newListing));

                return Created();
            }
            catch (InvalidProduceFormatException ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("available")]
        public IActionResult GetAvailableProduce(){
            
            return Ok(_produceRepository.GetAvailable());
        }

        [HttpGet("category/{category}")]
        public IActionResult GetProduceByCategory([FromRoute] Category category)
        {
           return Ok(_produceRepository.GetByCategory(category)); 
        }
        


    }
}