using Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly PokemonAPIService _pokemonAPIService;
        public PokemonController(PokemonAPIService pokemonAPIService)
        {
            _pokemonAPIService = pokemonAPIService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getBerry([FromRoute]int id)
        {
            return Ok(await _pokemonAPIService.GetBerryAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostBerry()
        {
            return Ok(await _pokemonAPIService.PostBerryAsync("code"));
        }
    }
}
