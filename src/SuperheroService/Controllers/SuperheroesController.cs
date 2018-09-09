using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SuperheroService.Controllers
{
    [Route("api/[controller]")]
    public class SuperheroesController : Controller
    {
        private static readonly Dictionary<string, Model.Superhero> Superheroes = new Dictionary<string, Model.Superhero>
        {
            ["Ant-Man"] = new Model.Superhero
            {
                Alias = "Ant-Man",
                RealName = "Scott Lang",
                Intelligence = 4,
                Strength = 5,
                Speed = 3,
                Durability = 5,
                EnergyProjection = 3,
                FightingSkills = 4
            },
            ["Black Panther"] = new Model.Superhero
            {
                Alias = "Black Panther",
                RealName = "T'Challa",
                Intelligence = 5,
                Strength = 3,
                Speed = 2,
                Durability = 3,
                EnergyProjection = 3,
                FightingSkills = 5
            },
            ["Black Widow"] = new Model.Superhero
            {
                Alias = "Black Widow",
                RealName = "Natasha Romanoff",
                Intelligence = 3,
                Strength = 3,
                Speed = 2,
                Durability = 3,
                EnergyProjection = 3,
                FightingSkills = 6
            },
            ["Captain America"] = new Model.Superhero
            {
                Alias = "Captain America",
                RealName = "Steven Rogers",
                Intelligence = 3,
                Strength = 3,
                Speed = 2,
                Durability = 3,
                EnergyProjection = 1,
                FightingSkills = 6
            },
            ["Dr. Strange"] = new Model.Superhero
            {
                Alias = "Dr. Strange",
                RealName = "Stephen Strange",
                Intelligence = 4,
                Strength = 2,
                Speed = 7,
                Durability = 2,
                EnergyProjection = 6,
                FightingSkills = 6
            },
            ["Falcon"] = new Model.Superhero
            {
                Alias = "Falcon",
                RealName = "Sam Wilson",
                Intelligence = 2,
                Strength = 2,
                Speed = 3,
                Durability = 2,
                EnergyProjection = 1,
                FightingSkills = 4
            },
            ["Hawkeye"] = new Model.Superhero
            {
                Alias = "Hawkeye",
                RealName = "Clint Barton",
                Intelligence = 3,
                Strength = 2,
                Speed = 2,
                Durability = 2,
                EnergyProjection = 1,
                FightingSkills = 6
            },
            ["Hulk"] = new Model.Superhero
            {
                Alias = "Hulk",
                RealName = "Bruce Banner",
                Intelligence = 2,
                Strength = 7,
                Speed = 3,
                Durability = 7,
                EnergyProjection = 5,
                FightingSkills = 4
            },
            ["Iron Man"] = new Model.Superhero
            {
                Alias = "Iron Man",
                RealName = "Tony Stark",
                Intelligence = 6,
                Strength = 6,
                Speed = 5,
                Durability = 6,
                EnergyProjection = 6,
                FightingSkills = 4
            },
            ["War Machine"] = new Model.Superhero
            {
                Alias = "War Machine",
                RealName = "James Rhodes",
                Intelligence = 3,
                Strength = 6,
                Speed = 5,
                Durability = 6,
                EnergyProjection = 6,
                FightingSkills = 4
            },
            ["Quicksilver"] = new Model.Superhero
            {
                Alias = "Quicksilver",
                RealName = "Pietro Maximoff",
                Intelligence = 3,
                Strength = 4,
                Speed = 5,
                Durability = 3,
                EnergyProjection = 1,
                FightingSkills = 4
            },
            ["Scarlet Witch"] = new Model.Superhero
            {
                Alias = "Scarlet Witch",
                RealName = "Wanda Maximoff",
                Intelligence = 3,
                Strength = 2,
                Speed = 2,
                Durability = 2,
                EnergyProjection = 6,
                FightingSkills = 3
            },
            ["Spider-Man"] = new Model.Superhero
            {
                Alias = "Spider-Man",
                RealName = "Peter Parker",
                Intelligence = 4,
                Strength = 4,
                Speed = 3,
                Durability = 3,
                EnergyProjection = 1,
                FightingSkills = 4
            },
            ["Thor"] = new Model.Superhero
            {
                Alias = "Thor",
                RealName = "Thor Odinson",
                Intelligence = 2,
                Strength = 7,
                Speed = 7,
                Durability = 6,
                EnergyProjection = 6,
                FightingSkills = 4
            },
            ["Vision"] = new Model.Superhero
            {
                Alias = "Vision",
                RealName = "Vision",
                Intelligence = 4,
                Strength = 5,
                Speed = 3,
                Durability = 6,
                EnergyProjection = 6,
                FightingSkills = 3
            },
            ["Winter Soldier"] = new Model.Superhero
            {
                Alias = "Winter Soldier",
                RealName = "Bucky Barnes",
                Intelligence = 2,
                Strength = 4,
                Speed = 2,
                Durability = 3,
                EnergyProjection = 1,
                FightingSkills = 6
            }
        };

        // GET api/superheroes
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Superheroes.Keys;
        }

        // GET api/superheroes/hulk
        [HttpGet("{alias}")]
        public Model.Superhero Get(string alias)
        {
            return Superheroes[alias];
        }
    }
}
