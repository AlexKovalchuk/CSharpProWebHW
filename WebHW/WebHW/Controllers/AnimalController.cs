using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using WebHW.Animals;

namespace WebHW.Controllers;

[Route("api/animals")]
[ApiController]
public class AnimalController : ControllerBase
{
    private static readonly List<IAnimal> s_animals = new List<IAnimal>
    {
        new Dog("Thor", "Odin", 120),
        new Dog("Zeus", "Hera", 45),
        new Dog("Achilles", "Patroclus", 30),
        new Dog("Hercules", "Alcmene", 50),
        new Dog("Ares", "Aphrodite", 35),
        new Dog("Odysseus", "Penelope", 40),
        new Dog("Apollo", "Artemis", 28),
        new Dog("Loki", "Frigga", 75),
        new Dog("Fenrir", "Jörmungandr", 200),
        new Dog("Beowulf", "Grendel", 32)
    };

    [HttpGet]
    public ActionResult<List<IAnimal>> GetAnimals()
    {
        return Ok(s_animals);
    }

    [HttpGet("details")]
    public ActionResult<List<IAnimal>> GetAnimalDetails([FromQuery] [Required] int index = 1)
    {
        if (index < 1 || index > s_animals.Count) return BadRequest("Index out of range");

        var animal = s_animals[index - 1];
        return Ok(animal);
    }

    [HttpPut("edit")]
    public ActionResult<List<IAnimal>> EditAnimal([FromQuery] [Required] int index, string name, string host, int age)
    {
        if (index < 1 || index > s_animals.Count) return BadRequest("Index out of range");

        var oldAnimal = s_animals[index - 1];
        var newName = name?.Length > 0 ? name : oldAnimal.Name;
        var newHost = host?.Length > 0 ? host : oldAnimal.HostName;
        var newAge = age > 0 ? age : oldAnimal.Age;
        s_animals[index - 1] = new Dog(newName, newHost, newAge);
        return Ok(s_animals[index - 1]);
    }

    [HttpDelete("delete")]
    public IActionResult DeleteAnimal([FromQuery] [Required] int index = 1)
    {
        if (index < 1 || index > s_animals.Count) return BadRequest("Index out of range");

        s_animals.RemoveAt(index - 1);
        return Ok();
    }

    [HttpPost("add")]
    public ActionResult<List<IAnimal>> EditAnimal(
        [FromQuery] [Required] string name,
        [FromQuery] [Required] string host,
        [FromQuery] [Required] int age
    )
    {
        s_animals.Add(new Dog(name, host, age));
        return Ok(s_animals[^1]);
    }
}
