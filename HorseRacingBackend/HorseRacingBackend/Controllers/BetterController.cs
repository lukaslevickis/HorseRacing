using System;
using System.Threading.Tasks;
using HorseRacingBackend.Dtos;
using HorseRacingBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace HorseRacingBackend.Controllers
{
    [Route("api/[controller]")]
    public class BetterController : Controller
    {
        private readonly BetterService _betterService;

        public BetterController(BetterService betterService)
        {
            _betterService = betterService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _betterService.GetAllAsync());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await _betterService.GetByIdAsync(id));
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BetterDto better)
        {
            return Ok(await _betterService.CreateAsync(better));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] BetterDto better)
        {
            if (id != better.Id)
            {
                return BadRequest();
            }

            return Ok(await _betterService.UpdateAsync(better));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _betterService.DeleteAsync(id);

            return NoContent();
        }

        [HttpGet]
        [Route("horse/{id}")]
        public async Task<ActionResult> GetHorseBettersById(int id)
        {
            return Ok(await _betterService.GetAllAsync(id));
        }
    }
}
