using Api.Extensions;
using Business.Models;
using Business.Services; 
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftController :  ControllerBase
    {
        private readonly ILogger<AircraftController> _logger;
        private readonly IAircraftService aircraftService;

        public AircraftController(ILogger<AircraftController> logger,
            IAircraftService aircraftService)
        {
            _logger = logger;
            this.aircraftService = aircraftService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AircraftDetailModel>>> GetAll([FromQuery]AircraftParams aircraftParams)
        {
            var aircrafts = await aircraftService.GetAll(aircraftParams);
            Response.AddpaginationHeader(aircrafts.SkipCount, aircrafts.PageSize, aircrafts.TotalCount, aircrafts.TotalPages);
            return Ok(aircrafts);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<AircraftDetailModel> Get(int id)
        {
            return await aircraftService.GetById(id);
        }

        [HttpPost]
        public async Task Create(AircraftDetailModel aircraftDetail)
        {
             await aircraftService.Add(aircraftDetail);
        }

        [HttpDelete("{id:int}")]
        public async Task Delete(int id)
        {
            await aircraftService.Delete(id);
        }

        [HttpPut("{id:int}")]
        public async Task Update(int id, AircraftDetailModel aircraftDetail)
        {
            aircraftDetail.Id = id;
            await aircraftService.Update(aircraftDetail);
        }
    }
}
