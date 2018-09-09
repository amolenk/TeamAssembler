using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SuperheroesController : Controller
    {
        private static HttpClient Client = new HttpClient();

        public SuperheroesController()
        {
        }

        // GET: api/Superheroes
        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            using (HttpResponseMessage response = await Client.GetAsync(superheroServiceUrl))
            {
                var superheroes = JsonConvert.DeserializeObject<string[]>(await response.Content.ReadAsStringAsync());

                return Json(superheroes);
            }
        }

        private static Uri superheroServiceUrl = new Uri($"{Environment.GetEnvironmentVariable("Services_Superhero_Url")}/api/superheroes");
    }
}