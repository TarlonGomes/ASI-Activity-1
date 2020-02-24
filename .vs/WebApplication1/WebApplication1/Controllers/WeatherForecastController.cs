using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Controllers
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

        [HttpPost("{zipCode}")]
        public WeatherForecast Post(int zipCode)
        {
            try
            {                
                Random r = new Random();
                int rInt = r.Next(-10, 40);
                
                return new WeatherForecast
                {
                    Date = DateTime.Now,
                    TemperatureC = rInt,
                    Summary = "I don't know, and I don't want to know"
                };
                
            }catch(Exception e)
            {
                return null;
            }
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var dateString = "02/24/2020 07:00 PM";
            var culture = CultureInfo.CreateSpecificCulture("en-US");
            var styles = DateTimeStyles.None;
            var rng = new Random();


            return Enumerable.Range(1, 1).Select(index => new WeatherForecast
            {
                Date = DateTime.Parse(dateString, culture, styles),
                TemperatureC = 14,
                Summary = "Sunny"
            })
            .ToArray();
        }
    }
}
