using System;
using System.Threading.Tasks;
using HorseRacingBackend.Dtos;
using HorseRacingBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace HorseRacingBackend.Controllers
{
    [Route("api/[controller]")]
    public class HorseController : Controller
    {
        private readonly HorseService _horseService;

        public HorseController(HorseService horseService)
        {
            _horseService = horseService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _horseService.GetAllAsync());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await _horseService.GetByIdAsync(id));
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] HorseDto horse)
        {
            return Ok(await _horseService.CreateAsync(horse));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] HorseDto horse)
        {
            if (id != horse.Id)
            {
                return BadRequest();
            }

            return Ok(await _horseService.UpdateAsync(horse));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _horseService.DeleteAsync(id);

            return NoContent();
        }
    }
}
