using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Newtonsoft.Json;

namespace TeamService.Controllers
{
    [Route("api/[controller]")]
    public class TeamsController : Controller
    {
        private const string DataFolder = "data";

        public TeamsController()
        {
            EnsureDataFolderExists();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var teams = new List<Team>();

            foreach (var path in Directory.GetFiles(DataFolder, "*.json"))
            {
                Team team = JsonConvert.DeserializeObject<Team>(
                    await System.IO.File.ReadAllTextAsync(path));

                teams.Add(team);
            }

            return Json(teams);
        }

/*
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var teamsDictionary = await stateManager.GetOrAddAsync<IReliableDictionary<string, Team>>(DICTIONARY_TEAMS);

            using (var tx = stateManager.CreateTransaction())
            {
                var team = await teamsDictionary.TryGetValueAsync(tx, name);
                if (team.HasValue)
                {
                    return Ok(team);
                }
            }

            return NotFound();
        }
*/

        [HttpPut("{name}")]
        public async Task Put(string name, [FromBody]Team team)
        {
            string path = $"{DataFolder}/{name}.json";
            string contents = JsonConvert.SerializeObject(team);

            await System.IO.File.WriteAllTextAsync(path, contents);
        }

        [HttpDelete("{name}")]
        public Task Delete(string name)
        {
            string path = $"{DataFolder}/{name}.json";

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            return Task.CompletedTask;
        }

        private static void EnsureDataFolderExists()
        {
            if (!Directory.Exists(DataFolder))
            {
                Directory.CreateDirectory(DataFolder);
            }
        }
    }
}
