using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Model;
using System.Text;
using System.Net.Http.Headers;

namespace FrontEnd.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TeamsController : Controller
    {
        private static HttpClient Client = new HttpClient();

        public TeamsController()
        {
        }

        // GET: api/Teams
        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            using (HttpResponseMessage response = await Client.GetAsync(teamServiceUrl))
            {
                var teams = JsonConvert.DeserializeObject<Team[]>(await response.Content.ReadAsStringAsync());

                return Json(teams);
            }
        }

        // PUT: api/Teams/name
        [HttpPut("{name}")]
        public async Task<IActionResult> Put(string name, [FromBody]string[] members)
        {
            PowerGrid powerGrid = await CalculatePowerGridAsync(members);

            StringContent putContent = new StringContent(
                JsonConvert.SerializeObject(new Team
                {
                    Name = name,
                    Members = members,
                    PowerGrid = powerGrid,
                    Score = (powerGrid.Intelligence
                        + powerGrid.Strength
                        + powerGrid.Speed
                        + powerGrid.Durability
                        + powerGrid.EnergyProjection
                        + powerGrid.FightingSkills) / 6
                }),
                Encoding.UTF8,
                "application/json");

            putContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using (HttpResponseMessage response = await Client.PutAsync($"{teamServiceUrl}/{name}", putContent))
            {
                return new ContentResult()
                {
                    StatusCode = (int)response.StatusCode,
                    Content = await response.Content.ReadAsStringAsync()
                };
            }
        }

        // DELETE: api/Teams/name
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            using (HttpResponseMessage response = await Client.DeleteAsync($"{teamServiceUrl}/{name}"))
            {
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return StatusCode((int)response.StatusCode);
                }
            }

            return Ok();
        }

        private static Uri superheroServiceUrl = new Uri($"{Environment.GetEnvironmentVariable("Services_Superhero_Url")}/api/superheroes");

        private static Uri teamServiceUrl = new Uri($"{Environment.GetEnvironmentVariable("Services_Team_Url")}/api/teams");

        private static async Task<PowerGrid> CalculatePowerGridAsync(string[] members)
        {
            int intelligence = 0;
            int strength = 0;
            int speed = 0;
            int durability = 0;
            int energyProjection = 0;
            int fightingSkills = 0;

            foreach (string member in members)
            {
                using (HttpResponseMessage response = await Client.GetAsync($"{superheroServiceUrl}/{member}"))
                {
                    Superhero superhero = JsonConvert.DeserializeObject<Superhero>(await response.Content.ReadAsStringAsync());

                    intelligence += superhero.Intelligence;
                    strength += superhero.Strength;
                    speed += superhero.Speed;
                    durability += superhero.Durability;
                    energyProjection += superhero.EnergyProjection;
                    fightingSkills += superhero.FightingSkills;
                }
            }

            int teamSize = members.Length;

            return new PowerGrid
            {
                Intelligence = intelligence / teamSize,
                Strength = strength / teamSize,
                Speed = speed / teamSize,
                Durability = durability / teamSize,
                EnergyProjection = energyProjection / teamSize,
                FightingSkills = fightingSkills / teamSize
            };
        }
    }
}