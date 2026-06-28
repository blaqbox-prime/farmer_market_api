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
        private ProduceRepository _produceRepository;
        

        [HttpGet]
        public IActionResult GetProduceListings()
        {
            return Ok(_produceRepository.getAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetProduceListingById(int id)
        { 
            try 
            { 
                var produce = _produceRepository.GetById(id);
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
        public IActionResult GetProduceListingSummary(int id)
        {
            var produce = _produceRepository.GetById(id);
            if(produce == null)
            {
                return NotFound();
            } else
            {
                return Ok(produce.GetFormattedSummary());
            }
        }

        [HttpPost]
        public IActionResult CreateProduceListing([FromBody] CreateProduceDTO newListing)
        {
            try
            {
                var createdProduce = _produceRepository.AddProduce(
                    new ProduceListing
                    {
                        FarmerId = newListing.FarmerId,
                        ProduceName = newListing.ProduceName,
                        Category = newListing.Category,
                        PricePerKg = newListing.PricePerKg,
                        QuantityKg = newListing.QuantityKg,
                        IsAvailable = newListing.IsAvailable,
                        HarvestDate = newListing.HarvestDate,
                        DateListed = newListing.DateListed,
                        Description = newListing.Description
                    });
                return Created("api/produce/" + createdProduce.ListingId, createdProduce);
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