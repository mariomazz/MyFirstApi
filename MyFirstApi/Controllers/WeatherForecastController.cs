using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Controllers.models;

namespace MyFirstApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("weather")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }


      /*  [HttpGet]
        [Route("users")]
        public List<Dictionary<string, string>> getUsers()
        {

            User user = new User("Mario", "Mazzarelli", 21);

            List<Dictionary<string, string>> users = new List<Dictionary<string, string>>();

            users.Add(user.toMap());
            users.Add(user.toMap());
            users.Add(user.toMap());
            users.Add(user.toMap());
            users.Add(user.toMap());
            users.Add(user.toMap());
            users.Add(user.toMap());
            users.Add(user.toMap());
            users.Add(user.toMap());
            users.Add(user.toMap());
            users.Add(user.toMap());





            return users;

        }
      */

    }
}